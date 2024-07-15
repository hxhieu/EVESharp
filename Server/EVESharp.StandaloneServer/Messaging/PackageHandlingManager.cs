using EVESharp.StandaloneServer.Messaging.Package;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging
{
    interface IPackageHandlingManager
    {
        PyDataType? HandlePackage (EveClientPacket packet, IEveTcpSession owner);
    }

    internal class PackageHandlingManager (
        ILogger<ClientCommandManager> _logger,
        IServiceProvider _serviceProvider
    ) : IPackageHandlingManager
    {
        public static string GetRegistryKey (string key) => $"{nameof (PackageHandlingManager)}::{key}";

        public PyDataType? HandlePackage (EveClientPacket packet, IEveTcpSession owner)
        {
            var handler = _serviceProvider.GetKeyedService<IPackageHandler> (GetRegistryKey (packet.HandlerKey))
               ?? throw new NotImplementedException (
                   $"{nameof (PackageHandlingManager)} handler for {packet.HandlerKey} is not yet implemented"
               );
            
            _logger.LogDebug ("HANDLING PACKAGE {Packet}", packet.ToString ());

            return handler.Handle (packet, owner);
        }
    }
}
