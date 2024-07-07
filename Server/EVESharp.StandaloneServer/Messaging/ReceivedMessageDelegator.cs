using EVESharp.EVE.Packets;
using EVESharp.EVE.Types.Network;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IMessageReceivedDelegator
    {
        Task Received (byte [] buffer, int bytesCount, Func<byte [], Task> sender);
    }

    internal sealed class ReceivedMessageDelegator (
        ILogger<ReceivedMessageDelegator> logger,
        IMessageDecoder messageTranslator,
        IClientCommandManager clientCommand
    ) : IMessageReceivedDelegator
    {
        public async Task Received (byte [] buffer, int bytesCount, Func<byte [], Task> sender)
        {
            var data = messageTranslator.Decode(buffer, bytesCount);
            logger.LogDebug ("RECEIVED {Data}", data.ToString ());

            // Try cascading processing the received data
            // It is pretty ugly because the implicit casts hide all of the validations

            string? delegateType = null;
            PyDataType? sentData = null;

            try
            {
                LowLevelVersionExchange handshake = data;
                delegateType = nameof (LowLevelVersionExchange);
                // TODO: Don't need to do anything with handshake received?
            }
            catch (ReceivedMessageHandlingException) { throw; }
            catch { /* Intentionally ignore this so it can flow to the next one */ }

            if (delegateType == null)
            {
                try
                {
                    ClientCommand command = data;
                    delegateType = $"{nameof (ClientCommand)} -> {command.Command}";
                    sentData = await clientCommand.HandleCommand (command, sender);
                }
                catch (ReceivedMessageHandlingException) { throw; }
                catch { /* Intentionally ignore this so it can flow to the next one */  }
            }

            if (delegateType == null)
            {
                try
                {
                    PyPacket packet = data;
                    delegateType = nameof (PyPacket);

                    // TODO: Stuff

                }
                catch (ReceivedMessageHandlingException) { throw; }
                catch { /* Intentionally ignore this so it can flow to the next one */ }
            }

            if (delegateType == null)
            {
                throw new NotImplementedException ($"Received data not yet implemented. {data}");
            }

            logger.LogDebug ("HANDLED {Type} -> {SentData}", delegateType, sentData?.ToString ());
        }
    }
}
