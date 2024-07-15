using AutoMapper;
using EVESharp.Database.Entity.Context;
using EVESharp.EVE.Network.Sockets;
using EVESharp.StandaloneServer.Database.Repository;
using EVESharp.StandaloneServer.Messaging;
using EVESharp.StandaloneServer.Network;
using EVESharp.StandaloneServer.Server;
using Microsoft.EntityFrameworkCore;
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
            builder.Services.Configure<EveServerAuthOptions> (configuration.GetSection (EveServerAuthOptions.ConfigSection));

            // Logging
            var seriLogger = new LoggerConfiguration ().ReadFrom.Configuration (builder.Configuration).CreateLogger ();
            builder.Services.AddSerilog (seriLogger);

            #region Database

            var connStr = configuration.GetConnectionString("EveSharpDb");
            var serverVer = ServerVersion.AutoDetect(connStr);
            builder.Services.AddDbContext<EveSharpDbContext> (dbContextOptions =>
            {
                dbContextOptions
                    .UseMySql (connStr, serverVer)
                // TODO: These for debugging, should be feature toggled
                //.LogTo (log => seriLogger.Debug (log))
                //.EnableSensitiveDataLogging ()
                //.EnableDetailedErrors ()
                ;
            }).AddRepositories ();

            #endregion

            #region Dependencies

            // Mapper
            builder.Services.AddAutoMapper (typeof (Program).Assembly);

            // Session is an important thing and it would require a lot of services
            builder.Services.AddTransient (services =>
            {
                return new EveTcpSession (
                    services.GetRequiredService<EveTcpServer> (),
                    services.GetRequiredService<ILogger<EveTcpSession>> (),
                    services.GetRequiredService<IMessageDecoder> (),
                    services.GetRequiredService<IEveTcpSessionDelegator> (),
                    services.GetRequiredService<IMapper>()
                );
            });

            builder.Services.AddTransient<StreamPacketizer> ();

            // Handle client messaging
            builder.Services.AddCoreMessaging ();
            builder.Services.AddClientCommandHandlers ();
            builder.Services.AddPackageHandlers ();

            builder.Services.AddSingleton<IMessageDecoder, MessageDecoder> ();
            builder.Services.AddSingleton<IEveTcpSessionDelegator, EveTcpSessionDelegator> ();

            // Default EVESharp single mode services
            builder.Services.AddEVESharpSingleNodeMachoNet (seriLogger); // TODO: Remove

            // Something else
            builder.Services.AddSingleton<MachoNetNext> (); // TODO: Remove
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
