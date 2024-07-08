using EVESharp.EVE.Accounts;
using EVESharp.EVE.Messages.Processor;
using EVESharp.EVE.Network;
using EVESharp.EVE.Network.Messages;
using EVESharp.EVE.Network.Transports;
using EVESharp.EVE.Sessions;
using EVESharp.EVE.Types.Network;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using EVESharp.Types.Collections;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ISerilogger = Serilog.ILogger;

namespace EVESharp.StandaloneServer.Network
{
    internal class MachoNetNext (
        ILogger<MachoNetNext> _logger,
        IOptions<EveServerOptions> _options
    ) : IEveServer
    {
        public long NodeID { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }
        public string Address { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }

        public RunMode Mode => RunMode.Single;

        public ushort Port => _options.Value.ListenPort;

        public ISerilogger Log => Serilog.Log.Logger;

        public string OrchestratorURL => string.Empty;

        public IQueueProcessor<LoginQueueEntry> LoginProcessor => throw new NotImplementedException ();

        public IQueueProcessor<MachoMessage> MessageProcessor { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }

        public ITransportManager TransportManager => throw new NotImplementedException ();

        public ISessionManager SessionManager { get => throw new NotImplementedException (); set => throw new NotImplementedException (); }

        public PyList<PyObjectData> LiveUpdates => throw new NotImplementedException ();

        public MachoNetNext Server => this;

        public void Initialize ()
        {
            _logger.LogInformation ("{Service} [{Mode}] is listening at :{Port}", nameof (MachoNetNext), Mode, Port);
        }

        public void QueueInputPacket (IMachoTransport origin, PyPacket packet)
        {
            throw new NotImplementedException ();
        }

        public void QueueOutputPacket (IMachoTransport origin, PyPacket packet)
        {
            throw new NotImplementedException ();
        }
    }
}
