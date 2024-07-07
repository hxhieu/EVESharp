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
    internal class EveTcpServer : TcpServer, IEveServer
    {
        private readonly ILogger<EveTcpServer> _logger;
        private readonly IServiceProvider _serviceProvider;

        public EveTcpServer (
            IOptions<EveServerOptions> options,
            ILogger<EveTcpServer> logger,
            IServiceProvider serviceProvider
        ) :
        // TODO: for now it will bind 0.0.0.0
        base (IPAddress.Any, options.Value.ListenPort)
        {
            // TODO: Tweak these
            OptionKeepAlive = true;
            OptionTcpKeepAliveTime = 64;
            OptionTcpKeepAliveInterval = 64;
            OptionTcpKeepAliveRetryCount = 2;

            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public void Initialize ()
        {
            OptionKeepAlive = true;
            _logger.LogInformation ("{Service} is listening at :{Port}", nameof (EveTcpServer), Port);
            Start ();
        }

        protected override TcpSession CreateSession () =>
            // Pretty bad we need to use the service locator here because `NetCoreServer` introduces circular referencing TcpServer -> TcpSession -> TcpServer
            _serviceProvider.GetRequiredService<EveTcpSession> ();

        protected override void OnDisconnected (TcpSession session)
        {
            // TODO: Not working, when the client disconnected at the middle of a request
            // Kill the session when it is disconnected on this server
            if (session != null && !session.IsDisposed)
            {
                session.Socket.Dispose ();
                session.Dispose ();
            }
        }

        protected override void OnStopping ()
        {
            _logger.LogError ("{Server} is stopping!", nameof (EveTcpServer));
        }

        protected override void OnStopped ()
        {
            _logger.LogError ("{Server} has stopped!", nameof (EveTcpServer));
        }


        protected override void OnError (SocketError error)
        {
            _logger.LogError ("{Server} caught an error with code '{Error}'", nameof (EveTcpServer), error);
        }
    }
}
