using System.IO;
using EVESharp.Types;
using EVESharp.Types.Collections;

namespace EVESharp.EVE.Packets;

public class ClientCommand
{
    public string Command { get; }

    public ClientCommand(string command)
    {
        Command = command;
    }

    public static implicit operator ClientCommand(PyDataType data)
    {
        PyTuple tuple = data as PyTuple;

        if (tuple.Count != 2 && tuple.Count != 3)
            throw new InvalidDataException("Expected a tuple of two or three elements");

        var command = tuple[0] as PyString;
        if (tuple.Count == 3)
        {
            command = tuple [1] as PyString;
        }

        return new ClientCommand(command);
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
}