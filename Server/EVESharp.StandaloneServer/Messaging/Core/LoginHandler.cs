using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Database.Repository;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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

            var existingAcc = _accountRepository.GetFirstAsync(x => x.AccountName.ToLower() == req.user_name.ToLower()).Result;

            // Auto create
            if (existingAcc == null && _authOptions.Value.AutoAccount)
            {
                throw new NotImplementedException ("Auto account creation is not yet implemented");
            }

            //var salt =  BCrypt.Net.BCrypt.GenerateSalt();
            //var password = BCrypt.Net.BCrypt.HashPassword("1234", salt).ToHex();
            //var s = salt.ToHex();

            if (existingAcc != null && string.IsNullOrWhiteSpace (existingAcc.PasswordV2))
            {
                // TODO: Redirect user to get new password
                throw new SessionMessageHandlingError ($"This is a legacy account and it needs to be upgraded");
            }

            // TODO: If we can separate banned account response?
            try
            {
                if (existingAcc == null || !existingAcc.Login (req.user_password) || existingAcc.Banned)
                {
                    owner.SendData (new GPSTransportClosed ("LoginAuthFailed"));
                    return null;
                }

                // TODO: Send login okay here

                throw new NotImplementedException ();
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "{Error}", ex.Message);
                // TODO: Exception feedback to user
                throw new SessionMessageHandlingError ("Cannot verify account login");
            }
        }
    }
}
