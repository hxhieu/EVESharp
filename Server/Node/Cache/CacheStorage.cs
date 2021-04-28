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

using System;
using System.Collections.Generic;
using Common.Database;
using Common.Logging;
using EVE.Packets.Complex;
using MySql.Data.MySqlClient;
using Node.Inventory;
using Node.Inventory.Items;
using Node.StaticData.Inventory;
using PythonTypes.Marshal;
using PythonTypes.Types.Collections;
using PythonTypes.Types.Database;
using PythonTypes.Types.Primitives;

namespace Node
{
    /// <summary>
    /// Manages cache entries generated by the server for the EVE client
    /// </summary>
    public class CacheStorage : DatabaseAccessor
    {
        /// <summary>
        /// Different types of cache objects, used on the Load mechanism that allow you to specify a SQL query
        /// Simplifies the flow of fetching and storing the data
        /// </summary>
        public enum CacheObjectType
        {
            TupleSet = 0,
            Rowset = 1,
            CRowset = 2,
            PackedRowList = 3,
            IntIntDict = 4,
            IndexRowset = 5
        }

        /// <summary>
        /// BulkData fetched by the EVE client on login
        /// </summary>
        public static readonly Dictionary<string, string> LoginCacheTable = new Dictionary<string, string>()
        {
            {"config.BulkData.ramactivities", "config.BulkData.ramactivities"},
            {"config.BulkData.billtypes", "config.BulkData.billtypes"},
            {"config.Bloodlines", "config.Bloodlines"},
            {"config.Units", "config.Units"},
            {"config.BulkData.tickernames", "config.BulkData.tickernames"},
            {"config.BulkData.ramtyperequirements", "config.BulkData.ramtyperequirements"},
            {"config.BulkData.ramaltypesdetailpergroup", "config.BulkData.ramaltypesdetailpergroup"},
            {"config.BulkData.ramaltypes", "config.BulkData.ramaltypes"},
            {"config.BulkData.allianceshortnames", "config.BulkData.allianceshortnames"},
            {"config.BulkData.ramcompletedstatuses", "config.BulkData.ramcompletedstatuses"},
            {"config.BulkData.categories", "config.BulkData.categories"},
            {"config.BulkData.invtypereactions", "config.BulkData.invtypereactions"},
            {"config.BulkData.dgmtypeeffects", "config.BulkData.dgmtypeeffects"},
            {"config.BulkData.metagroups", "config.BulkData.metagroups"},
            {"config.BulkData.ramtypematerials", "config.BulkData.ramtypematerials"},
            {"config.BulkData.ramaltypesdetailpercategory", "config.BulkData.ramaltypesdetailpercategory"},
            {"config.BulkData.owners", "config.BulkData.owners"},
            {"config.StaticOwners", "config.StaticOwners"},
            {"config.Races", "config.Races"},
            {"config.Attributes", "config.Attributes"},
            {"config.BulkData.dgmtypeattribs", "config.BulkData.dgmtypeattribs"},
            {"config.BulkData.locations", "config.BulkData.locations"},
            {"config.BulkData.locationwormholeclasses", "config.BulkData.locationwormholeclasses"},
            {"config.BulkData.groups", "config.BulkData.groups"},
            {"config.BulkData.shiptypes", "config.BulkData.shiptypes"},
            {"config.BulkData.dgmattribs", "config.BulkData.dgmattribs"},
            {"config.Flags", "config.Flags"},
            {"config.BulkData.bptypes", "config.BulkData.bptypes"},
            {"config.BulkData.graphics", "config.BulkData.graphics"},
            {"config.BulkData.mapcelestialdescriptions", "config.BulkData.mapcelestialdescriptions"},
            {"config.BulkData.certificates", "config.BulkData.certificates"},
            {"config.StaticLocations", "config.StaticLocations"},
            {"config.InvContrabandTypes", "config.InvContrabandTypes"},
            {"config.BulkData.certificaterelationships", "config.BulkData.certificaterelationships"},
            {"config.BulkData.units", "config.BulkData.units"},
            {"config.BulkData.dgmeffects", "config.BulkData.dgmeffects"},
            {"config.BulkData.types", "config.BulkData.types"},
            {"config.BulkData.invmetatypes", "config.BulkData.invmetatypes"},
        };

        /// <summary>
        /// Queries to populate the BulkData for the EVE Client on login
        /// </summary>
        public static readonly string[] LoginCacheQueries =
        {
            "SELECT activityID, activityName, iconNo, description, published FROM ramActivities",
            "SELECT billTypeID, billTypeName, description FROM billTypes",
            "SELECT bloodlineID, bloodlineName, raceID, description, maleDescription, femaleDescription, shipTypeID, corporationID, perception, willpower, charisma, memory, intelligence, graphicID, shortDescription, shortMaleDescription, shortFemaleDescription, dataID FROM chrBloodlines",
            "SELECT unitID, unitName, displayName FROM eveUnits",
            "SELECT corporationID, tickerName, shape1, shape2, shape3, color1, color2, color3 FROM corporation WHERE hasPlayerPersonnelManager = 0",
            "SELECT typeID, activityID, requiredTypeID, quantity, damagePerJob, recycle FROM typeActivityMaterials WHERE damagePerJob != 1.0 OR recycle = 1",
            "SELECT a.assemblyLineTypeID, b.activityID, a.groupID, a.timeMultiplier, a.materialMultiplier FROM ramAssemblyLineTypeDetailPerGroup AS a LEFT JOIN ramAssemblyLineTypes AS b ON a.assemblyLineTypeID = b.assemblyLineTypeID",
            "SELECT assemblyLineTypeID, assemblyLineTypeName, assemblyLineTypeName AS typeName, description, activityID, baseTimeMultiplier, baseMaterialMultiplier, volume FROM ramAssemblyLineTypes",
            "SELECT allianceID, shortName FROM alliance_shortnames",
            "SELECT completedStatusID, completedStatusName, completedStatusText FROM ramCompletedStatuses",
            "SELECT categoryID, categoryName, description, graphicID, published, 0 AS dataID FROM invCategories",
            "SELECT reactionTypeID, input, typeID, quantity FROM invTypeReactions",
            "SELECT typeID, effectID, isDefault FROM dgmTypeEffects",
            "SELECT metaGroupID, metaGroupName, description, graphicID, 0 AS dataID FROM invMetaGroups",
            "SELECT typeID, requiredTypeID AS materialTypeID, quantity FROM typeActivityMaterials WHERE activityID = 6 AND damagePerJob = 1.0 UNION SELECT productTypeID AS typeID, requiredTypeID AS materialTypeID, quantity FROM typeActivityMaterials JOIN invBlueprintTypes ON typeID = blueprintTypeID WHERE activityID = 1 AND damagePerJob = 1.0",
            "SELECT a.assemblyLineTypeID, b.activityID, a.categoryID, a.timeMultiplier, a.materialMultiplier FROM ramAssemblyLineTypeDetailPerCategory AS a LEFT JOIN ramAssemblyLineTypes AS b ON a.assemblyLineTypeID = b.assemblyLineTypeID",
            "SELECT itemID AS ownerID, itemName AS ownerName, typeID FROM eveNames WHERE itemID = 0",
            $"SELECT itemID AS ownerID, itemName AS ownerName, typeID FROM eveNames WHERE categoryID = 1 AND itemID < {ItemFactory.USERGENERATED_ID_MIN}",
            "SELECT raceID, raceName, description, graphicID, shortDescription, 0 AS dataID FROM chrRaces",
            "SELECT attributeID, attributeName, description, graphicID FROM chrAttributes",
            "SELECT	typeID, attributeID, IF(valueInt IS NULL, valueFloat, valueInt) AS value FROM dgmTypeAttributes",
            "SELECT locationID, locationName, x, y, z FROM cacheLocations",
            "SELECT locationID, wormholeClassID FROM mapLocationWormholeClasses",
            "SELECT groupID, categoryID, groupName, description, graphicID, useBasePrice, allowManufacture, allowRecycler, anchored, anchorable, fittableNonSingleton, 1 AS published, 0 AS dataID FROM invGroups",
            "SELECT shipTypeID,weaponTypeID,miningTypeID,skillTypeID FROM invShipTypes",
            "SELECT attributeID, attributeName, attributeCategory, description, maxAttributeID, attributeIdx, graphicID, chargeRechargeTimeID, defaultValue, published, displayName, unitID, stackable, highIsGood, categoryID, 0 AS dataID FROM dgmAttributeTypes",
            "SELECT flagID, flagName, flagText, flagType, orderID FROM invFlags",
            "SELECT invTypes.typeName AS blueprintTypeName, invTypes.description, invTypes.graphicID, invTypes.basePrice, blueprintTypeID, parentBlueprintTypeID, productTypeID, productionTime, techLevel, researchProductivityTime, researchMaterialTime, researchCopyTime, researchTechTime, productivityModifier, materialModifier, wasteFactor, chanceOfReverseEngineering, maxProductionLimit FROM invBlueprintTypes, invTypes WHERE invBlueprintTypes.blueprintTypeID = invTypes.typeID",
            #if DEBUG
            "SELECT graphicID, url3D, urlWeb, icon, urlSound, description, explosionID FROM eveGraphics", // include description on debug builds so the developers can search by description value
            #else
            "SELECT graphicID, url3D, urlWeb, icon, urlSound, explosionID FROM eveGraphics",
            #endif
            "SELECT celestialID, description FROM mapCelestialDescriptions",
            "SELECT certificateID, categoryID, classID, grade, iconID, corpID, description, 0 AS dataID FROM crtCertificates",
            $"SELECT itemID AS locationID, itemName as locationName, x, y, z FROM invItems LEFT JOIN eveNames USING (itemID) LEFT JOIN invPositions USING (itemID) WHERE (groupID = {(int) Groups.Station} OR groupID = {(int) Groups.Constellation} OR groupID = {(int) Groups.SolarSystem} OR groupID = {(int) Groups.Region}) AND itemID < {ItemFactory.USERGENERATED_ID_MIN}",
            "SELECT factionID, typeID, standingLoss, confiscateMinSec, fineByValue, attackMinSec FROM invContrabandTypes",
            "SELECT relationshipID, parentID, parentTypeID, parentLevel, childID, childTypeID FROM crtRelationships",
            "SELECT unitID,unitName,displayName FROM eveUnits",
            "SELECT effectID, effectName, effectCategory, preExpression, postExpression, description, guid, graphicID, isOffensive, isAssistance, durationAttributeID, trackingSpeedAttributeID, dischargeAttributeID, rangeAttributeID, falloffAttributeID, published, displayName, isWarpSafe, rangeChance, electronicChance, propulsionChance, distribution, sfxName, npcUsageChanceAttributeID, npcActivationChanceAttributeID, 0 AS fittingUsageChanceAttributeID, 0 AS dataID FROM dgmEffects",
            "SELECT typeID, groupID, typeName, description, graphicID, radius, mass, volume, capacity, portionSize, raceID, basePrice, published, marketGroupID, chanceOfDuplicating, dataID FROM invTypes",
            "SELECT typeID, parentTypeID, metaGroupID FROM invMetaTypes"
        };

        /// <summary>
        /// How the BulkData for the EVE Client should be stored
        /// </summary>
        public static readonly CacheObjectType[] LoginCacheTypes =
        {
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.TupleSet,
            CacheObjectType.Rowset,
            CacheObjectType.CRowset,
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.CRowset,
            CacheObjectType.Rowset,
            CacheObjectType.TupleSet,
            CacheObjectType.Rowset,
            CacheObjectType.CRowset,
            CacheObjectType.TupleSet,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.PackedRowList,
            CacheObjectType.TupleSet,
            CacheObjectType.CRowset,
            CacheObjectType.TupleSet,
            CacheObjectType.CRowset,
            CacheObjectType.TupleSet,
            CacheObjectType.Rowset,
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.CRowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.CRowset,
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.TupleSet,
            CacheObjectType.CRowset
        };

        /// <summary>
        /// Cache entries for the character creation information
        /// </summary>
        public static readonly Dictionary<string, string> CreateCharacterCacheTable = new Dictionary<string, string>()
        {
            {"charCreationInfo.bl_eyebrows", "eyebrows"},
            {"charCreationInfo.bl_eyes", "eyes"},
            {"charCreationInfo.bl_decos", "decos"},
            {"charCreationInfo.bloodlines", "bloodlines"},
            {"charCreationInfo.bl_hairs", "hairs"},
            {"charCreationInfo.bl_backgrounds", "backgrounds"},
            {"charCreationInfo.bl_accessories", "accessories"},
            {"charCreationInfo.bl_costumes", "costumes"},
            {"charCreationInfo.bl_lights", "lights"},
            {"charCreationInfo.races", "races"},
            {"charCreationInfo.ancestries", "ancestries"},
            {"charCreationInfo.schools", "schools"},
            {"charCreationInfo.attributes", "attributes"},
            {"charCreationInfo.bl_beards", "beards"},
            {"charCreationInfo.bl_skins", "skins"},
            {"charCreationInfo.bl_lipsticks", "lipsticks"},
            {"charCreationInfo.bl_makeups", "makeups"}
        };

        /// <summary>
        /// Queries to populate the character creation cache
        /// </summary>
        public static readonly string[] CreateCharacterCacheQueries = new string[]
        {
            "SELECT bloodlineID, gender, eyebrowsID, npc FROM chrBLEyebrows",
            "SELECT bloodlineID, gender, eyesID, npc FROM chrBLEyes",
            "SELECT bloodlineID, gender, decoID, npc FROM chrBLDecos",
            "SELECT bloodlineID, bloodlineName, raceID, description, maleDescription, femaleDescription, shipTypeID, corporationID, perception, willpower, charisma, memory, intelligence, graphicID, shortDescription, shortMaleDescription, shortFemaleDescription, 0 AS dataID FROM chrBloodlines",
            "SELECT bloodlineID, gender, hairID, npc FROM chrBLHairs",
            "SELECT backgroundID, backgroundName FROM chrBLBackgrounds",
            "SELECT bloodlineID, gender, accessoryID, npc FROM chrBLAccessories",
            "SELECT bloodlineID, gender, costumeID, npc FROM chrBLCostumes",
            "SELECT lightID, lightName FROM chrBLLights",
            "SELECT raceID, raceName, description, graphicID, shortDescription, 0 AS dataID FROM chrRaces",
            "SELECT ancestryID, ancestryName, bloodlineID, description, perception, willpower, charisma, memory, intelligence, graphicID, shortDescription, 0 AS dataID FROM chrAncestries",
            "SELECT raceID, schoolID, schoolName, description, graphicID, corporationID, agentID, newAgentID FROM chrSchools LEFT JOIN agtAgents USING (corporationID) GROUP BY schoolID",
            "SELECT attributeID, attributeName, description, graphicID FROM chrAttributes",
            "SELECT bloodlineID, gender, beardID, npc FROM chrBLBeards",
            "SELECT bloodlineID, gender, skinID, npc FROM chrBLSkins",
            "SELECT bloodlineID, gender, lipstickID, npc FROM chrBLLipsticks",
            "SELECT bloodlineID, gender, makeupID, npc FROM chrBLMakeups"
        };

        /// <summary>
        /// How the character creation caches will be stored
        /// </summary>
        public static readonly CacheObjectType[] CreateCharacterCacheTypes = new CacheObjectType[]
        {
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.CRowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.CRowset,
            CacheObjectType.CRowset,
            CacheObjectType.CRowset,
            CacheObjectType.CRowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset
        };

        public static readonly Dictionary<string, string> CharacterAppearanceCacheTable = new Dictionary<string, string>()
        {
            {"charCreationInfo.eyebrows", "eyebrows"},
            {"charCreationInfo.eyes", "eyes"},
            {"charCreationInfo.decos", "decos"},
            {"charCreationInfo.hairs", "hairs"},
            {"charCreationInfo.backgrounds", "backgrounds"},
            {"charCreationInfo.accessories", "accessories"},
            {"charCreationInfo.costumes", "costumes"},
            {"charCreationInfo.lights", "lights"},
            {"charCreationInfo.makeups", "makeups"},
            {"charCreationInfo.beards", "beards"},
            {"charCreationInfo.skins", "skins"},
            {"charCreationInfo.lipsticks", "lipsticks"}
        };

        public static readonly string[] CharacterAppearanceCacheQueries = new string[]
        {
            "SELECT eyebrowsID, eyebrowsName FROM chrEyebrows",
            "SELECT eyesID, eyesName FROM chrEyes",
            "SELECT decoID, decoName FROM chrDecos",
            "SELECT hairID, hairName FROM chrHairs",
            "SELECT backgroundID, backgroundName FROM chrBackgrounds",
            "SELECT accessoryID, accessoryName FROM chrAccessories",
            "SELECT costumeID, costumeName FROM chrCostumes",
            "SELECT lightID, lightName FROM chrLights",
            "SELECT makeupID, makeupName FROM chrMakeups",
            "SELECT beardID, beardName FROM chrBeards",
            "SELECT skinID, skinName FROM chrSkins",
            "SELECT lipstickID, lipstickName FROM chrLipsticks"
        };

        public static readonly CacheObjectType[] CharacterAppearanceCacheTypes = new CacheObjectType[]
        {
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset,
            CacheObjectType.Rowset
        };

        /// <summary>
        /// Main storage of cache data for ease of querying
        /// </summary>
        private readonly Dictionary<string, PyDataType> mCacheData = new Dictionary<string, PyDataType>();
        /// <summary>
        /// Hints for the EVE Client so it knows when to request cache data or use the one already stored
        /// </summary>
        private readonly PyDictionary mCacheHints = new PyDictionary();
        
        private NodeContainer Container { get; }
        private Channel Log { get; }

        /// <summary>
        /// Checks if a cached object already exists
        /// </summary>
        /// <param name="name">The object to look for</param>
        public bool Exists(string name)
        {
            return this.mCacheData.ContainsKey(name);
        }

        /// <summary>
        /// Checks if a cached object for the given <paramref name="service"/> and <paramref name="method" /> already exists
        /// </summary>
        /// <param name="service">The service that generates the cache</param>
        /// <param name="method">The method that generates the cache</param>
        public bool Exists(string service, string method)
        {
            return this.mCacheData.ContainsKey($"{service}::{method}");
        }

        /// <summary>
        /// Generates an object identifier for the given <paramref name="service"/> and <paramref name="method" /> so the EVE Client
        /// knows how to request it from the server
        /// </summary>
        /// <param name="service">The service that generates the cache</param>
        /// <param name="method">The method that generates the cache</param>
        /// <returns>A Python type representing the cache identifier</returns>
        private PyDataType GenerateObjectIDForCall(string service, string method)
        {
            return new PyTuple(3)
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
        public PyDataType Get(string name)
        {
            return this.mCacheData[name];
        }

        /// <summary>
        /// Gets the specified cached content if it exists. The content is ready to be sent to the EVE Client 
        /// </summary>
        /// <param name="service">The service that generated the cached content</param>
        /// <param name="method">The method that generated the cached content</param>
        public PyDataType Get(string service, string method)
        {
            return this.mCacheData[$"{service}::{method}"];
        }

        /// <summary>
        /// Saves the given <paramref name="data"/> into the cache storage and identifies it by the given <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name to identify the cached data by</param>
        /// <param name="data">The data to cache</param>
        /// <param name="timestamp">The timestamp of when the cached object was created</param>
        public void Store(string name, PyDataType data, long timestamp)
        {
            byte[] marshalData = Marshal.ToByteArray(data);
            
            CachedHint hint = CachedHint.FromPyObject(name, marshalData, timestamp, this.Container.NodeID);

            // save cache hint
            this.mCacheHints[name] = hint;
            // save cache object
            this.mCacheData[name] = CachedObject.FromCacheHint(hint, marshalData);
        }

        /// <summary>
        /// Saves the given <paramref name="data"/> into the cache storage and identifies it by the <paramref name="service"/> and <paramref name="method"/> that generated it
        /// </summary>
        /// <param name="service">The service that generated the cached object</param>
        /// <param name="method">The method that generated the cached object</param>
        /// <param name="data">The data to cache</param>
        /// <param name="timestamp">The timestamp of when the cached object was generated</param>
        public void StoreCall(string service, string method, PyDataType data, long timestamp)
        {
            byte[] marshalData = Marshal.ToByteArray(data);
            
            string index = $"{service}::{method}";
            PyDataType objectID = this.GenerateObjectIDForCall(service, method);
            CachedHint hint = CachedHint.FromPyObject(objectID, marshalData, timestamp, this.Container.NodeID);
            
            // save cache hint
            this.mCacheHints[index] = hint;
            // save cache object
            this.mCacheData[index] = CachedObject.FromCacheHint(hint, marshalData);
        }

        /// <summary>
        /// Searches for a list of cache hints that hold information about the cached object
        /// </summary>
        /// <param name="list">The list of hints to look for, key is used as cached object name and value is used as name for the client</param>
        /// <returns>A dictionary ready for the EVE Client with the hints for the cached objects</returns>
        public PyDictionary<PyString, PyDataType> GetHints(Dictionary<string, string> list)
        {
            PyDictionary<PyString, PyDataType> hints = new PyDictionary<PyString, PyDataType>();

            foreach ((string key, string value) in list)
                hints[value] = this.GetHint(key);

            return hints;
        }

        /// <summary>
        /// Searches for a specific cached's object hint that holds information about the cached object
        /// </summary>
        /// <param name="name">The cached object to get the hint for</param>
        /// <returns>An object ready for the EVE Client with the hint information for the cached object</returns>
        public PyDataType GetHint(string name)
        {
            return this.mCacheHints[name];
        }

        /// <summary>
        /// Searches for a specific cached object's hint generated by the given <paramref name="service"/> and <paramref name="method"/>
        /// that holds information about the cached object
        /// </summary>
        /// <param name="service">The service that generated the cached object</param>
        /// <param name="method">The method that generated the cached object</param>
        /// <returns>An object ready for the EVE Client with the hing information for the cached object</returns>
        public PyDataType GetHint(string service, string method)
        {
            return this.mCacheHints[$"{service}::{method}"];
        }

        /// <summary>
        /// Helper method that queries the cached object and converts it to the proper type to be stored
        /// </summary>
        /// <param name="query">The query to run</param>
        /// <param name="type">The type of object to store</param>
        /// <returns>The final object to be used by the cache</returns>
        private PyDataType QueryCacheObject(string query, CacheObjectType type)
        {
            MySqlConnection connection = null;
            MySqlDataReader reader = Database.Query(ref connection, query);

            using(connection)
            using (reader)
            {
                return type switch
                {
                    CacheObjectType.Rowset => Rowset.FromMySqlDataReader(Database, reader),
                    CacheObjectType.CRowset => CRowset.FromMySqlDataReader(Database, reader),
                    CacheObjectType.TupleSet => TupleSet.FromMySqlDataReader(Database, reader),
                    CacheObjectType.PackedRowList => PyPackedRowList.FromMySqlDataReader(Database, reader),
                    CacheObjectType.IntIntDict => IntIntDictionary.FromMySqlDataReader(reader),
                    CacheObjectType.IndexRowset => IndexRowset.FromMySqlDataReader(Database, reader, 0),
                    _ => null
                };
            }
        }

        /// <summary>
        /// Runs the given <paramref name="query"/> and stores the result as a cached object identified by <paramref name="name"/>
        /// </summary>
        /// <param name="name">The name of the cached object</param>
        /// <param name="query">The SQL query to run</param>
        /// <param name="type">How the result will be stored inside the cache</param>
        public void Load(string name, string query, CacheObjectType type)
        {
            Log.Debug($"Loading cache data for {name} of type {type}");

            // if the cache already exists do not generate it again!
            if (this.Exists(name) == true)
                return;

            try
            {
                Store(name, this.QueryCacheObject(query, type), DateTime.UtcNow.ToFileTimeUtc());
            }
            catch (Exception)
            {
                Log.Error($"Cannot generate cache data for {name}");
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
        public void Load(string service, string method, string query, CacheObjectType type)
        {
            Log.Debug($"Loading cache data for {service}::{method} of type {type}");

            // if the cache already exists do not generate it again!
            if (this.Exists(service, method) == true)
                return;
            
            try
            {
                StoreCall(service, method, this.QueryCacheObject(query, type), DateTime.UtcNow.ToFileTimeUtc());
            }
            catch (Exception)
            {
                Log.Error($"Cannot generate cache data for {service}::{method}");
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
        public void Load(Dictionary<string, string> names, string[] queries, CacheObjectType[] types)
        {
            if (names.Count != queries.Length || names.Count != types.Length)
                throw new ArgumentOutOfRangeException("names", "names, queries and types do not match in size");

            int i = 0;

            foreach ((string key, string _) in names)
            {
                Load(key, queries[i], types[i]);
                i++;
            }
        }

        public CacheStorage(NodeContainer container, DatabaseConnection db, Logger logger) : base(db)
        {
            this.Log = logger.CreateLogChannel("CacheStorage");
            this.Container = container;
        }
    }
}