using EVESharp.EVE.Packets;
using EVESharp.Types;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IClientCommandManager
    {
        Task<PyDataType?> HandleCommand (ClientCommand command, Func<byte [], Task> sender);
    }

    internal sealed class ClientCommandManager (
        ILogger<ClientCommandManager> logger,
        IServiceProvider serviceProvider,
        IMediator mediator
    ) : IClientCommandManager
    {
        public static string GetRegistryKey (string command) => $"{nameof (ClientCommand)}::{command}";

        public async Task<PyDataType?> HandleCommand (ClientCommand command, Func<byte [], Task> sender)
        {
            var request = serviceProvider.GetKeyedService<IClientCommandRequest> (GetRegistryKey(command.Command))
                ?? throw new ReceivedMessageHandlingException (
                    $"{nameof(ClientCommand)} '{command.Command}' is not yet implemented"
                );
            request.Data = command;
            request.SendAsync = sender;
            var response = await mediator.Send (request);
            return response as PyDataType;
        }
    }
}
