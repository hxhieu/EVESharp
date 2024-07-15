using EVESharp.EVE.Packets;
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
        ICoreMessagingManager _coreMessaging
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
