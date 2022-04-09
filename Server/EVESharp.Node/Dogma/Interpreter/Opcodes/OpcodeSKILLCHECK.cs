﻿using System.IO;
using EVESharp.EVE.Dogma.Exception;

namespace EVESharp.Node.Dogma.Interpreter.Opcodes;

public class OpcodeSKILLCHECK : OpcodeWithBooleanOutput
{
    public OpcodeDEFSTRING ErrorMessage { get; private set; }

    public OpcodeSKILLCHECK (Interpreter interpreter) : base (interpreter) { }

    public override Opcode LoadOpcode (BinaryReader reader)
    {
        Opcode message = Interpreter.Step (reader);

        // the previous opcode should be a DEFSTRING which is the error message to send to the user
        if (message is not OpcodeDEFSTRING defstring)
            throw new DogmaMachineException ("The previous opcode is not a string");

        ErrorMessage = defstring;

        return this;
    }

    public override bool Execute ()
    {
        // TODO: HONOUR THE STRING PARAMETER FOR THE EXCEPTION

        // check if this character has the required skills to fit self
        Interpreter.Environment.Self.CheckPrerequisites (Interpreter.Environment.Character);

        return true;
    }
}