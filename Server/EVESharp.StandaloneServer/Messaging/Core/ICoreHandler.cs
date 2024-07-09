using EVESharp.StandaloneServer.Server;

namespace EVESharp.StandaloneServer.Messaging.Core
{
    internal interface ICoreHandler
    {
        TResult? Handle<T, TResult> (T data, IEveTcpSession owner)
             where T : class
            where TResult : class;
    }
}
