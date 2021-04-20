﻿using EVE.Packets.Exceptions;
using PythonTypes.Types.Collections;
using PythonTypes.Types.Primitives;

namespace Node.Exceptions.marketProxy
{
    public class RepackageBeforeSelling : UserError
    {
        public RepackageBeforeSelling(string item) : base("RepackageBeforeSelling", new PyDictionary {["item"] = item})
        {
        }
    }
}