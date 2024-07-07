using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Messaging.ClientCommands;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IClientCommandManager
    {
        PyDataType? HandleCommand (ClientCommand command, IEveTcpSession owner);
    }

    internal sealed class ClientCommandManager (
        ILogger<ClientCommandManager> _logger,
        IServiceProvider _serviceProvider
    ) : IClientCommandManager
    {
        public static string GetRegistryKey (string command) => $"{nameof (ClientCommand)}::{command}";

        public PyDataType? HandleCommand (ClientCommand command, IEveTcpSession owner)
        {
            var handler = _serviceProvider.GetKeyedService<IClientCommandHandler> (GetRegistryKey (command.Command))
               ?? throw new NotImplementedException (
                   $"{nameof (ClientCommand)} '{command.Command}' is not yet implemented"
               );

            return handler.Handle (command, owner);
        }
    }
}
