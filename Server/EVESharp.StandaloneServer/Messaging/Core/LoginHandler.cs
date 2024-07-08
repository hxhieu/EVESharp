using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal interface ILoginHandler
    {
        AuthenticationRsp? Handle (AuthenticationReq req, IEveTcpSession owner);
    }

    internal class LoginHandler : ILoginHandler
    {
        public AuthenticationRsp? Handle (AuthenticationReq req, IEveTcpSession owner)
        {
            throw new NotImplementedException ();
        }
    }
}
