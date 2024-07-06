using EVESharp.StandaloneServer.Session;
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
    /// <param name="sessionManager"></param>
    internal class EveTcpServer (
        IOptions<EveServerOptions> options,
        ILogger<EveTcpServer> logger,
        SessionManager sessionManager
    )
        // TODO: for now it will bind 0.0.0.0
        : TcpServer (IPAddress.Any, options.Value.ListenPort)
    {
        protected override TcpSession CreateSession () => sessionManager.CreateSession (this);

        protected override void OnError (SocketError error)
        {
            logger.LogError ("{Server} caught an error with code '{Error}'", nameof (EveTcpServer), error);
        }
    }
}
