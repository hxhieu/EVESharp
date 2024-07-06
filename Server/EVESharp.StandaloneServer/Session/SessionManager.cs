using Microsoft.Extensions.Logging;
using NetCoreServer;

namespace EVESharp.StandaloneServer.Session
{
    internal class SessionManager (ILoggerFactory loggerFactory)
    {
        public EveTcpSession CreateSession (TcpServer server)
        {
            // TODO: Session sure need more deps
            // And they can be passed in from SessionManager ctor
            return new EveTcpSession (
                server,
                loggerFactory.CreateLogger<EveTcpSession> ()
            );
        }
    }
}
