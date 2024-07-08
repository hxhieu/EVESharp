using EVESharp.StandaloneServer.Messaging.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class CoreMessagingManagerRegister
    {
        public static IServiceCollection AddCoreMessaging (this IServiceCollection services)
        {
            services
                .AddTransient<ILowLevelVersionExchangeHandler, LowLevelVersionExchangeHandler> ()
                .AddTransient<ILoginHandler, LoginHandler> ()
            ;

            services.AddSingleton<ICoreMessagingManager, CoreMessagingManager> ();

            return services;
        }
    }
}
