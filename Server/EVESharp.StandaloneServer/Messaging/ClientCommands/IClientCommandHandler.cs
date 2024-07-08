using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal interface IClientCommandHandler
    {
        PyDataType? Handle(ClientCommand command, IEveTcpSession owner);
    }
}
