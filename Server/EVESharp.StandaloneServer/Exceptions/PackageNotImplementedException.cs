using EVESharp.EVE.Exceptions;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Messaging;
using EVESharp.Types;
using EVESharp.Types.Collections;
using static EVESharp.EVE.Types.Network.PyPacket;

namespace EVESharp.StandaloneServer.Exceptions
{
    internal class PackageNotImplementedException (EveClientPacket requestPackage) : NotImplementedException (requestPackage.HandlerNotImplementedError), IClientResponseException
    {
        public PyDataType ClientResponse
        {
            get
            {
                // ensure destination has clientID in it
                PyAddressClient clientAddress = (PyAddressClient) requestPackage.Source;
                clientAddress.ClientID = requestPackage.UserID;
                var errorContent = new CustomError(requestPackage.HandlerNotImplementedError);

                // build a new packet with the correct information
                PyPacket result = new(PacketType.ERRORRESPONSE)
                {
                    // switch source and dest
                    Source      = requestPackage.Destination,
                    Destination = clientAddress,
                    UserID      = clientAddress.ClientID,
                    Payload = new PyTuple (3)
                    {
                        [0] = (int) requestPackage.Type,
                        [1] = (int) MachoErrorType.WrappedException,
                        [2] = new PyTuple (1) {[0] = new PySubStream (errorContent)}
                    }
                };

                return result;
            }
        }
    }
}
