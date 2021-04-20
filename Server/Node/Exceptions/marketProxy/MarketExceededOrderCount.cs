﻿using EVE.Packets.Exceptions;
using PythonTypes.Types.Collections;
using PythonTypes.Types.Primitives;

namespace Node.Exceptions.marketProxy
{
    public class MarketExceededOrderCount : UserError
    {
        public MarketExceededOrderCount(int currentCount, int maximumCount) : base("MarketExceededOrderCount",
            new PyDictionary { ["curCnt"] = currentCount, ["maxCnt"] = maximumCount})
        {
        }
    }
}