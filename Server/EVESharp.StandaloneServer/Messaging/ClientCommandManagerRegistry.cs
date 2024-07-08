using EVESharp.StandaloneServer.Messaging.ClientCommands;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class ClientCommandManagerRegistry
    {
        public static IServiceCollection AddClientCommandRequests (this IServiceCollection services)
        {
            services
                .AddKeyedTransient<IClientCommandHandler, VkClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey ("VK"))
                .AddKeyedTransient<IClientCommandHandler, VkClientCommandHandler> (
                    ClientCommandManager.GetRegistryKey ("VK1"))
                ;

            services.AddSingleton<IClientCommandManager, ClientCommandManager> ();

            return services;
        }
    }
}
