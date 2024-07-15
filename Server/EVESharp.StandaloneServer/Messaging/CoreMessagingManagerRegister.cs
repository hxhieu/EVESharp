using EVESharp.StandaloneServer.Messaging.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class CoreMessagingManagerRegister
    {
        public static IServiceCollection AddCoreMessaging (this IServiceCollection services)
        {
            // TODO: Maybe walk the assembly and dynamically register these
            services
                .AddKeyedTransient<ICoreHandler, LowLevelVersionExchangeHandler> (
                    CoreMessagingManager.GetRegistryKey (CoreMessageHandler.LowLevelVersionExchange))
                .AddKeyedTransient<ICoreHandler, LoginHandler> (
                    CoreMessagingManager.GetRegistryKey (CoreMessageHandler.Login))
                .AddKeyedTransient<ICoreHandler, PostAuthenticationHandler> (
                    CoreMessagingManager.GetRegistryKey (CoreMessageHandler.PostAuthentication))
            ;

            services.AddSingleton<ICoreMessagingManager, CoreMessagingManager> ();

            return services;
        }
    }
}
