using EVESharp.Types.Collections;
using System;
using System.Text;

namespace EVESharp.Types;

public class PyObject : PyDataType
{
    public bool         IsType2    { get; }
    public PyTuple      Header     { get; }
    public PyList       List       { get; }
    public PyDictionary Dictionary { get; }

    public PyObject (bool isType2, PyTuple header, PyList list = null, PyDictionary dict = null)
    {
        this.IsType2    = isType2;
        this.Header     = header;
        this.List       = list ?? new PyList ();
        this.Dictionary = dict ?? new PyDictionary ();
    }

    public override int GetHashCode ()
    {
        return (this.IsType2 ? 1 : 0) ^ this.Header.GetHashCode () ^ this.List.GetHashCode () ^ this.Dictionary.GetHashCode () ^ 0x36120485;
    }

    public override string ToString ()
    {
        var type = GetType ();
        var builder = new StringBuilder($"{Environment.NewLine}{type.Name}: {{{Environment.NewLine}");

        builder.Append('\t').Append("IsType2: ").Append(IsType2).Append(Environment.NewLine);
        builder.Append ('\t').Append ("Header: ").Append (Header.ToString()).Append (Environment.NewLine);
        builder.Append ('\t').Append ("List: ").Append (List.ToString ()).Append (Environment.NewLine);
        builder.Append ('\t').Append ("Dictionary: ").Append (Dictionary.ToString ()).Append (Environment.NewLine);

        builder.Append ('}');
        return builder.ToString ();
    }
}