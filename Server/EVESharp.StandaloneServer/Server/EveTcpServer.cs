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
    /// <param name="_options"></param>
    /// <param name="_logger"></param>
    /// <param name="_serviceProvider"></param>
    internal class EveTcpServer (
        IOptions<EveServerOptions> _options,
        ILogger<EveTcpServer> _logger,
        IServiceProvider _serviceProvider
        ) : TcpServer (IPAddress.Any, _options.Value.ListenPort), IEveServer
    {
        private readonly ILogger<EveTcpServer> _logger = _logger;
        private readonly IServiceProvider _serviceProvider = _serviceProvider;

        // Count not logged in sessions
        public int LoginCount => Sessions.Count (x => x.Value is IEveTcpSession { State: SessionState.LoggedIn });
        public int UserCount => Sessions.Count - LoginCount;

        public void Initialize ()
        {
            _logger.LogInformation ("{Service} is listening at :{Port}", nameof (EveTcpServer), Port);
            Start ();
        }

        protected override TcpSession CreateSession () =>
            // Pretty bad we need to use the service locator here because `NetCoreServer` introduces circular referencing TcpServer -> TcpSession -> TcpServer
            _serviceProvider.GetRequiredService<EveTcpSession> ();

        protected override void OnStopped ()
        {
            _logger.LogError ("{Server} has stopped!", nameof (EveTcpServer));
        }


        protected override void OnError (SocketError error)
        {
            _logger.LogError ("{Server} caught an error with code '{Error}'", nameof (EveTcpServer), error);
        }

        public T? GetInstance<T> () where T : class
        {
            return this as T;
        }
    }
}
