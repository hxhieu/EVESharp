using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Server
{
    /// <summary>
    /// Background service to host the server
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="eveServer">Singleton instance constructed via the service collection</param>
    internal sealed class EveServerWorker (ILogger<EveServerWorker> logger, IEveTcpServer eveServer) : IHostedService, IHostedLifecycleService
    {
        public Task StartAsync (CancellationToken cancellationToken)
        {
            eveServer.Server.Start ();
            return Task.CompletedTask;
        }

        public Task StartedAsync (CancellationToken cancellationToken)
        {
            // TODO:
            logger.LogInformation ("{Service} is listening at :{Port}", nameof (EveServerWorker), eveServer.Server.Port);
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
