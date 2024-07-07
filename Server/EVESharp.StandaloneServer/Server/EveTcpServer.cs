using EVESharp.StandaloneServer.Session;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreServer;
using System.Net;
using System.Net.Sockets;

namespace EVESharp.StandaloneServer.Server
{
    /// <summary>
    /// Extended implementation of `NetCoreServer.TcpServer`
    /// </summary>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    /// <param name="serviceProvider"></param>
    internal class EveTcpServer (
        IOptions<EveServerOptions> options,
        ILogger<EveTcpServer> logger,
        IServiceProvider serviceProvider
    )
        // TODO: for now it will bind 0.0.0.0
        : TcpServer (IPAddress.Any, options.Value.ListenPort), IEveServer
    {
        public void Initialize ()
        {
            logger.LogInformation ("{Service} is listening at :{Port}", nameof (EveTcpServer), Port);
            Start ();
        }

        protected override TcpSession CreateSession () =>
            // Pretty bad we need to use the service locator here because `NetCoreServer` introduces circular referencing TcpServer -> TcpSession -> TcpServer
            serviceProvider.GetRequiredService<EveTcpSession> ();

        protected override void OnError (SocketError error)
        {
            logger.LogError ("{Server} caught an error with code '{Error}'", nameof (EveTcpServer), error);
        }
    }
}
