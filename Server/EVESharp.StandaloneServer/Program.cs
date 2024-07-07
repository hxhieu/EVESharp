using EVESharp.EVE.Network.Sockets;
using EVESharp.StandaloneServer.Messaging;
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

            // Logging
            var seriLogger = new LoggerConfiguration ().ReadFrom.Configuration (builder.Configuration).CreateLogger ();
            builder.Services.AddSerilog (seriLogger);

            // Queries and handlers
            builder.Services.AddMediatR (cfg => cfg.RegisterServicesFromAssembly (typeof (Program).Assembly));

            #region Dependencies

            // Session is an important thing and it would require a lot of services
            builder.Services.AddTransient (services =>
            {
                using var scope = services.CreateScope();
                return new EveTcpSession (
                    scope.ServiceProvider.GetRequiredService<EveTcpServer> (),
                    scope.ServiceProvider.GetRequiredService<ILogger<EveTcpSession>> (),
                    scope.ServiceProvider.GetRequiredService<ICommonMessaging> (),
                    scope.ServiceProvider.GetRequiredService<IMessageReceivedDelegator> ()
                );
            });

            builder.Services.AddTransient<StreamPacketizer> ();

            // Client command registrations
            builder.Services.AddClientCommandRequests ();
            builder.Services.AddSingleton<IClientCommandManager, ClientCommandManager> ();

            builder.Services.AddSingleton<IMessageDecoder, MessageDecoder> ();
            builder.Services.AddSingleton<IMessageSender, MessageSender> ();
            builder.Services.AddSingleton<ICommonMessaging, CommonMessaging> ();
            builder.Services.AddSingleton<IMessageReceivedDelegator, ReceivedMessageDelegator> ();

            // Default EVESharp single mode services
            builder.Services.AddEVESharpSingleNodeMachoNet (seriLogger);

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

            var host = builder.Build ();

            // Start the server
            host.Run ();
        }
    }
}
