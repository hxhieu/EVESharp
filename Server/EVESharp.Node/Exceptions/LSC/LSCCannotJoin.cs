﻿namespace EVESharp.Node.Exceptions.LSC;

public class LSCCannotJoin : LSCStandardException
{
    public LSCCannotJoin (string message) : base ("LSCCannotJoin", message) { }
}