using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal class LoginHandler
        : ICoreHandler
    {
        public TResult? Handle<T, TResult> (T data, IEveTcpSession owner)
            where T : class
            where TResult : class
        {
            var req = data as AuthenticationReq;

            throw new NotImplementedException ();
        }
    }
}
