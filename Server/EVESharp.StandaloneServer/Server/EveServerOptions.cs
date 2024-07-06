namespace EVESharp.StandaloneServer.Server
{
    internal class EveServerOptions
    {
        public const string ConfigSection = "EveServer";

        public int ListenPort { get; set; } = 26000;
    }
}
