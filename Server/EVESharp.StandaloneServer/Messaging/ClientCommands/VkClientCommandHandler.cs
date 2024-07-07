﻿using EVESharp.EVE.Packets;
using EVESharp.StandaloneServer.Server;
using EVESharp.Types;
using Microsoft.Extensions.Logging;

namespace EVESharp.StandaloneServer.Messaging.ClientCommands
{
    internal sealed class VkClientCommandHandler (
        ILogger<VkClientCommandHandler> _logger
    ) : IClientCommandHandler
    {
        public PyDataType? Handle (ClientCommand command, IEveTcpSession owner)
        {
            _logger.LogDebug (
                "HANDLING {Type} {Command} <- {Data}",
                nameof (ClientCommand),
                command.Command,
                command.ToString ()
            );

            // Supposedly just send any signal?
            var sentData =  CommonPacket.None;
            owner.SendData (sentData);

            return sentData;
        }
    }
}
