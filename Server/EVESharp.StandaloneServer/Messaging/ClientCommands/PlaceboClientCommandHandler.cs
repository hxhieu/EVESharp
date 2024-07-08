using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal class PlaceboClientCommandHandler(ILogger<PlaceboClientCommandHandler> _logger) : IClientCommandHandler
    {
        public PyDataType? Handle (ClientCommand command, IEveTcpSession owner)
        {
            _logger.LogDebug (
                "HANDLING {Type} {Command}",
                nameof (PlaceboClientCommandHandler),
                command.Command
            );

            // Will response with the number of current login sessions
            var sentData =  new PyString("OK CC");

            owner.SendData (sentData);

            return sentData;
        }
    }
}
