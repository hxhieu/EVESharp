using EVESharp.Database.Account;
using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types.Collections;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal class AuthenticationAckHandler (
        ILogger<AuthenticationAckHandler> _logger
    ) : ICoreHandler
    {
        public string RegistrationKey => throw new NotImplementedException ();

        public TResult? Handle<T, TResult> (T data, IEveTcpSession owner)
            where T : class
            where TResult : class
        {
            if (data is not AuthenticationAckReq req)
            {
                throw new SessionMessageHandlingError ($"Cannot parse {nameof (AuthenticationAckReq)}");
            }

            _logger.LogDebug (
               "HANDLING {Type}",
               nameof (AuthenticationAckHandler)
            );

            // Send ack
            // Handshake sent when we are mostly in
            var ack = new HandshakeAck
            {
                //LiveUpdates    = this.MachoNet.LiveUpdates,
                //JIT            = this.Session.LanguageID,
                //UserID         = this.Session.UserID,
                MaxSessionTime = null,
                UserType       = AccountType.USER,
                //Role           = this.Session.Role,
                //Address        = this.Session.Address,
                InDetention    = null,
                ClientHashes   = new PyList (),
                //UserClientID   = this.Session.UserID
            };

            owner.SendData (ack);

            owner.State = SessionState.LoggedIn;

            return null;
        }
    }
}
