using EVESharp.EVE.Packets;
using EVESharp.Types;
using Version = EVESharp.EVE.Data.Version;

namespace EVESharp.StandaloneServer.Messaging
{
    internal static class CommonPacket
    {
        public static PyDataType LowLevelExchange (int activeSessions) => new LowLevelVersionExchange
        {
            Codename = Version.CODENAME,
            Birthday = Version.BIRTHDAY,
            Build = Version.BUILD,
            MachoVersion = Version.MACHO_VERSION,
            Version = Version.VERSION,
            UserCount = activeSessions,
            Region = Version.REGION
        };
        public static readonly PyDataType None = new PyNone();
        public static readonly PyDataType One = new PyInteger(1);
        public static readonly PyDataType Zero = new PyInteger(0);
        public static readonly PyDataType True = new PyBool(true);
        public static readonly PyDataType False = new PyBool(false);
    }
}
