using EVESharp.EVE.Packets;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Messaging;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Server
{
    internal interface IEveTcpSessionDelegator
    {
        void Received (byte [] buffer, int bytesCount, IEveTcpSession owner);
    }

    internal sealed class EveTcpSessionDelegator (
        ILogger<EveTcpSessionDelegator> _logger,
        IMessageDecoder _messageTranslator,
        IClientCommandManager _clientCommand
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
                e is NotImplementedException
            )
            { throw; }
            catch { /* Intentionally ignore this so it can flow to the next one */  }
        }

        public void Received (byte [] buffer, int bytesCount, IEveTcpSession owner)
        {
            var data = _messageTranslator.Decode(buffer, bytesCount);
            _logger.LogDebug ("RECEIVED {Data}", data.ToString ());

            ArgumentNullException.ThrowIfNull (owner, nameof (owner));

            // Try cascading processing the received data
            // It is pretty ugly because the implicit casts hide all of the validations

            string? delegateType = null;
            PyDataType? sentData = null;

            TryHandleMessage (() =>
            {
                LowLevelVersionExchange handshake = data;
                delegateType = nameof (LowLevelVersionExchange);
                // TODO: Don't need to do anything with handshake received?
            });

            if (delegateType == null)
            {
                TryHandleMessage (() =>
                {
                    ClientCommand command = data;
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

            _logger.LogDebug ("HANDLED {Type} with {SentData}", delegateType, sentData);
        }
    }
}
