using EVESharp.StandaloneServer.Network;
using EVESharp.StandaloneServer.Server;
using EVESharp.StandaloneServer.Session;
using Microsoft.Extensions.Configuration;
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
            var builder = Host.CreateApplicationBuilder (args);

            // Remember to create the local settings file by
            // Right-click the project > Manage User Secrets
            // Copy+paste the appsettings.json and tweak it
            var configuration = builder.Configuration;

            // Configuration options
            builder.Services.Configure<EveServerOptions> (configuration.GetSection (EveServerOptions.ConfigSection));

            #region Dependencies

            // Session is an important thing and it would require a lot of services
            builder.Services.AddTransient (services =>
            {
                return new EveTcpSession (
                    services.GetRequiredService<EveTcpServer> (),
                    services.GetRequiredService<ILogger<EveTcpSession>> ()
                );
            });

            // Default EVESharp single mode services
            //builder.Services.RegisterEVESharpSingleNodeMachoNet ();
            //builder.Services.AddSingleton<MachoNet> ();

            // Something else
            builder.Services.AddSingleton<MachoNetNext> ();
            builder.Services.AddSingleton<EveTcpServer> ();

            #endregion

            // Background worker
            var serverImpl = configuration.GetValue<ServerImplementation> ($"{EveServerOptions.ConfigSection}:Implementation");
            switch (serverImpl)
            {
                case ServerImplementation.MachoNetNext:
                    builder.Services.AddHostedService<EveServerWorker<MachoNetNext>> ();
                    break;
                case ServerImplementation.MachoNet:
                    builder.Services.AddHostedService<EveServerWorker<MachoNet>> ();
                    break;
                default:
                    builder.Services.AddHostedService<EveServerWorker<EveTcpServer>> ();
                    break;
            }

            // Logging
            var seriLogger = new LoggerConfiguration ().ReadFrom.Configuration (builder.Configuration).CreateLogger ();
            builder.Services.AddSingleton (_ => seriLogger); // For legacy direct access Serilog ILogger
            builder.Services.AddSerilog (seriLogger); // Microsoft logging framework backing with Serilog

            var host = builder.Build ();

            // Start the server
            host.Run ();
        }
    }
}
