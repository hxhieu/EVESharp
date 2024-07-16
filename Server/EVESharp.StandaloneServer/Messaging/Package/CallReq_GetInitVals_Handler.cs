using EVESharp.StandaloneServer.Exceptions;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;

namespace EVESharp.StandaloneServer.Messaging.Package
{
    internal class CallReq_GetInitVals_Handler : IPackageHandler
    {
        /// <summary>
        /// Must match client request HandlerKey
        /// </summary>
        public static string RegistrationKey => "CALL_REQ::GetInitVals";

        public PyDataType? Handle (EveClientPacket packet, IEveTcpSession owner)
        {
            throw new PackageNotImplementedException (packet);
        }
    }
}
