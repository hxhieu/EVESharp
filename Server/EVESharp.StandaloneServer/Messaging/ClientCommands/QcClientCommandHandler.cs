using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal class QcClientCommandHandler(
        ILogger<QcClientCommandHandler> _logger
    ) : IClientCommandHandler
    {
        public PyDataType? Handle (ClientCommand command, IEveTcpSession owner)
        {
            _logger.LogDebug (
                "HANDLING {Type} {Command} <- {Data}",
                nameof (QcClientCommandHandler),
                command.Command,
                command.ToString ()
            );

            // Will response with the number of current login sessions
            var sentData =  new PyInteger(owner.Server.LoginCount);

            owner.SendData (sentData);
            // Also need to send the handshake package afterward
            owner.SendData (CommonPacket.LowLevelExchange (owner.Server.UserCount));

            return sentData;
        }
    }
}
