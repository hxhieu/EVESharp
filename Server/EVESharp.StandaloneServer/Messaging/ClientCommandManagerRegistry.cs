using EVESharp.StandaloneServer.Messaging.ClientCommands;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class ClientCommandManagerRegistry
    {
        public static IServiceCollection AddClientCommandHandling (this IServiceCollection services)
        {
            // The register keys must much the command from client
            services
                .AddKeyedTransient<IClientCommandHandler, VkClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey ("VK"))
                .AddKeyedTransient<IClientCommandHandler, QcClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey ("QC"))
                .AddKeyedTransient<IClientCommandHandler, PlaceboClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey ("placebo"))
                ;

            services.AddSingleton<IClientCommandManager, ClientCommandManager> ();

            return services;
        }
    }
}
