using EVESharp.StandaloneServer.Server;
using EVESharp.StandaloneServer.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

            #region Dependencies

            // Session is an important thing and it would require a lot of services
            builder.Services.AddTransient (services =>
            {
                return new EveTcpSession (
                    services.GetRequiredService<IEveTcpServer> ().Server,
                    services.GetRequiredService<ILogger<EveTcpSession>> ()
                );
            });

            builder.Services.AddSingleton<IEveTcpServer, EveTcpServer> ();

            #endregion

            // Background worker
            builder.Services.AddHostedService<EveServerWorker> ();

            // Logging
            builder.Services.AddSerilog (logging =>
            {
                logging.ReadFrom.Configuration (builder.Configuration);
            });

            var host = builder.Build ();

            // Start the server
            host.Run ();
        }
    }
}
