﻿using PythonTypes.Types.Exceptions;
using PythonTypes.Types.Primitives;

namespace Node.Exceptions.contractMgr
{
    public class ConCannotTradeNonSingletonShip : UserError
    {
        public ConCannotTradeNonSingletonShip(string example, string station) : base("ConCannotTradeNonSingletonShip", new PyDictionary {["example"] = example, ["station"] = station})
        {
        }
    }
}