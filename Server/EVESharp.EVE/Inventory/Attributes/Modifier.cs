﻿using EVESharp.EVE.Data.Dogma;

namespace EVESharp.EVE.Inventory.Attributes;

public class Modifier
{
    public Association Modification { get; init; }
    public Attribute   Value        { get; init; }
}