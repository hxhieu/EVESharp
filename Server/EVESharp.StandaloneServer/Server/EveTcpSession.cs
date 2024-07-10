using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Messaging;
using EVESharp.Types;
using Microsoft.Extensions.Logging;
using NetCoreServer;
using System.Net.Sockets;

namespace EVESharp.StandaloneServer.Server
{
    internal interface IEveTcpSession
    {
        void SendData (PyDataType data, bool async = true);
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

        public void SendData (PyDataType data, bool async = true)
        {
            var buffer = _messageDecoder.Encode ( data );
            if (async)
            {
                SendAsync (buffer);
            }
            else
            {
                Send (buffer);
            }
            _logger.LogDebug ("SENT {Data} {Async}", data.ToString (), async ? "async" : "sync");
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
                SendData (new GPSTransportClosed (ex.Message));
                Dispose ();
            }
        }

        protected override void OnDisconnected ()
        {
            _logger.LogInformation ("TCP session {Id} -> disconnected!", Id);
            Dispose ();
        }
        protected override void OnError (SocketError error)
        {
            _logger.LogError ("TCP session {Id} -> caught an error with code '{Error}'", Id, error);
        }

        protected override void OnReceived (byte [] buffer, long offset, long size)
        {
            try
            {
                var packets = _messageDecoder.Decode(buffer, (int)size);
                var totalPacket = packets.Count();

                _logger.LogDebug (
                    "--------------------------{NewLine}RECEIVED PACKET(S) {Total}",
                    Environment.NewLine,
                    totalPacket
                );

                var currentPacket = 0;
                foreach (var packet in packets)
                {
                    currentPacket++;
                    _logger.LogDebug (
                        "{Current} of {Total} {Data}",
                        currentPacket,
                        totalPacket,
                        packet.ToString ()
                    );
                    _sessionDelegator.Received (packet, this);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "{Error}", ex.Message);
                // TODO: Will this disconnect the client? If so we need to handle UserError as well.
                SendData (new GPSTransportClosed (ex.Message));
                Dispose ();
            }
        }
    }
}
