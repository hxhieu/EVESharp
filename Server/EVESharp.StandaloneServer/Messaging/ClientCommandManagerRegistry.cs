using EVESharp.StandaloneServer.Messaging.ClientCommands;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class ClientCommandManagerRegistry
    {
        public static IServiceCollection AddClientCommandHandlers (this IServiceCollection services)
        {
            // The register keys must much the command from client
            // TODO: Maybe walk the assembly and dynamically register these
            services
                .AddKeyedTransient<IClientCommandHandler, VkClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey (VkClientCommandHandler.RegistrationKey))
                .AddKeyedTransient<IClientCommandHandler, QcClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey (QcClientCommandHandler.RegistrationKey))
                .AddKeyedTransient<IClientCommandHandler, PlaceboClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey (PlaceboClientCommandHandler.RegistrationKey))
                ;

            services.AddSingleton<IClientCommandManager, ClientCommandManager> ();

            return services;
        }
    }
}
