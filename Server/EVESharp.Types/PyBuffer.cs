using EVESharp.Common.Checksum;
using System;
using System.Text;

namespace EVESharp.Types;

public class PyBuffer : PyDataType
{
    public byte [] Value  { get; }
    public int     Length => this.Value.Length;

    public PyBuffer (byte [] value)
    {
        this.Value = value;
    }

    public override int GetHashCode ()
    {
        return (int) CRC32.Checksum (this.Value);
    }

    public static implicit operator byte [] (PyBuffer obj)
    {
        return obj.Value;
    }

    public static implicit operator PyBuffer (byte [] value)
    {
        return new PyBuffer (value);
    }

    public override string ToString ()
    {
        var type = GetType ();
        var builder = new StringBuilder($"{Environment.NewLine}{type.Name}: [{Environment.NewLine}");

        builder.Append ($"{Value.Length} bytes");

        builder.Append (']');
        return builder.ToString ();
    }
}