namespace EVESharp.StandaloneServer.Server
{
    internal enum ServerImplementation
    {
        MachoNet,
        MachoNetNext,
        TcpServer
    }

    internal class EveServerOptions
    {
        public const string ConfigSection = "EveServer";

        public ushort ListenPort { get; set; } = 26000;
        public ServerImplementation Implementation { get; set; } = ServerImplementation.MachoNetNext;
    }
}
