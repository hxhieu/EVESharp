using EVESharp.StandaloneServer.Server;
using EVESharp.Types;

namespace EVESharp.StandaloneServer.Messaging.Package
{
    internal interface IPackageHandler : IKeyedService
    {
        PyDataType? Handle (EveClientPacket packet, IEveTcpSession owner);
    }
}
