using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal sealed class VkClientCommandHandler (
        ILogger<VkClientCommandHandler> _logger,
        IMessageDecoder _messageDecoder
    ) : IClientCommandHandler
    {
        public PyDataType? Handle (ClientCommand command, IEveTcpSession owner)
        {
            _logger.LogDebug (
                "HANDLING {Type} -> {Command} <- {Data}",
                nameof (ClientCommand),
                command.Command,
                command.ToString ()
            );

            // Supposedly just send any signal?
            var sentData =  CommonPacket.None;

            owner.Send (_messageDecoder.Encode (sentData));

            _logger.LogDebug (
                "HANDLED {Type} -> {Command} -> {SentData}",
                nameof (ClientCommand),
                command.Command,
                sentData.ToString ()
            );

            return sentData;
        }
    }
}
