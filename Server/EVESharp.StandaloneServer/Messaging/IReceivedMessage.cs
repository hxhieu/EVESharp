using EVESharp.Types;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IReceivedMessage
    {
        PyDataType Data { get; set; }
    }
}
