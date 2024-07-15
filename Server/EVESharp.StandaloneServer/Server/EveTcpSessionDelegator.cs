using AutoMapper;
using EVESharp.EVE.Packets;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Messaging;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Server
{
    internal interface IEveTcpSessionDelegator
    {
        void Received (PyDataType data, IEveTcpSession owner);
    }

    internal sealed class EveTcpSessionDelegator (
        ILogger<EveTcpSessionDelegator> _logger,
        IClientCommandManager _clientCommand,
        ICoreMessagingManager _coreMessaging,
        IPackageHandlingManager _packageHandling,
        IMapper _mapper
    ) : IEveTcpSessionDelegator
    {
        private static void TryHandleMessage (Action action)
        {
            try
            {
                action ();
            }
            // Throw on known exceptions
            catch (Exception e) when (
                e is SessionMessageHandlingError ||
                e is NotImplementedException ||
                e is ArgumentNullException ||
                e is InvalidOperationException
            )
            { throw; }
            catch { /* Intentionally ignore this so it can flow to the next one */  }
        }

        private (string?, PyDataType?) HandleAuthentication (PyDataType data, IEveTcpSession owner)
        {
            string? delegateType = null;
            PyDataType? respData = null;

            // Try cascading processing the received data
            // It is pretty ugly because the implicit casts hide all of the validations
            // Also quite important NOT to change the checking order

            TryHandleMessage (() =>
            {
                LowLevelVersionExchange handshake = data;
                delegateType = nameof (LowLevelVersionExchange);
                _coreMessaging.HandleCore<LowLevelVersionExchange, object> (
                    CoreMessageHandler.LowLevelVersionExchange,
                    handshake,
                    owner
                );
            });

            if (delegateType == null)
            {
                // AuthenticationReq Tuple[2]
                TryHandleMessage (() =>
                {
                    AuthenticationReq authReq = data;
                    delegateType = nameof (AuthenticationReq);
                    respData = _coreMessaging.HandleCore<AuthenticationReq, PyDataType> (
                        CoreMessageHandler.Login,
                        authReq,
                        owner
                    );
                });
            }

            if (delegateType == null)
            {
                // ClientCommand Tuple[2..3]
                TryHandleMessage (() =>
                {
                    ClientCommand command = data;
                    if (string.IsNullOrWhiteSpace (command.Command.Replace ("\0", string.Empty)))
                    {
                        return;
                    }
                    delegateType = nameof (ClientCommand);
                    respData = _clientCommand.HandleCommand (command, owner);
                });
            }

            return (delegateType, respData);
        }

        private (string?, PyDataType?) HandlePostAuthentication (PyDataType data, IEveTcpSession owner)
        {
            string? delegateType = null;
            PyDataType? respData = null;

            // Try cascading processing the received data
            // It is pretty ugly because the implicit casts hide all of the validations
            // Also quite important NOT to change the checking order

            TryHandleMessage (() =>
            {
                AuthenticationAckReq loginAckRequest = data;
                delegateType = nameof (AuthenticationAckReq);
                _coreMessaging.HandleCore<AuthenticationAckReq, object> (
                    CoreMessageHandler.PostAuthentication,
                    loginAckRequest,
                    owner
                );
            });

            return (delegateType, respData);
        }

        private (string?, PyDataType?) HandlePackage (PyDataType packet, IEveTcpSession owner)
        {
            string? delegateType = nameof(PyPacket);
            PyDataType? respData = null;

            if (packet is PyObject)
                throw new SessionMessageHandlingError ("Got exception from client");

            PyPacket pyPacket = packet;

            // replace the address if specific situations occur (why is CCP doing it like this?)
            if (pyPacket.Type == PyPacket.PacketType.NOTIFICATION && pyPacket.Source is PyAddressNode)
                pyPacket.Source = new PyAddressClient (owner.Session.UserID);

            // ensure the source address is right as it cannot be trusted
            if (pyPacket.Source is not PyAddressClient source)
                throw new SessionMessageHandlingError ("Received a packet from client without a source client address");
            if (pyPacket.UserID != owner.Session.UserID)
                throw new SessionMessageHandlingError ("Received a packet coming from a client trying to spoof it's userID");

            // ensure the clientId is set in the PyAddressClient
            source.ClientID = owner.Session.UserID;

            // Handle the package
            // The package can be handled when its corresponding handler is implement
            // Each handler should extend `IPackageHandler` with the `RegistryKey` set to the package's `HandlerKey`
            var eveClientPackage = _mapper.Map<EveClientPacket>(pyPacket);
            respData = _packageHandling.HandlePackage(eveClientPackage, owner);

            return (delegateType, respData);
        }

        public void Received (PyDataType data, IEveTcpSession owner)
        {
            ArgumentNullException.ThrowIfNull (owner, nameof (owner));

            string? delegateType = null;
            PyDataType? respData = null;

            switch (owner.State)
            {
                case SessionState.Authenticating:
                    (delegateType, respData) = HandleAuthentication (data, owner);
                    break;
                case SessionState.Authenticated:
                    (delegateType, respData) = HandlePostAuthentication (data, owner);
                    break;
                case SessionState.LoggedIn:
                    (delegateType, respData) = HandlePackage (data, owner);
                    break;
            }

            // If we need more handlers
            if (delegateType == null)
            {
                throw new NotImplementedException ($"Received data not yet implemented. {data}");
            }

            // If any clean up resp we need to send
            if (respData != null)
            {
                owner.SendData (respData);
            }
        }
    }
}
