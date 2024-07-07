using EVESharp.Common.Configuration;
using EVESharp.Database;
using EVESharp.EVE.Accounts;
using EVESharp.EVE.Messages.Processor;
using EVESharp.EVE.Messages.Queue;
using EVESharp.EVE.Network.Transports;
using EVESharp.Node.Accounts;
using EVESharp.Node.Configuration;
using EVESharp.Node.Server.Shared.Transports;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using MachoNetWrapper = EVESharp.StandaloneServer.Network.MachoNet;

namespace EVESharp.StandaloneServer
{
    internal static class EVESharpExtensions
    {
        /// <summary>
        /// Register minimum required deps for the EVESharp MachoNet to run
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection AddEVESharpSingleNodeMachoNet (this IServiceCollection services, ILogger logger)
        {
            // load configuration first
            General configuration = Loader.Load <General> ("configuration.conf");

            services.AddSingleton (configuration);
            services.AddSingleton (configuration.Database);
            services.AddSingleton (configuration.Authentication);

            // Common
            services.AddSingleton (() => logger);
            services.AddTransient (_ => new HttpClient ());
            services.AddSingleton<IDatabase, Database.Database> ();
            services.AddSingleton<ITransportManager, TransportManager> ();
            services.AddSingleton<IMessageQueue<LoginQueueEntry>, LoginQueue> ();
            services.AddSingleton<IQueueProcessor<LoginQueueEntry>, ThreadedProcessor<LoginQueueEntry>> ();

            services.AddSingleton<MachoNetWrapper> ();

            return services;
        }
    }
}
