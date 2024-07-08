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
    /// <param name="_database"></param>
    /// <param name="_transportManager"></param>
    /// <param name="_loginProcessor"></param>
    /// <param name="_configuration"></param>
    /// <param name="_logger"></param>
    internal class MachoNet (
        // All these required by the original implementation, do not change them
        IDatabase _database, ITransportManager _transportManager, IQueueProcessor<LoginQueueEntry> _loginProcessor, General _configuration, ILogger _logger
        // Add extra services below
    ) : EVESharpMachoNet (_database, _transportManager, _loginProcessor, _configuration, _logger), IEveServer
    {}
}
