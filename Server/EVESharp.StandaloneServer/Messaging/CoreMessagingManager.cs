using EVESharp.StandaloneServer.Messaging.Core;
using EVESharp.StandaloneServer.Server;
using Microsoft.Extensions.DependencyInjection;

namespace EVESharp.StandaloneServer.Messaging
{
    internal enum CoreMessageHandler
    {
        LowLevelVersionExchange,
        Login
    }

    internal interface ICoreMessagingManager
    {
        TResult? HandleCore<T, TResult> (CoreMessageHandler type, T data, IEveTcpSession owner)
            where T : class
            where TResult : class;
    }

    internal class CoreMessagingManager (IServiceProvider _serviceProvider) : ICoreMessagingManager
    {
        public static string GetRegistryKey (CoreMessageHandler type) => $"{nameof (CoreMessagingManager)}::{type}";

        public TResult? HandleCore<T, TResult> (CoreMessageHandler type, T data, IEveTcpSession owner)
            where T : class
            where TResult : class
        {
            var handler = _serviceProvider.GetKeyedService<ICoreHandler> (GetRegistryKey (type))
               ?? throw new NotImplementedException (
                   $"Handler for {type} is not yet implemented"
               );

            return handler.Handle<T, TResult> (data, owner);
        }
    }
}
