using EVESharp.StandaloneServer.Messaging.ClientCommands;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class ClientCommandManagerRegistry
    {
        public static IServiceCollection AddClientCommandRequests (this IServiceCollection services)
        {
            services
                .AddKeyedTransient<IClientCommandRequest, VkClientCmdRequest> (
                    ClientCommandManager.GetRegistryKey ("VK"))
                .AddKeyedTransient<IClientCommandRequest, VkClientCmdRequest> (
                    ClientCommandManager.GetRegistryKey ("VK1"))
                ;
            return services;
        }
    }
}
