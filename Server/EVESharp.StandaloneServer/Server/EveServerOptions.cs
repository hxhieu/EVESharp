namespace EVESharp.StandaloneServer.Server
{
    internal enum ServerImplementation
    {
        TcpServer,
        MachoNetNext,
        MachoNet,
    }

    internal class EveServerOptions
    {
        public const string ConfigSection = "EveServer";

        public ushort ListenPort { get; set; } = 26000;
        public ServerImplementation Implementation { get; set; }
    }
}
