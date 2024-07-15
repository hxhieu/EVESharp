using EVESharp.StandaloneServer.Messaging.Package;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class PackageHandlingManagerRegistry
    {
        public static IServiceCollection AddPackageHandlers (this IServiceCollection services)
        {
            // TODO: Walk the folder
            services
                .AddKeyedTransient<IPackageHandler, CallReq_GetInitVals_Handler> (
                    PackageHandlingManager.GetRegistryKey (CallReq_GetInitVals_Handler.RegistrationKey)
                )
            ;

            services.AddSingleton<IPackageHandlingManager, PackageHandlingManager> ();

            return services;
        }
    }
}
