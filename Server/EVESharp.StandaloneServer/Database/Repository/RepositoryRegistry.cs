using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Database.Repository
{
    internal static class RepositoryRegistry
    {
        public static IServiceCollection AddRepositories (this IServiceCollection services)
        {
            // TODO: Walk the folder instead
            services.AddScoped<IAccountRepository, AccountRepository> ();
            services.AddScoped<ILiveUpdateRepository, LiveUpdateRepository> ();

            return services;
        }
    }
}
