﻿namespace Node.Dogma.Interpreter.Opcodes
{
    public abstract class OpcodeWithBooleanOutput : Opcode
    {
        protected OpcodeWithBooleanOutput(Interpreter interpreter) : base(interpreter)
        {
        }

        public abstract bool Execute();
    }
}