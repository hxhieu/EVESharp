using AutoMapper;
using EVESharp.Database.Entity;
using EVESharp.EVE.Packets;
using EVESharp.EVE.Sessions;
using EVESharp.StandaloneServer.Messaging;
using EVESharp.Types;
using Microsoft.Extensions.Logging;
using NetCoreServer;
using System.Net.Sockets;

namespace EVESharp.StandaloneServer.Server
{
    internal enum SessionState
    {
        None,
        /// <summary>
        /// DB and permission checking
        /// </summary>
        Authenticating,

        /// <summary>
        /// Valid login and need to exchange ack
        /// </summary>
        Authenticated,
        LoggedIn
    }

    internal interface IEveTcpSession
    {
        string Id { get; }
        void SendData (PyDataType data, bool async = true);
        SessionState State { get; set; }
        IEveServer Server { get; }
        Session Session { get; }
        void SetAccount (Account account);
    }

    /// <summary>
    /// Extended `NetCoreServer.TcpSession`
    /// </summary>
    internal class EveTcpSession (
        IEveServer _server,
        ILogger<EveTcpSession> _logger,
        IMessageDecoder _messageDecoder,
        IEveTcpSessionDelegator _sessionDelegator,
        IMapper _mapper
    ) : TcpSession (_server.GetInstance<TcpServer> ()), IEveTcpSession
    {
        public new IEveServer Server => _server;

        public SessionState State { get; set; }

        public Session Session { get; private set; } = [];

        string IEveTcpSession.Id => Id.ToString ();

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

        public void SetAccount (Account account)
        {
            Session = _mapper.Map (account, Session);
        }

        protected override void OnConnected ()
        {
            _logger.LogInformation ("TCP session {Id} -> connected!", Id);
            State = SessionState.Authenticating;
            // Initial session data
            Session = _mapper.Map (this, Session);

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
                    "--------------------------{NewLine}RECEIVED DATA {Total}",
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
