using EVESharp.Common.Configuration;
using EVESharp.Database;
using EVESharp.EVE.Accounts;
using EVESharp.EVE.Messages.Processor;
using EVESharp.EVE.Network;
using EVESharp.EVE.Network.Transports;
using EVESharp.Node.Configuration;
using EVESharp.Node.Server.Shared.Transports;
using Microsoft.Extensions.DependencyInjection;
using MachoNet = EVESharp.Node.Server.Single.MachoNet;

namespace EVESharp.StandaloneServer.Extension
{
    internal static class EVESharpExtensions
    {
        /// <summary>
        /// Register minimum required deps for the EVESharp MachoNet to run
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection RegisterEVESharpSingleNodeMachoNet (this IServiceCollection services)
        {
            // load configuration first
            General configuration = Loader.Load <General> ("configuration.conf");

            services.AddSingleton (configuration);
            //services.AddSingleton<IDatabase, Database.Database> ();
            //services.AddSingleton<ITransportManager, TransportManager> ();
            //services.AddSingleton<IQueueProcessor<LoginQueueEntry>, ThreadedProcessor<LoginQueueEntry>> ();

            services.AddSingleton<IMachoNet, MachoNet> ();

            return services;
        }
    }
}
