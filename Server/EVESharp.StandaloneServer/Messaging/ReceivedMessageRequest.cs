using EVESharp.Types;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IReceivedMessageRequest
    {
        PyDataType? Data { get; set; }
        Func<byte [], Task>? SendAsync { get; set; }
    }

    internal abstract class ReceivedMessageRequest
    {
        public PyDataType? Data { get; set; }
        public Func<byte [], Task>? SendAsync { get; set; }
    }
}
