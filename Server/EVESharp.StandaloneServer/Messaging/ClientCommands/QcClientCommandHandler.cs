using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal class QcClientCommandHandler (
        ILogger<QcClientCommandHandler> _logger
    ) : IClientCommandHandler
    {
        public PyDataType? Handle (ClientCommand command, IEveTcpSession owner)
        {
            _logger.LogDebug (
                "HANDLING {Type} {Command}",
                nameof (QcClientCommandHandler),
                command.Command
            );

            // Will response with the number of current login sessions - this session itself
            var sentData =  new PyInteger(owner.Server.LoginCount - 1);

            owner.SendData (sentData);
            // Also its required to send the handshake package right afterward
            owner.SendData (CommonPacket.LowLevelExchange (owner.Server.UserCount));

            return sentData;
        }
    }
}
