namespace EVESharp.StandaloneServer.Server
{
    internal class EveServerAuthOptions
    {
        public const string ConfigSection = "Authentication";

        public bool AutoAccount { get; set; } = true;
        public string [] NewAccountRole { get; set; } = { "ROLE_PLAYER", "ROLE_LOGIN" };
        public string LoginMessageType { get; set; } = "MESSAGE";
        public string LoginMessage { get; set; } = "Welcome to EVESharp, the EVE Online server emulator written in C#";
    }
}
