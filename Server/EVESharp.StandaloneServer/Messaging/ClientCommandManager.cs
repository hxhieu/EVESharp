using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Exceptions;
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
        public static string GetRegistryKey (string command) => $"{nameof (ClientCommandManager)}::{command}";

        public PyDataType? HandleCommand (ClientCommand command, IEveTcpSession owner)
        {
            var handler = _serviceProvider.GetKeyedService<IClientCommandHandler> (GetRegistryKey (command.Command))
               ?? throw new ClientGenericErrorException (
                   $"{nameof (ClientCommand)} handler for {command.Command} is not yet implemented",
                   owner
               );

            return handler.Handle (command, owner);
        }
    }
}
