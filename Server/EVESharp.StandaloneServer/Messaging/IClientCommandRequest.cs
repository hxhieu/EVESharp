namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IClientCommandRequest : IReceivedMessageRequest
    {
        string Command { get; }
    }
}
