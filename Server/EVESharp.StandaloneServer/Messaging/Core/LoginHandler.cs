using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Database.Extensions;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Org.BouncyCastle.Asn1.Ocsp;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal class LoginHandler (
        ILogger<LoginHandler> _logger,
        IAccountRepository _accountRepository,
        IOptions<EveServerAuthOptions> _authOptions
    ) : ICoreHandler
    {
        public string RegistrationKey => CoreMessageHandler.Login.ToString ();

        public TResult? Handle<T, TResult> (T data, IEveTcpSession owner)
            where T : class
            where TResult : class
        {
            if (data is not AuthenticationReq req)
            {
                throw new SessionMessageHandlingError ($"Cannot parse {nameof (AuthenticationReq)}");
            }

            // Cannot process hashed password yet...
            if (req.user_password is null)
            {
                _logger.LogDebug ("Received a hashed password, need to ask for plain one.");
                // request the user a plain password
                owner.SendData (new PyInteger (1)); // 1 => plain, 2 => hashed
                return null;
            }

            var accExists = _accountRepository.GetFirstAsync(x => x.AccountName.ToLower() == req.user_name.ToLower()).Result != null;

            if (!accExists && _authOptions.Value.AutoAccount)
            {
                throw new NotImplementedException ("Auto account creation is not yet implemented");
            }

            var existingAcc = _accountRepository.Login(req.user_name, req.user_password).Result;

            // TODO: If we can separate banned account response?
            if (existingAcc == null || existingAcc.Banned)
            {
                owner.SendData (new GPSTransportClosed ("LoginAuthFailed"));
                return null;
            }

            throw new NotImplementedException ();
        }
    }
}
