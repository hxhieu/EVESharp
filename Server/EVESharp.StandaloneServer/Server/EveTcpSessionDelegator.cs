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
                e is ArgumentNullException
            )
            { throw; }
            catch { /* Intentionally ignore this so it can flow to the next one */  }
        }

        public void Received (PyDataType data, IEveTcpSession owner)
        {
            ArgumentNullException.ThrowIfNull (owner, nameof (owner));

            // Try cascading processing the received data
            // It is pretty ugly because the implicit casts hide all of the validations
            // Also quite important NOT to change the checking order

            string? delegateType = null;
            PyDataType? sentData = null;

            TryHandleMessage (() =>
            {
                LowLevelVersionExchange handshake = data;
                delegateType = nameof (LowLevelVersionExchange);
                _coreMessaging.LowLevelExchangeHandler.Handle (handshake, owner);
            });

            if (delegateType == null)
            {
                // AuthenticationReq Tuple[2]
                TryHandleMessage (() =>
                {
                    AuthenticationReq authReq = data;
                    delegateType = nameof (AuthenticationReq);
                    _coreMessaging.LoginHandler.Handle (authReq, owner);
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
                    sentData = _clientCommand.HandleCommand (command, owner);
                });
            }

            if (delegateType == null)
            {
                TryHandleMessage (() =>
                {
                    PyPacket packet = data;
                    delegateType = nameof (PyPacket);

                    // TODO: Stuff});
                });
            }

            // If we need more handlers
            if (delegateType == null)
            {
                throw new NotImplementedException ($"Received data not yet implemented. {data}");
            }
        }
    }
}
