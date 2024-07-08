using EVESharp.StandaloneServer.Messaging;
using Microsoft.Extensions.Logging;
using NetCoreServer;
using System.Net.Sockets;

namespace EVESharp.StandaloneServer.Server
{
    internal interface IEveTcpSession
    {
        long Send (byte [] buffer);
        bool IsLoggedIn { get; set; }
    }

    /// <summary>
    /// Extended `NetCoreServer.TcpSession`
    /// </summary>
    /// <param name="_server"></param>
    internal class EveTcpSession (
        IEveServer _server,
        ILogger<EveTcpSession> _logger,
        IMessageDecoder _messageDecoder,
        IEveTcpSessionDelegator _sessionDelegator
    ) : TcpSession (_server.GetInstance<TcpServer> ()), IEveTcpSession
    {
        public bool IsLoggedIn { get; set; }

        protected override void OnConnected ()
        {
            _logger.LogInformation ("TCP session {Id} -> connected!", Id);
            // Send handshake
            var buffer = _messageDecoder.Encode(CommonPacket.LowLevelExchange(_server.UserCount));
            try
            {
                Send (buffer);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "{Error}", ex.Message);
                // TODO: Sent errors instead of kill the connection
                Disconnect ();
            }
        }

        protected override void OnDisconnected ()
        {
            _logger.LogInformation ("TCP session {Id} -> disconnected!", Id);
        }
        protected override void OnError (SocketError error)
        {
            _logger.LogError ("TCP session {Id} -> caught an error with code '{Error}'", Id, error);
        }

        protected override void OnReceived (byte [] buffer, long offset, long size)
        {
            try
            {
                _sessionDelegator.Received (buffer, (int) size, this);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "{Error}", ex.Message);
                // TODO: Sent errors instead of kill the connection
                Disconnect ();
            }
        }
    }
}
