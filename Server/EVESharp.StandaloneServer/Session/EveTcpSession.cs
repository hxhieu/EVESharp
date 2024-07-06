using Microsoft.Extensions.Logging;
using NetCoreServer;
using System.Net.Sockets;
using System.Text;

namespace EVESharp.StandaloneServer.Session
{
    internal interface IEveTcpSession { }

    /// <summary>
    /// Extended `NetCoreServer.TcpSession`
    /// </summary>
    /// <param name="server"></param>
    internal class EveTcpSession (
        TcpServer server,
        ILogger<EveTcpSession> logger
    ) : TcpSession (server), IEveTcpSession
    {
        protected override void OnConnected ()
        {
            logger.LogInformation ("TCP session {Id} -> connected!", Id);
            // TODO: Everything starts from here
            Thread.Sleep (2000);
            Disconnect ();
        }

        protected override void OnDisconnected ()
        {
            logger.LogInformation ("TCP session {Id} -> disconnected!", Id);
        }
        protected override void OnError (SocketError error)
        {
            logger.LogError ("TCP session {Id} -> caught an error with code '{Error}'", Id, error);
        }

        protected override void OnReceived (byte [] buffer, long offset, long size)
        {
            string message = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
            logger.LogDebug ("TCP session {Id} -> incoming: {Message}", Id, message);
        }
    }
}
