﻿/*
    ------------------------------------------------------------------------------------
    LICENSE:
    ------------------------------------------------------------------------------------
    This file is part of EVE#: The EVE Online Server Emulator
    Copyright 2022 - EVE# Team
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using EVESharp.Database;
using EVESharp.EVE.Database;
using EVESharp.EVE.Network;
using EVESharp.EVE.Network.Caching;
using EVESharp.EVE.Packets.Complex;
using EVESharp.Types;
using EVESharp.Types.Collections;
using EVESharp.Types.Serialization;
using Serilog;

namespace EVESharp.Node.Cache;

/// <summary>
/// Manages cache entries generated by the server for the EVE client
/// </summary>
public class CacheStorage : DatabaseAccessor, ICacheStorage
{
    /// <summary>
    /// Main storage of cache data for ease of querying
    /// </summary>
    private readonly Dictionary <string, PyDataType> mCacheData = new Dictionary <string, PyDataType> ();
    /// <summary>
    /// Hints for the EVE Client so it knows when to request cache data or use the one already stored
    /// </summary>
    private readonly Dictionary <string, PyDataType> mCacheHints = new Dictionary <string, PyDataType> ();

    private IMachoNet MachoNet { get; }
    private ILogger   Log      { get; }

    public CacheStorage (IMachoNet machoNet, IDatabaseConnection db, ILogger logger) : base (db)
    {
        Log      = logger;
        MachoNet = machoNet;
    }

    /// <summary>
    /// Checks if a cached object already exists
    /// </summary>
    /// <param name="name">The object to look for</param>
    public bool Exists (string name)
    {
        return this.mCacheData.ContainsKey (name);
    }

    /// <summary>
    /// Checks if a cached object for the given <paramref name="service"/> and <paramref name="method" /> already exists
    /// </summary>
    /// <param name="service">The service that generates the cache</param>
    /// <param name="method">The method that generates the cache</param>
    public bool Exists (string service, string method)
    {
        return this.mCacheData.ContainsKey ($"{service}::{method}");
    }

    /// <summary>
    /// Generates an object identifier for the given <paramref name="service"/> and <paramref name="method" /> so the EVE Client
    /// knows how to request it from the server
    /// </summary>
    /// <param name="service">The service that generates the cache</param>
    /// <param name="method">The method that generates the cache</param>
    /// <returns>A Python type representing the cache identifier</returns>
    private PyDataType GenerateObjectIDForCall (string service, string method)
    {
        return new PyTuple (3)
        {
            [0] = "Method Call",
            [1] = "server",
            [2] = new PyTuple (2)
            {
                [0] = service,
                [1] = method
            }
        };
    }

    /// <summary>
    /// Gets the specified cached content if it exists. This content is ready to be sent to the EVE Client
    /// </summary>
    /// <param name="name">The cached content to look for</param>
    public PyDataType Get (string name)
    {
        return this.mCacheData [name];
    }

    /// <summary>
    /// Gets the specified cached content if it exists. The content is ready to be sent to the EVE Client 
    /// </summary>
    /// <param name="service">The service that generated the cached content</param>
    /// <param name="method">The method that generated the cached content</param>
    public PyDataType Get (string service, string method)
    {
        return this.mCacheData [$"{service}::{method}"];
    }

    /// <summary>
    /// Saves the given <paramref name="data"/> into the cache storage and identifies it by the given <paramref name="name"/>
    /// </summary>
    /// <param name="name">The name to identify the cached data by</param>
    /// <param name="data">The data to cache</param>
    /// <param name="timestamp">The timestamp of when the cached object was created</param>
    public void Store (string name, PyDataType data, long timestamp)
    {
        byte [] marshalData = Marshal.ToByteArray (data);

        CachedHint hint = CachedHint.FromPyObject (name, marshalData, timestamp, MachoNet.NodeID);

        // save cache hint
        this.mCacheHints [name] = hint;
        // save cache object
        this.mCacheData [name] = CachedObject.FromCacheHint (hint, marshalData);
    }

    /// <summary>
    /// Saves the given <paramref name="data"/> into the cache storage and identifies it by the <paramref name="service"/> and <paramref name="method"/> that generated it
    /// </summary>
    /// <param name="service">The service that generated the cached object</param>
    /// <param name="method">The method that generated the cached object</param>
    /// <param name="data">The data to cache</param>
    /// <param name="timestamp">The timestamp of when the cached object was generated</param>
    public void StoreCall (string service, string method, PyDataType data, long timestamp)
    {
        byte [] marshalData = Marshal.ToByteArray (data);

        string     index    = $"{service}::{method}";
        PyDataType objectID = this.GenerateObjectIDForCall (service, method);
        CachedHint hint     = CachedHint.FromPyObject (objectID, marshalData, timestamp, MachoNet.NodeID);

        // save cache hint
        this.mCacheHints [index] = hint;
        // save cache object
        this.mCacheData [index] = CachedObject.FromCacheHint (hint, marshalData);
    }

    /// <summary>
    /// Searches for a list of cache hints that hold information about the cached object
    /// </summary>
    /// <param name="list">The list of hints to look for, key is used as cached object name and value is used as name for the client</param>
    /// <returns>A dictionary ready for the EVE Client with the hints for the cached objects</returns>
    public PyDictionary <PyString, PyDataType> GetHints (Dictionary <string, string> list)
    {
        PyDictionary <PyString, PyDataType> hints = new PyDictionary <PyString, PyDataType> ();

        foreach ((string key, string value) in list)
            hints [value] = this.GetHint (key);

        return hints;
    }

    /// <summary>
    /// Searches for a specific cached's object hint that holds information about the cached object
    /// </summary>
    /// <param name="name">The cached object to get the hint for</param>
    /// <returns>An object ready for the EVE Client with the hint information for the cached object</returns>
    public PyDataType GetHint (string name)
    {
        return this.mCacheHints [name];
    }

    /// <summary>
    /// Searches for a specific cached object's hint generated by the given <paramref name="service"/> and <paramref name="method"/>
    /// that holds information about the cached object
    /// </summary>
    /// <param name="service">The service that generated the cached object</param>
    /// <param name="method">The method that generated the cached object</param>
    /// <returns>An object ready for the EVE Client with the hing information for the cached object</returns>
    public PyDataType GetHint (string service, string method)
    {
        return this.mCacheHints [$"{service}::{method}"];
    }

    /// <summary>
    /// Helper method that queries the cached object and converts it to the proper type to be stored
    /// </summary>
    /// <param name="query">The query to run</param>
    /// <param name="type">The type of object to store</param>
    /// <returns>The final object to be used by the cache</returns>
    private PyDataType QueryCacheObject (string query, CacheObjectType type)
    {
        IDbConnection connection = null;
        DbDataReader  reader     = Database.Select (ref connection, query);

        using (connection)
        using (reader)
        {
            return type switch
            {
                CacheObjectType.Rowset        => reader.Rowset (),
                CacheObjectType.CRowset       => reader.CRowset (),
                CacheObjectType.TupleSet      => reader.TupleSet (),
                CacheObjectType.PackedRowList => reader.PackedRowList (),
                CacheObjectType.IntIntDict    => reader.IntIntDictionary (),
                CacheObjectType.IndexRowset   => reader.IndexRowset (0),
                _                             => null
            };
        }
    }

    /// <summary>
    /// Runs the given <paramref name="query"/> and stores the result as a cached object identified by <paramref name="name"/>
    /// </summary>
    /// <param name="name">The name of the cached object</param>
    /// <param name="query">The SQL query to run</param>
    /// <param name="type">How the result will be stored inside the cache</param>
    public void Load (string name, string query, CacheObjectType type)
    {
        Log.Debug ($"Loading cache data for {name} of type {type}");

        // if the cache already exists do not generate it again!
        if (this.Exists (name))
            return;

        try
        {
            this.Store (name, this.QueryCacheObject (query, type), DateTime.UtcNow.ToFileTimeUtc ());
        }
        catch (Exception)
        {
            Log.Error ($"Cannot generate cache data for {name}");

            throw;
        }
    }

    /// <summary>
    /// Runs the given <paramref name="query"/> and stores the result as a cached object identified by the <paramref name="service"/> and
    /// <paramref name="method"/> that generated it
    /// </summary>
    /// <param name="service">The service that generated the cached object</param>
    /// <param name="method">The method that generated the cached object</param>
    /// <param name="query">The SQL query to run</param>
    /// <param name="type">How the result will be stored inside the cache</param>
    public void Load (string service, string method, string query, CacheObjectType type)
    {
        Log.Debug ($"Loading cache data for {service}::{method} of type {type}");

        // if the cache already exists do not generate it again!
        if (this.Exists (service, method))
            return;

        try
        {
            this.StoreCall (service, method, this.QueryCacheObject (query, type), DateTime.UtcNow.ToFileTimeUtc ());
        }
        catch (Exception)
        {
            Log.Error ($"Cannot generate cache data for {service}::{method}");

            throw;
        }
    }

    /// <summary>
    /// Runs the given <paramref name="queries"/> and stores the result as a cached object identified by the <paramref name="names"/>
    ///
    /// The key of the dictionary is used as name. The values in queries and types should be in the order the names were added
    /// to the dictionary
    /// </summary>
    /// <param name="names">The list of names to store the cached objects as</param>
    /// <param name="queries">The queries to run</param>
    /// <param name="types">How to store each of the cached objects</param>
    /// <exception cref="ArgumentOutOfRangeException">The number of queries, names and types do not match</exception>
    public void Load (Dictionary <string, string> names, string [] queries, CacheObjectType [] types)
    {
        if (names.Count != queries.Length || names.Count != types.Length)
            throw new ArgumentOutOfRangeException (nameof (names), "names, queries and types do not match in size");

        int i = 0;

        foreach ((string key, string _) in names)
        {
            this.Load (key, queries [i], types [i]);
            i++;
        }
    }

    /// <summary>
    /// Removes the given cached data from the cache storage
    /// </summary>
    /// <param name="name"></param>
    public void Remove (string name)
    {
        this.mCacheData.Remove (name);
        this.mCacheHints.Remove (name);
    }

    /// <summary>
    /// Removes the given cached data for a service call from the cache storage
    /// </summary>
    /// <param name="service"></param>
    /// <param name="method"></param>
    public void Remove (string service, string method)
    {
        string name = $"{service}::{method}";

        this.Remove (name);
    }
}