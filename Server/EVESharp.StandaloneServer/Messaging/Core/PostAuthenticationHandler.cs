using EVESharp.Database.Account;
using EVESharp.Database.Types;
using EVESharp.EVE.Packets;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Database.Repository;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using EVESharp.Types.Collections;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal class PostAuthenticationHandler (
        ILogger<PostAuthenticationHandler> _logger,
        ILiveUpdateRepository _liveUpdateRepo
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
               nameof (PostAuthenticationHandler)
            );

            // Fetch and build live updates from DB
            PyList <PyObjectData> liveUpdates = [];

            var liveUpdateEntities = _liveUpdateRepo.GetAllAsync().Result;
            liveUpdateEntities.ForEach (x =>
            {
                PyDictionary entry = [];
                PyDictionary code  = new ()
                {
                    ["code"] = x.Code,
                    ["codeType"] = x.CodeType,
                    ["methodName"] = x.MethodName,
                    ["objectID"] = x.ObjectId
                };
                entry ["code"] = KeyVal.FromDictionary (code);
                liveUpdates.Add (KeyVal.FromDictionary (entry));
            });

            // Send ack
            // Handshake sent when we are mostly in
            var ack = new HandshakeAck
            {
                LiveUpdates    = liveUpdates,
                JIT            = owner.Session.LanguageID,
                UserID         = owner.Session.UserID,
                MaxSessionTime = null,
                UserType       = AccountType.USER,
                Role           = owner.Session.Role,
                Address        = owner.Session.Address,
                InDetention    = null,
                ClientHashes   = [],
                UserClientID   = owner.Session.UserID
            };

            owner.SendData (ack);

            // Initialise session
            // build the initial state notification
            PyPacket packet = new(PyPacket.PacketType.SESSIONINITIALSTATENOTIFICATION)
            {
                Source      = new PyAddressNode (owner.Session.NodeID),
                Destination = new PyAddressClient (owner.Session.UserID, 0),
                UserID      = owner.Session.UserID,
                Payload     = new SessionInitialStateNotification {Session = owner.Session},
                OutOfBounds = new PyDictionary {["channel"]                = "sessionchange"}
            };

            owner.SendData (packet);

            owner.State = SessionState.LoggedIn;

            return null;
        }
    }
}
