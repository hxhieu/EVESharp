using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal interface ILowLevelVersionExchangeHandler
    {
        PyDataType? Handle (LowLevelVersionExchange data, IEveTcpSession owner);
    }

    internal class LowLevelVersionExchangeHandler (ILogger<LowLevelVersionExchangeHandler> _logger) : ILowLevelVersionExchangeHandler
    {
        public PyDataType? Handle (LowLevelVersionExchange data, IEveTcpSession owner)
        {
            // TODO: Nothing to do LowLevelVersionExchange?
            _logger.LogDebug (
                "HANDLING {Type} _VOID_",
                nameof (LowLevelVersionExchangeHandler)
            );

            return null;
        }
    }
}
