using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal class PlaceboClientCommandHandler (ILogger<PlaceboClientCommandHandler> _logger) 
        : IClientCommandHandler
    {
        public static string RegistrationKey => "placebo";

        public PyDataType? Handle (ClientCommand command, IEveTcpSession owner)
        {
            _logger.LogDebug (
                "HANDLING {Type} {Command}",
                nameof (PlaceboClientCommandHandler),
                command.Command
            );

            owner.SendData (new PyString ("OK CC"));

            return null;
        }
    }
}
