﻿/*
    ------------------------------------------------------------------------------------
    LICENSE:
    ------------------------------------------------------------------------------------
    This file is part of EVE#: The EVE Online Server Emulator
    Copyright 2021 - EVE# Team
    ------------------------------------------------------------------------------------
    This program is free software; you can redistribute it and/or modify it under
    the terms of the GNU Lesser General Public License as published by the Free Software
    Foundation; either version 2 of the License, or (at your option) any later
    version.

    This program is distributed in the hope that it will be useful, but WITHOUT
    ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
    FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License along with
    this program; if not, write to the Free Software Foundation, Inc., 59 Temple
    Place - Suite 330, Boston, MA 02111-1307, USA, or go to
    http://www.gnu.org/copyleft/lesser.txt.
    ------------------------------------------------------------------------------------
    Creator: Almamu
*/

using System.Collections;
using System.Collections.Generic;
using EVESharp.Database.Inventory;
using EVESharp.EVE.Data.Inventory;
using EVESharp.Node.Database;
using EVESharp.Node.Dogma;
using EVESharp.PythonTypes.Types.Database;

namespace EVESharp.Node.Data.Inventory;

public class Types : ITypes
{
    private readonly Dictionary <int, Type> mTypes;
    public Type this [TypeID id] => this [(int) id];

    public Types (IDatabaseConnection Database, IAttributes attributes, IDefaultAttributes defaultAttributes, IGroups groups, IExpressions expressionManager)
    {
        this.mTypes = Database.LoadItemTypes (attributes, defaultAttributes, groups, expressionManager);
    }

    public bool ContainsKey (int typeID)
    {
        return this.mTypes.ContainsKey (typeID);
    }

    public bool TryGetValue (int typeID, out Type value)
    {
        return this.mTypes.TryGetValue (typeID, out value);
    }

    public Type this [int id] => this.mTypes [id];
    public IEnumerable <int>  Keys   => this.mTypes.Keys;
    public IEnumerable <Type> Values => this.mTypes.Values;
    public int                Count  => this.mTypes.Count;

    public IEnumerator <KeyValuePair <int, Type>> GetEnumerator ()
    {
        return this.mTypes.GetEnumerator ();
    }

    IEnumerator IEnumerable.GetEnumerator ()
    {
        return this.GetEnumerator ();
    }
}