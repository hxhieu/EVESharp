using EVESharp.StandaloneServer.Messaging.Core;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface ICoreMessagingManager
    {
        ILowLevelVersionExchangeHandler LowLevelExchangeHandler { get; }
    }

    internal class CoreMessagingManager (IServiceProvider _serviceProvider) : ICoreMessagingManager
    {
        public ILowLevelVersionExchangeHandler LowLevelExchangeHandler => 
            _serviceProvider.GetRequiredService<ILowLevelVersionExchangeHandler> ();
    }
}
