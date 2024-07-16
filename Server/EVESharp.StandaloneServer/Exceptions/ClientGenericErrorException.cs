using EVESharp.EVE.Exceptions;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using EVESharp.Types.Collections;
using static EVESharp.EVE.Types.Network.PyPacket;

namespace EVESharp.StandaloneServer.Exceptions
{
    internal class ClientGenericErrorException (string message, IEveTcpSession owner) : Exception (message ?? "Generic error"), IClientResponseException
    {
        public PyDataType ClientResponse
        {
            get
            {
                // ensure destination has clientID in it
                var userId = owner.State == SessionState.LoggedIn ? owner.Session.UserID : -1;
                PyAddressClient clientAddress = new (userId);
                PyAddressNode nodeAddress = new(owner.Session.NodeID);
                var errorContent = new CustomError (message);

                // build a new packet with the correct information
                PyPacket result = new(PacketType.ERRORRESPONSE)
                {
                    Source      = nodeAddress,
                    Destination = clientAddress,
                    UserID      = clientAddress.ClientID,
                    Payload = new PyTuple (3)
                    {
                        [0] = (int) PacketType.__Fake_Invalid_Type,
                        [1] = (int) MachoErrorType.WrappedException,
                        [2] = new PyTuple (1) {[0] = new PySubStream (errorContent)}
                    }
                };

                return result;
            }
        }
    }
}
