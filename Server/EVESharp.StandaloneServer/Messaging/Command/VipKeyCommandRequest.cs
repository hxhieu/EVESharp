using EVESharp.Types;
using MediatR;

namespace EVESharp.StandaloneServer.Messaging.Command
{
    internal interface IVipKeyCommandRequest : ICommandRequest, IRequest<PyDataType> { }

    internal class VipKeyCommandRequest : IVipKeyCommandRequest
    {
        public string Command => "VK";

        public required PyDataType Data { get; set; }
    }
}
