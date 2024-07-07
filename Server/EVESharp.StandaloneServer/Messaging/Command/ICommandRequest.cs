namespace EVESharp.StandaloneServer.Messaging.Command
{
    internal interface ICommandRequest : IReceivedMessage
    {
        string Command { get; }
    }
}
