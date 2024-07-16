using EVESharp.EVE.Types.Network;
using EVESharp.Types;
using EVESharp.Types.Collections;
using System.Text;

namespace EVESharp.StandaloneServer.Messaging
{
    internal class EveClientPacket : PyPacket
    {
        public string HandlerNotImplementedError => $"Handler for {HandlerKey} is not implemented";

        public PyTuple? PayloadInfo
        {
            get
            {
                if (Payload == null || Payload.Count == 0)
                {
                    return null;
                }

                var payload = Payload [0] as PyTuple;
                if (payload == null)
                {
                    return null;
                }

                if (payload.Count < 2)
                {
                    return null;
                }

                var stream = payload[1] as PySubStream;
                if (stream == null)
                {
                    return null;
                }

                return stream.Stream as PyTuple;
            }
        }

        public string? Call => PayloadInfo != null ? PayloadInfo [1] as PyString : null;
        public PyTuple? Args => PayloadInfo != null ? PayloadInfo [2] as PyTuple : null;
        public PyDictionary? Sub => PayloadInfo != null ? PayloadInfo [3] as PyDictionary : null;

        public string HandlerKey => $"{Type}::{Call}";

        public override string ToString ()
        {
            var type = GetType ();
            var builder = new StringBuilder($"{Environment.NewLine}{type.Name}: {{{Environment.NewLine}");

            builder.Append ('\t').Append ("Type: ").Append (Type.ToString ()).Append (Environment.NewLine);
            builder.Append ('\t').Append ("Call: ").Append (Call).Append (Environment.NewLine);
            builder.Append ('\t').Append ("HandlerKey: ").Append (HandlerKey).Append (Environment.NewLine);
            builder.Append ('\t').Append ("Args: ").Append (Args).Append (Environment.NewLine);
            builder.Append ('\t').Append ("Sub: ").Append (Sub).Append (Environment.NewLine);

            builder.Append ('}');
            return builder.ToString ();
        }
    }
}
