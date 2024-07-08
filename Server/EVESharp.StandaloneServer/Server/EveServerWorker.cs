using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Server
{
    internal interface IEveServer
    {
        T? GetInstance<T> () where T : class;
        void Initialize ();
        int LoginCount { get; }
        int UserCount { get; }
    }

    /// <summary>
    /// Background service to host the server
    /// </summary>
    /// <param name="_logger"></param>
    /// <param name="eveServer">Singleton instance constructed via the service collection</param>
    internal sealed class EveServerWorker<TServer> (
        ILogger<EveServerWorker<TServer>> _logger,
        TServer _server
    ) : IHostedService, IHostedLifecycleService where TServer : IEveServer
    {
        public Task StartAsync (CancellationToken cancellationToken)
        {
            _server.Initialize ();
            return Task.CompletedTask;
        }

        public Task StartedAsync (CancellationToken cancellationToken)
        {
            // TODO:
            return Task.CompletedTask;
        }

        public Task StartingAsync (CancellationToken cancellationToken)
        {
            // TODO:
            return Task.CompletedTask;
        }

        public Task StopAsync (CancellationToken cancellationToken)
        {
            // TODO:
            return Task.CompletedTask;
        }

        public Task StoppedAsync (CancellationToken cancellationToken)
        {
            // TODO:
            return Task.CompletedTask;
        }

        public Task StoppingAsync (CancellationToken cancellationToken)
        {
            // TODO:
            return Task.CompletedTask;
        }
    }
}
