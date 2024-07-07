using EVESharp.EVE.Packets;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Messaging;
using EVESharp.Types;
using Microsoft.Extensions.Logging;
using NetCoreServer;
using System.Net.Sockets;

namespace EVESharp.StandaloneServer.Server
{
    internal interface IEveTcpSession
    {
        void SendData (PyDataType data);
        bool IsLoggedIn { get; set; }
        IEveServer Server { get; }
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
        public new IEveServer Server => _server;

        public void SendData (PyDataType data)
        {
            var buffer = _messageDecoder.Encode ( data );
            Send (buffer);
            _logger.LogDebug ("SENT {Data}", data.ToString ());
        }

        protected override void OnConnected ()
        {
            _logger.LogInformation ("TCP session {Id} -> connected!", Id);
            // Send handshake
            try
            {
                SendData (CommonPacket.LowLevelExchange (_server.UserCount));
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "{Error}", ex.Message);
                SendData (new PyException ("GPSTransportClosed", ex.Message, null, null));
                Dispose ();
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
                var data = _messageDecoder.Decode(buffer, (int)size);
                _logger.LogDebug ("RECEIVED {Data}", data.ToString ());

                _sessionDelegator.Received (data, this);
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "{Error}", ex.Message);
                SendData (new PyException ("GPSTransportClosed", ex.Message, null, null));
                Dispose ();
            }
        }
    }
}
