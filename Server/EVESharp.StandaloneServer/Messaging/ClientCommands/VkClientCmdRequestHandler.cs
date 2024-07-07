using EVESharp.EVE.Packets;
using EVESharp.Types;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal sealed class VkClientCmdRequestHandler (
        ILogger<VkClientCmdRequestHandler> logger,
        IMessageDecoder messageDecoder
    ) : IRequestHandler<VkClientCmdRequest, PyDataType>
    {
        public async Task<PyDataType> Handle (VkClientCmdRequest request, CancellationToken cancellationToken)
        {
            logger.LogDebug (
                "HANDLING {Type} -> {Command} {Data}",
                nameof (ClientCommand),
                request.Command,
                request.Data?.ToString ()
            );
            var sentData =  new PyNone ();
            if (request.SendAsync == null)
            {
                throw new ReceivedMessageHandlingException ($"Cannot send message to client {nameof(request.SendAsync)} is null");
            }
            await request.SendAsync (messageDecoder.Encode (sentData));
            return sentData;
        }
    }
}
