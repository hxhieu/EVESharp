using EVESharp.EVE.Packets;
using EVESharp.EVE.Types.Network;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IMessageReceivedDelegator
    {
        Task Received (byte [] buffer, int bytesCount);
    }

    internal class MessageReceivedDelegator (
        ILogger<MessageReceivedDelegator> logger,
        IMessageTranslator messageTranslator,
        IServiceProvider serviceProvider
    ) : IMessageReceivedDelegator
    {
        public Task Received (byte [] buffer, int bytesCount)
        {
            try
            {
                var data = messageTranslator.Decode(buffer, bytesCount);
                logger.LogDebug ("RECEIVED {Data}", data.ToString ());

                // Try cascading processing the received data
                // It is pretty ugly because the implicit casts hide all the validations

                string? delegateType = null;

                try
                {
                    LowLevelVersionExchange handshake = data;
                    delegateType = nameof (LowLevelVersionExchange);
                    // TODO: Don't need to do anything with handshake received?
                }
                catch { /* Intentionally ignore this so it can flow to the next one */ }

                if (delegateType == null)
                {
                    try
                    {
                        ClientCommand command = data;
                        delegateType = nameof (ClientCommand);

                        // TODO: Stuff

                    }
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
                    catch { /* Intentionally ignore this so it can flow to the next one */ }
                }

                if (delegateType == null)
                {
                    throw new NotImplementedException ($"Received data not yet implemented. {data.ToString ()}");
                }

                logger.LogDebug ("HANDLED {Type} {Data}", delegateType, data.ToString ());
            }
            catch (Exception ex)
            {
                logger.LogError (ex, "{Error}", ex.Message);
            }
            return Task.CompletedTask;
        }
    }
}
