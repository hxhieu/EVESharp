using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IMessageSender
    {
        Task SendAsync (PyDataType data, Func<byte [], Task> send);
    }

    internal class MessageSender (ILogger<MessageSender> logger, IMessageDecoder messageTranslator) : IMessageSender
    {
        public async Task SendAsync (PyDataType data, Func<byte [], Task> send)
        {
            if (send == null)
            {
                logger.LogWarning (
                    "{Service} attempted to call {Method} with NULL {Sender}, ignored.",
                    GetType ().Name,
                    nameof (SendAsync),
                    nameof (send)
                );
                return;
            }

            try
            {
                var buffer = messageTranslator.Encode (data);
                await send (buffer);
                logger.LogDebug ("SENT {Data}", data.ToString ());
            }
            catch (Exception ex)
            {
                logger.LogError (ex, "{Error}", ex.Message);
            }
        }
    }
}
