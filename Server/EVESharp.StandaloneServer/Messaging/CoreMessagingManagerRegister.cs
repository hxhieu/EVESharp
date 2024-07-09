using EVESharp.StandaloneServer.Messaging.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class CoreMessagingManagerRegister
    {
        public static IServiceCollection AddCoreMessaging (this IServiceCollection services)
        {
            services
                .AddKeyedTransient<ICoreHandler, LowLevelVersionExchangeHandler> (
                    CoreMessagingManager.GetRegistryKey (CoreMessageType.LowLevelVersionExchange))
                .AddKeyedTransient<ICoreHandler, LoginHandler> (
                    CoreMessagingManager.GetRegistryKey (CoreMessageType.Login))
            ;

            services.AddSingleton<ICoreMessagingManager, CoreMessagingManager> ();

            return services;
        }
    }
}
