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
                    CoreMessagingManager.GetRegistryKey (LowLevelVersionExchangeHandler.RegistrationKey))
                .AddKeyedTransient<ICoreHandler, LoginHandler> (
                    CoreMessagingManager.GetRegistryKey (LoginHandler.RegistrationKey))
                .AddKeyedTransient<ICoreHandler, PostAuthenticationHandler> (
                    CoreMessagingManager.GetRegistryKey (PostAuthenticationHandler.RegistrationKey))
            ;

            services.AddSingleton<ICoreMessagingManager, CoreMessagingManager> ();

            return services;
        }
    }
}
