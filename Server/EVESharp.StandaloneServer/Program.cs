using EVESharp.StandaloneServer.Server;
using EVESharp.StandaloneServer.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EVESharp.StandaloneServer
{
    internal class Program
    {
        static void Main (string [] args)
        {
            // Remember to create the local settings file by
            // Right-click the project > Manage User Secrets
            // Copy+paste the appsettings.json and tweak it
            var builder = Host.CreateApplicationBuilder (args);

            // Configuration options
            builder.Services.Configure<EveServerOptions> (builder.Configuration.GetSection (EveServerOptions.ConfigSection));

            // Dependencies
            builder.Services.AddSingleton<EveTcpServer> ();
            builder.Services.AddSingleton<SessionManager> ();

            // Background worker
            builder.Services.AddHostedService<EveServerWorker> ();

            // Logging
            builder.Services.AddSerilog ((_, logging) =>
            {
                logging.ReadFrom.Configuration (builder.Configuration);
            });

            var host = builder.Build ();

            // Start the server
            host.Run ();
        }
    }
}
