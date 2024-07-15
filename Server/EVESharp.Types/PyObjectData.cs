using System;
using System.Text;

namespace EVESharp.Types;

public class PyObjectData : PyDataType
{
    public PyString   Name      { get; }
    public PyDataType Arguments { get; }

    public PyObjectData (PyString name, PyDataType arguments)
    {
        this.Name      = name;
        this.Arguments = arguments;
    }

    public override int GetHashCode ()
    {
        return (this.Name?.GetHashCode () ?? PyNone.HASH_VALUE) ^ (this.Arguments?.GetHashCode () ?? PyNone.HASH_VALUE) ^ 0x69548514;
    }

    public override string ToString ()
    {
        var type = GetType ();
        var builder = new StringBuilder($"{Environment.NewLine}{type.Name}: {{{Environment.NewLine}");

        builder.Append ('\t').Append ("Name: ").Append (Name.ToString()).Append (Environment.NewLine);
        builder.Append ('\t').Append ("Arguments: ").Append (Arguments.ToString ()).Append (Environment.NewLine);
        
        builder.Append ('}');
        return builder.ToString ();
    }
}