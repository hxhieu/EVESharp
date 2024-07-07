using EVESharp.Types;
using MediatR;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal sealed class VkClientCmdRequest : ReceivedMessageRequest, IClientCommandRequest, IRequest<PyDataType>
    {
        public string Command => "VK";
    }
}
