using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Server
{
    internal interface IEveServer
    {
        void Initialize ();
    }

    /// <summary>
    /// Background service to host the server
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="eveServer">Singleton instance constructed via the service collection</param>
    internal sealed class EveServerWorker<TServer> (
        ILogger<EveServerWorker<TServer>> logger,
        TServer server
    ) : IHostedService, IHostedLifecycleService where TServer: IEveServer
    {
        public Task StartAsync (CancellationToken cancellationToken)
        {
            server.Initialize ();
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
