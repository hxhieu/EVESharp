using System.IO;
using EVESharp.Types;
using EVESharp.Types.Collections;

namespace EVESharp.EVE.Packets;

public class ClientCommand
{
    public string Command { get; }

    private static PyDataType _raw;

    public ClientCommand (string command)
    {
        Command = command;
    }

    public static implicit operator ClientCommand (PyDataType data)
    {
        _raw = data;

        PyTuple tuple = data as PyTuple;

        if (tuple.Count != 2 && tuple.Count != 3)
            throw new InvalidDataException ("Expected a tuple of two or three elements");

        // Command is either Tuple.1 or Tuple.2
        var command = tuple[0] as PyString ?? tuple [1] as PyString;

        return new ClientCommand (command);
    }

    public static implicit operator PyDataType (ClientCommand command)
    {
        return new PyTuple (3)
        {
            [0] = null,
            [1] = command.Command,
            [2] = null
        };
    }

    public override string ToString ()
    {
        return _raw?.ToString () ?? Command;
    }
}