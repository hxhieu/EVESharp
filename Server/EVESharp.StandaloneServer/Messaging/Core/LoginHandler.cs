﻿using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Database.Repository;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Version = EVESharp.EVE.Data.Version;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal class LoginHandler (
        ILogger<LoginHandler> _logger,
        IAccountRepository _accountRepository,
        IOptions<EveServerAuthOptions> _authOptions
    ) : ICoreHandler
    {
        public static string RegistrationKey => CoreMessageHandler.Login;

        public TResult? Handle<T, TResult> (T data, IEveTcpSession owner)
            where T : class
            where TResult : class
        {
            if (data is not AuthenticationReq req)
            {
                throw new CatastropheException ($"Cannot parse {nameof (AuthenticationReq)}");
            }

            _logger.LogDebug (
               "HANDLING {Type}",
               nameof (LoginHandler)
            );

            owner.State = SessionState.Authenticating;
            
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
                throw new CatastropheException ("Auto account creation is not yet implemented");
            }

            if (existingAcc != null && string.IsNullOrWhiteSpace (existingAcc.PasswordV2))
            {
                // TODO: Redirect user to get new password
                throw new CatastropheException ($"This is a legacy account and it needs to be upgraded");
            }

            try
            {
                // TODO: If we can separate banned account response?
                if (existingAcc == null || !existingAcc.Login (req.user_password) || existingAcc.Banned)
                {
                    owner.SendData (new GPSTransportClosed ("LoginAuthFailed"));
                    return null;
                }

                // String "None" marshaled
                byte [] func_marshaled_code = {0x74, 0x04, 0x00, 0x00, 0x00, 0x4E, 0x6F, 0x6E, 0x65};

                // Send login okay here
                var authResponse = new AuthenticationRsp
                {
                    serverChallenge = "",
                    func_marshaled_code = func_marshaled_code,
                    verification = false,
                    cluster_usercount = owner.Server.UserCount,
                    user_logonqueueposition = 1, // TODO: Always 1?
                    challenge_responsehash = "55087",

                    macho_version = Version.MACHO_VERSION,
                    boot_version = Version.VERSION,
                    boot_build = Version.BUILD,
                    boot_codename = Version.CODENAME,
                    boot_region = Version.REGION
                };

                owner.SendData (authResponse);

                owner.State = SessionState.Authenticated;

                // Update session
                owner.SetAccount (existingAcc);

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError (ex, "{Error}", ex.Message);
                throw new CatastropheException ("Cannot verify account login");
            }
        }
    }
}
