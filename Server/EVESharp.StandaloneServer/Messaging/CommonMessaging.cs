using EVESharp.EVE.Packets;
using Microsoft.Extensions.Logging;
using Version = EVESharp.EVE.Data.Version;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface ICommonMessaging : IMessageSender
    {
        Task SendHandShakeAsync (Func<byte [], Task> sender);
    }

    internal class CommonMessaging (
        ILogger<CommonMessaging> logger,
        IMessageTranslator messageHandler
    ) : MessageSender (logger, messageHandler), ICommonMessaging
    {
        public async Task SendHandShakeAsync (Func<byte [], Task> sender)
        {
            var data = new LowLevelVersionExchange
            {
                Codename     = Version.CODENAME,
                Birthday     = Version.BIRTHDAY,
                Build        = Version.BUILD,
                MachoVersion = Version.MACHO_VERSION,
                Version      = Version.VERSION,
                UserCount    = 0, // TODO: Get from server instance
                Region       = Version.REGION
            };

            await SendAsync (data, sender);
        }
    }
}
