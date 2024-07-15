using EVESharp.Common.Compression;
using EVESharp.EVE.Network.Sockets;
using EVESharp.Types;
using EVESharp.Types.Serialization;

namespace EVESharp.StandaloneServer.Messaging
{
    internal interface IMessageDecoder
    {
        IEnumerable<PyDataType> Decode (byte [] buffer, int bytesCount);
        byte [] Encode (PyDataType data);
    }

    internal class MessageDecoder (StreamPacketizer _streamPacketizer) : IMessageDecoder
    {
        public IEnumerable<PyDataType> Decode (byte [] buffer, int bytesCount)
        {
            _streamPacketizer.QueuePackets (buffer, bytesCount);
            _streamPacketizer.ProcessPackets ();
            while (_streamPacketizer.PacketCount> 0)
            {
                yield return Unmarshal.ReadFromByteArray (_streamPacketizer.PopItem ());
            }
        }

        public byte [] Encode (PyDataType data)
        {
            // convert the data to bytes
            byte [] encodedPacket = Marshal.ToByteArray (data);
            // compress the packet if required
            if (encodedPacket.Length > Common.Constants.Network.MAX_PACKET_SIZE)
                encodedPacket = ZlibHelper.Compress (encodedPacket);

            // generate the final buffer
            byte [] packetBuffer = new byte [encodedPacket.Length + sizeof (int)];

            // write the packet size and the buffer to the final buffer
            Buffer.BlockCopy (BitConverter.GetBytes (encodedPacket.Length), 0, packetBuffer, 0, sizeof (int));
            Buffer.BlockCopy (encodedPacket, 0, packetBuffer, sizeof (int), encodedPacket.Length);

            return packetBuffer;
        }
    }
}
