﻿using PythonTypes.Types.Exceptions;
using PythonTypes.Types.Primitives;

namespace Node.Exceptions.marketProxy
{
    public class MktAsksMustSpecifyItems : UserError
    {
        public MktAsksMustSpecifyItems() : base("MktAsksMustSpecifyItems", null)
        {
        }
    }
}