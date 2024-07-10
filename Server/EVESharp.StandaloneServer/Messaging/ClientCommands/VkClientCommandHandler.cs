using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal sealed class VkClientCommandHandler (
        ILogger<VkClientCommandHandler> _logger
    ) : IClientCommandHandler
    {
        public string RegistrationKey => "VK";

        public PyDataType? Handle (ClientCommand command, IEveTcpSession owner)
        {
            _logger.LogDebug (
                "HANDLING {Type} {Command} _VOID_",
                nameof (ClientCommand),
                command.Command
            );

            return null;
        }
    }
}
