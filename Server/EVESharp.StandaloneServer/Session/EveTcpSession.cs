using EVESharp.StandaloneServer.Messaging;
using Microsoft.Extensions.Logging;
using NetCoreServer;
using System.Net.Sockets;

namespace EVESharp.StandaloneServer.Session
{
    internal interface IEveTcpSession { }

    /// <summary>
    /// Extended `NetCoreServer.TcpSession`
    /// </summary>
    /// <param name="server"></param>
    internal class EveTcpSession (
        TcpServer server,
        ILogger<EveTcpSession> logger,
        ICommonMessaging commonMessaging,
        IMessageReceivedDelegator messageReceivedDelegator
    ) : TcpSession (server), IEveTcpSession
    {
        protected override void OnConnected ()
        {
            logger.LogInformation ("TCP session {Id} -> connected!", Id);
            commonMessaging.SendHandShakeAsync ((buffer) =>
            {
                SendAsync (buffer);
                return Task.CompletedTask;
            });
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
            messageReceivedDelegator.Received (buffer, (int)size).Wait();
        }
    }
}
