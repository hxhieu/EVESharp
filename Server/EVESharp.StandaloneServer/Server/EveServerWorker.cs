using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Server
{
    /// <summary>
    /// Background service to host the server
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="server">Singleton instance constructed via the service collection</param>
    internal sealed class EveServerWorker (ILogger<EveServerWorker> logger, EveTcpServer server) : IHostedService, IHostedLifecycleService
    {
        public Task StartAsync (CancellationToken cancellationToken)
        {
            server.Start ();
            return Task.CompletedTask;
        }

        public Task StartedAsync (CancellationToken cancellationToken)
        {
            // TODO:
            logger.LogInformation ("{Service} is listening at :{Port}", nameof (EveServerWorker), server.Port);
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
