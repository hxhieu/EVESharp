using EVESharp.EVE.Packets;
using EVESharp.Types;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.Command
{
    internal class VipKeyCommandRequestHandler (ILogger<VipKeyCommandRequestHandler> logger) : IRequestHandler<VipKeyCommandRequest, PyDataType>
    {
        public Task<PyDataType> Handle (VipKeyCommandRequest request, CancellationToken cancellationToken)
        {
            logger.LogDebug ("HANDLING {Type} -> {Command} {Data}", nameof (ClientCommand), nameof (VipKeyCommandRequest), request.Data.ToString ());
            return Task.FromResult ((PyDataType) new PyBool (true));
        }
    }
}
