using EVESharp.StandaloneServer.Server;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal class LowLevelVersionExchangeHandler (ILogger<LowLevelVersionExchangeHandler> _logger)
        : ICoreHandler
    {
        public TResult? Handle<T, TResult> (T data, IEveTcpSession owner)
            where T : class
            where TResult : class
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
