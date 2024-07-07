using EVESharp.Database;
using EVESharp.EVE.Accounts;
using EVESharp.EVE.Messages.Processor;
using EVESharp.EVE.Network.Transports;
using EVESharp.Node.Configuration;
using EVESharp.StandaloneServer.Server;
using Serilog;
using EVESharpMachoNet = EVESharp.Node.Server.Single.MachoNet;

namespace EVESharp.StandaloneServer.Network
{
    /// <summary>
    /// This does nothing extra from the base MachoNet but having the distinguish interface for DI
    /// </summary>
    /// <param name="database"></param>
    /// <param name="transportManager"></param>
    /// <param name="loginProcessor"></param>
    /// <param name="configuration"></param>
    /// <param name="logger"></param>
    internal class MachoNet (IDatabase database, ITransportManager transportManager, IQueueProcessor<LoginQueueEntry> loginProcessor, General configuration, ILogger logger)
        : EVESharpMachoNet (database, transportManager, loginProcessor, configuration, logger), IEveServer
    { }
}
