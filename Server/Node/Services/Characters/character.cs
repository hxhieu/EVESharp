/*
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
using System.Text.RegularExpressions;
using Common.Logging;
using Common.Services;
using Node.Data;
using Node.Database;
using Node.Exceptions.character;
using Node.Inventory;
using Node.Inventory.Items;
using Node.Inventory.Items.Types;
using Node.Network;
using Node.Notifications.Chat;
using PythonTypes.Types.Collections;
using PythonTypes.Types.Database;
using PythonTypes.Types.Exceptions;
using PythonTypes.Types.Primitives;

namespace Node.Services.Characters
{
    public class character : IService
    {
        enum NameValidationResults
        {
            Valid = 1,
            TooShort = -1,
            TooLong = -2,
            IllegalCharacters = -5,
            MoreThanOneSpace = -6,
            Taken = -101,
            Banned = -102
        };

        private CharacterDB DB { get; }
        private ChatDB ChatDB { get; }
        private ItemManager ItemManager { get; }
        private TypeManager TypeManager { get; }
        private CacheStorage CacheStorage { get; }
        private NodeContainer Container { get; }
        private NotificationManager NotificationManager { get; }
        private readonly Dictionary<int, Bloodline> mBloodlineCache = null;
        private readonly Dictionary<int, Ancestry> mAncestriesCache = null;
        private readonly Configuration.Character mConfiguration = null;
        private readonly Channel Log = null;

        public character(CacheStorage cacheStorage, CharacterDB db, ChatDB chatDB, ItemManager itemManager, TypeManager typeManager, Logger logger, Configuration.Character configuration, NodeContainer container, NotificationManager notificationManager)
        {
            this.Log = logger.CreateLogChannel("character");
            this.mConfiguration = configuration;
            this.DB = db;
            this.ChatDB = chatDB;
            this.ItemManager = itemManager;
            this.TypeManager = typeManager;
            this.CacheStorage = cacheStorage;
            this.Container = container;
            this.NotificationManager = notificationManager;
            this.mBloodlineCache = this.DB.GetBloodlineInformation();
            this.mAncestriesCache = this.DB.GetAncestryInformation(this.mBloodlineCache);
        }

        public PyDataType GetCharactersToSelect(CallInformation call)
        {
            return this.DB.GetCharacterList(call.Client.AccountID);
        }

        public PyDataType LogStartOfCharacterCreation(CallInformation call)
        {
            return null;
        }

        public PyDataType GetCharCreationInfo(CallInformation call)
        {
            return this.CacheStorage.GetHints(CacheStorage.CreateCharacterCacheTable);
        }

        public PyDataType GetAppearanceInfo(CallInformation call)
        {
            return this.CacheStorage.GetHints(CacheStorage.CharacterAppearanceCacheTable);
        }

        public PyDataType GetCharNewExtraCreationInfo(CallInformation call)
        {
            return new PyDictionary();
        }

        public PyInteger ValidateNameEx(PyString name, CallInformation call)
        {
            string characterName = name;
            
            if (characterName.Length < 3)
                return (int) NameValidationResults.TooShort;

            // character name length is maximum 24 characters based on the error messages used for the user
            if (characterName.Length > 24)
                return (int) NameValidationResults.TooLong;

            // ensure only alphanumeric characters and/or spaces are used
            if (Regex.IsMatch(characterName, "^[a-zA-Z0-9 ]*$") == false)
                return (int) NameValidationResults.IllegalCharacters;

            // no more than one space allowed
            if (characterName.IndexOf(' ') != characterName.LastIndexOf(' '))
                return (int) NameValidationResults.MoreThanOneSpace;

            // ensure there is no character registered with this name already
            if (this.DB.IsCharacterNameTaken(characterName) == true)
                return (int) NameValidationResults.Taken;

            // TODO: IMPLEMENT BANLIST OF WORDS
            return (int) NameValidationResults.Valid;
        }

        private void GetRandomCareerForRace(int raceID, out int careerID, out int schoolID, out int careerSpecialityID,
            out int corporationID)
        {
            // TODO: DETERMINE SCHOOLID, CARREERID AND CAREERSPECIALITYID PROPERLY
            
            bool found = this.DB.GetRandomCareerForRace(raceID, out careerID, out schoolID,
                out careerSpecialityID, out corporationID);

            if (found == true)
                return;
            
            Log.Error($"Cannot find random career for race {raceID}");
                
            throw new CustomError($"Cannot find random career for race {raceID}");
        }

        private void GetLocationForCorporation(int corporationID, out int stationID, out int solarSystemID,
            out int constellationID, out int regionID)
        {
            // fetch information of starting location for the player
            bool found = this.DB.GetLocationForCorporation(corporationID, out stationID, out solarSystemID,
                out constellationID, out regionID);

            if (found == true)
                return;
            
            Log.Error($"Cannot find location for corporation {corporationID}");
                
            throw new CustomError($"Cannot find location for corporation {corporationID}");
        }

        private void ExtractExtraCharacterAppearance(PyDictionary data, out PyInteger accessoryID,
            out PyInteger beardID, out PyInteger decoID, out PyInteger lipstickID, out PyInteger makeupID,
            out PyDecimal morph1e, out PyDecimal morph1n, out PyDecimal morph1s, out PyDecimal morph1w,
            out PyDecimal morph2e, out PyDecimal morph2n, out PyDecimal morph2s, out PyDecimal morph2w,
            out PyDecimal morph3e, out PyDecimal morph3n, out PyDecimal morph3s, out PyDecimal morph3w,
            out PyDecimal morph4e, out PyDecimal morph4n, out PyDecimal morph4s, out PyDecimal morph4w)
        {
            data.TryGetValue("accessoryID", out accessoryID);
            data.TryGetValue("beardID", out beardID);
            data.TryGetValue("decoID", out decoID);
            data.TryGetValue("lipstickID", out lipstickID);
            data.TryGetValue("makeupID", out makeupID);
            data.TryGetValue("morph1e", out morph1e);
            data.TryGetValue("morph1n", out morph1n);
            data.TryGetValue("morph1s", out morph1s);
            data.TryGetValue("morph1w", out morph1w);
            data.TryGetValue("morph2e", out morph2e);
            data.TryGetValue("morph2n", out morph2n);
            data.TryGetValue("morph2s", out morph2s);
            data.TryGetValue("morph2w", out morph2w);
            data.TryGetValue("morph3e", out morph3e);
            data.TryGetValue("morph3n", out morph3n);
            data.TryGetValue("morph3s", out morph3s);
            data.TryGetValue("morph3w", out morph3w);
            data.TryGetValue("morph4e", out morph4e);
            data.TryGetValue("morph4n", out morph4n);
            data.TryGetValue("morph4s", out morph4s);
            data.TryGetValue("morph4w", out morph4w);
        }

        private void ExtractCharacterAppearance(PyDictionary data, out PyInteger costumeID, out PyInteger eyebrowsID,
            out PyInteger eyesID, out PyInteger hairID, out PyInteger skinID, out PyInteger backgroundID,
            out PyInteger lightID, out PyDecimal headRotation1, out PyDecimal headRotation2,
            out PyDecimal headRotation3, out PyDecimal eyeRotation1, out PyDecimal eyeRotation2,
            out PyDecimal eyeRotation3, out PyDecimal camPos1, out PyDecimal camPos2, out PyDecimal camPos3)
        {
            if (data.TryGetValue("costumeID", out costumeID) == false)
                throw new Exception("Cannot get costumeID from character appearance");
            if (data.TryGetValue("eyebrowsID", out eyebrowsID) == false)
                throw new Exception("Cannot get eyebrowsID from character appearance");
            if (data.TryGetValue("eyesID", out eyesID) == false)
                throw new Exception("Cannot get eyesID from character appearance");
            if (data.TryGetValue("hairID", out hairID) == false)
                throw new Exception("Cannot get hairID from character appearance");
            if (data.TryGetValue("skinID", out skinID) == false)
                throw new Exception("Cannot get skinID from character appearance");
            if (data.TryGetValue("backgroundID", out backgroundID) == false)
                throw new Exception("Cannot get backgroundID from character appearance");
            if (data.TryGetValue("lightID", out lightID) == false)
                throw new Exception("Cannot get lightID from character appearance");
            if (data.TryGetValue("headRotation1", out headRotation1) == false)
                throw new Exception("Cannot get headRotation1 from character appearance");
            if (data.TryGetValue("headRotation2", out headRotation2) == false)
                throw new Exception("Cannot get headRotation2 from character appearance");
            if (data.TryGetValue("headRotation3", out headRotation3) == false)
                throw new Exception("Cannot get headRotation3 from character appearance");
            if (data.TryGetValue("eyeRotation1", out eyeRotation1) == false)
                throw new Exception("Cannot get eyeRotation1 from character appearance");
            if (data.TryGetValue("eyeRotation2", out eyeRotation2) == false)
                throw new Exception("Cannot get eyeRotation2 from character appearance");
            if (data.TryGetValue("eyeRotation3", out eyeRotation3) == false)
                throw new Exception("Cannot get eyeRotation3 from character appearance");
            if (data.TryGetValue("camPos1", out camPos1) == false)
                throw new Exception("Cannot get camPos1 from character appearance");
            if (data.TryGetValue("camPos2", out camPos2) == false)
                throw new Exception("Cannot get camPos2 from character appearance");
            if (data.TryGetValue("camPos3", out camPos3) == false)
                throw new Exception("Cannot get camPos3 from character appearance");
        }
        
        private Character CreateCharacter(string characterName, Ancestry ancestry, int genderID, PyDictionary appearance, long currentTime, CallInformation call)
        {
            // load the item into memory
            ItemEntity owner = this.ItemManager.LocationSystem;
            
            this.GetRandomCareerForRace(ancestry.Bloodline.RaceID, out int careerID, out int schoolID, out int careerSpecialityID, out int corporationID);
            this.GetLocationForCorporation(corporationID, out int stationID, out int solarSystemID, out int constellationID, out int regionID);
            this.ExtractCharacterAppearance(appearance, out PyInteger costumeID, out PyInteger eyebrowsID,
                out PyInteger eyesID, out PyInteger hairID, out PyInteger skinID, out PyInteger backgroundID,
                out PyInteger lightID, out PyDecimal headRotation1, out PyDecimal headRotation2,
                out PyDecimal headRotation3, out PyDecimal eyeRotation1, out PyDecimal eyeRotation2,
                out PyDecimal eyeRotation3, out PyDecimal camPos1, out PyDecimal camPos2, out PyDecimal camPos3
            );
            this.ExtractExtraCharacterAppearance(appearance, out PyInteger accessoryID, out PyInteger beardID,
                out PyInteger decoID, out PyInteger lipstickID, out PyInteger makeupID, out PyDecimal morph1e,
                out PyDecimal morph1n, out PyDecimal morph1s, out PyDecimal morph1w, out PyDecimal morph2e,
                out PyDecimal morph2n, out PyDecimal morph2s, out PyDecimal morph2w, out PyDecimal morph3e,
                out PyDecimal morph3n, out PyDecimal morph3s, out PyDecimal morph3w, out PyDecimal morph4e,
                out PyDecimal morph4n, out PyDecimal morph4s, out PyDecimal morph4w
            );
            
            int itemID = this.DB.CreateCharacter(
                ancestry.Bloodline.ItemType, characterName, owner, call.Client.AccountID, this.mConfiguration.Balance,
                0.0, corporationID, 0, 0, 0, 0, 0,
                currentTime, currentTime, currentTime, ancestry.ID,
                careerID, schoolID, careerSpecialityID, genderID,
                accessoryID, beardID, costumeID, decoID, eyebrowsID, eyesID, hairID, lipstickID,
                makeupID, skinID, backgroundID, lightID, headRotation1, headRotation2, headRotation3,
                eyeRotation1, eyeRotation2, eyeRotation3, camPos1, camPos2, camPos3,
                morph1e, morph1n, morph1s, morph1w, morph2e, morph2n, morph2s, morph2w,
                morph3e, morph3n, morph3s, morph3w, morph4e, morph4n, morph4s, morph4w,
                stationID, solarSystemID, constellationID, regionID
            );

            return this.ItemManager.LoadItem(itemID) as Character;
        }

        public PyDataType CreateCharacter2(
            PyString characterName, PyInteger bloodlineID, PyInteger genderID, PyInteger ancestryID,
            PyDictionary appearance, CallInformation call)
        {
            int validationError = this.ValidateNameEx(characterName, call);

            // ensure the name is valid
            switch (validationError)
            {
                case (int) NameValidationResults.TooLong: throw new CharNameInvalidMaxLength ();
                case (int) NameValidationResults.Taken: throw new CharNameInvalidTaken ();
                case (int) NameValidationResults.IllegalCharacters: throw new CharNameInvalidSomeChar ();
                case (int) NameValidationResults.TooShort: throw new CharNameInvalidMinLength ();
                case (int) NameValidationResults.MoreThanOneSpace: throw new CharNameInvalidMaxSpaces ();
                case (int) NameValidationResults.Banned: throw new CharNameInvalidBannedWord ();
                case (int) NameValidationResults.Valid: break;
                // unknown actual error, return generic error
                default: throw new CharNameInvalid();
            }
            
            // load bloodline and ancestry info for the requested character
            Bloodline bloodline = this.mBloodlineCache[bloodlineID];
            Ancestry ancestry = this.mAncestriesCache[ancestryID];
            long currentTime = DateTime.UtcNow.ToFileTimeUtc();

            if (ancestry.Bloodline != bloodline)
            {
                Log.Error($"The ancestry {ancestryID} doesn't belong to the given bloodline {bloodlineID}");

                throw new BannedBloodline(ancestry, bloodline);
            }

            Character character =
                this.CreateCharacter(characterName, ancestry, genderID, appearance, currentTime, call);
            Station station = this.ItemManager.GetStaticStation(character.StationID);

            // TODO: CREATE DEFAULT STANDINGS FOR THE CHARACTER
            // change character attributes based on the picked ancestry
            character.Charisma = bloodline.Charisma + ancestry.Charisma;
            character.Intelligence = bloodline.Intelligence + ancestry.Intelligence;
            character.Memory = bloodline.Memory + ancestry.Memory;
            character.Willpower = bloodline.Willpower + ancestry.Willpower;
            character.Perception = bloodline.Perception + ancestry.Perception;
            
            // get skills by race and create them
            Dictionary<int, int> skills = this.DB.GetBasicSkillsByRace(bloodline.RaceID);

            foreach ((int skillTypeID, int level) in skills)
            {
                ItemType skillType = this.TypeManager[skillTypeID];
                    
                // create the skill at the required level
                this.ItemManager.CreateSkill(skillType, character, level);
            }
            
            // create the ship for the character
            Ship ship = this.ItemManager.CreateShip(bloodline.ShipType, station,
                character);
            
            // add one unit of Tritanium to the station's hangar for the player
            ItemType tritaniumType = this.TypeManager[ItemTypes.Tritanium];

            ItemEntity tritanium =
                this.ItemManager.CreateSimpleItem(tritaniumType, character,
                    station, ItemFlags.Hangar);
            
            // add one unit of Damage Control I to the station's hangar for the player
            ItemType damageControlType = this.TypeManager[ItemTypes.DamageControlI];

            ItemEntity damageControl =
                this.ItemManager.CreateSimpleItem(damageControlType, character,
                    station, ItemFlags.Hangar);
            
            // create an alpha clone
            ItemType cloneType = this.TypeManager[ItemTypes.CloneGradeAlpha];
            
            Clone clone = this.ItemManager.CreateClone(cloneType, station, character);

            character.LocationID = ship.ID;
            character.ActiveClone = clone;
            
            // character is 100% created and the base items are too
            // persist objects to database and unload them as they do not really belong to us
            clone.Persist();
            damageControl.Persist();
            tritanium.Persist();
            ship.Persist();
            character.Persist();
            
            // join the character to all the general channels
            this.ChatDB.GrantAccessToStandardChannels(character.ID);
            // create required mailing list channel
            this.ChatDB.CreateChannel(character, character, characterName, true);
            // and subscribe the character to some channels
            this.ChatDB.JoinEntityMailingList(character.ID, character.ID);
            this.ChatDB.JoinEntityChannel(character.SolarSystemID, character.ID);
            this.ChatDB.JoinEntityChannel(character.ConstellationID, character.ID);
            this.ChatDB.JoinEntityChannel(character.RegionID, character.ID);
            this.ChatDB.JoinEntityChannel(character.CorporationID, character.ID);
            this.ChatDB.JoinEntityMailingList(character.CorporationID, character.ID);
            
            // unload items from list
            this.ItemManager.UnloadItem(clone);
            this.ItemManager.UnloadItem(damageControl);
            this.ItemManager.UnloadItem(tritanium);
            this.ItemManager.UnloadItem(ship);
            this.ItemManager.UnloadItem(character);
            
            // finally return the new character's ID and wait for the subsequent calls from the EVE client :)
            return character.ID;
        }

        public PyDataType GetCharacterToSelect(PyInteger characterID, CallInformation call)
        {
            return this.DB.GetCharacterSelectionInfo(characterID, call.Client.AccountID);
        }

        public PyDataType SelectCharacterID(PyInteger characterID, PyBool loadDungeon, PyDataType secondChoiceID,
            CallInformation call)
        {
            return this.SelectCharacterID(characterID, loadDungeon == true ? 1 : 0, secondChoiceID, call);
        }
        
        // TODO: THIS PyNone SHOULD REALLY BE AN INTEGER, ALTHOUGH THIS FUNCTIONALITY IS NOT USED
        // TODO: IT REVEALS AN IMPORTANT ISSUE, WE CAN'T HAVE A WILDCARD PARAMETER PyDataType
        public PyDataType SelectCharacterID(PyInteger characterID, PyInteger loadDungeon, PyDataType secondChoiceID,
            CallInformation call)
        {
            // ensure the character belongs to the current account
            Character character = this.ItemManager.LoadItem<Character>(characterID);

            if (character.AccountID != call.Client.AccountID)
            {
                // unload character
                this.ItemManager.UnloadItem(character);
                
                // throw proper error
                throw new CustomError("The selected character does not belong to this account, aborting...");                
            }

            // update the session data for this client
            call.Client.CharacterID = character.ID;
            call.Client.CorporationID = character.CorporationID;

            if (character.StationID == 0)
            {
                call.Client.SolarSystemID = character.SolarSystemID;
            }
            else
            {
                call.Client.StationID = character.StationID;
            }

            call.Client.SolarSystemID2 = character.SolarSystemID;
            call.Client.ConstellationID = character.ConstellationID;
            call.Client.RegionID = character.RegionID;
            call.Client.HQID = 0;
            call.Client.CorporationRole = character.CorpRole;
            call.Client.RolesAtAll = character.RolesAtAll;
            call.Client.RolesAtBase = character.RolesAtBase;
            call.Client.RolesAtHQ = character.RolesAtHq;
            call.Client.RolesAtOther = character.RolesAtOther;
            call.Client.ShipID = character.LocationID;
            call.Client.RaceID = this.mAncestriesCache[character.AncestryID].Bloodline.RaceID;

            // update the character and set it's only flag to true
            character.Online = 1;
            // the online status must be persisted after update, so force the entity to be updated in the database
            character.Persist();
            
            // unload the character, let the session change handler handle everything
            // TODO: CHECK IF THE PLAYER IS GOING TO SPAWN IN THIS NODE AND IF IT IS NOT, UNLOAD IT FROM THE ITEM MANAGER
            PyList<PyInteger> onlineFriends = this.DB.GetOnlineFriendList(character);

            this.NotificationManager.NotifyCharacters(
                onlineFriends, new OnContactLoggedOn(character.ID)
            );
            
            // unload the character
            this.ItemManager.UnloadItem(characterID);
            
            // finally send the session change
            call.Client.SendSessionChange();
            
            return null;
        }

        public PyDataType Ping(CallInformation call)
        {
            return call.Client.AccountID;
        }

        public PyDataType GetOwnerNoteLabels(CallInformation call)
        {
            Character character = this.ItemManager.GetItem<Character>(call.Client.EnsureCharacterIsSelected());

            return this.DB.GetOwnerNoteLabels(character);
        }

        public PyDataType GetCloneTypeID(CallInformation call)
        {
            Character character = this.ItemManager.GetItem<Character>(call.Client.EnsureCharacterIsSelected());

            if (character.ActiveCloneID is null)
                throw new CustomError("You do not have any medical clone...");

            return character.ActiveClone.Type.ID;
        }

        public PyDataType GetHomeStation(CallInformation call)
        {
            Character character = this.ItemManager.GetItem<Character>(call.Client.EnsureCharacterIsSelected());

            if (character.ActiveCloneID is null)
                throw new CustomError("You do not have any medical clone...");

            return character.ActiveClone.LocationID;
        }

        public PyDataType GetCharacterDescription(PyInteger characterID, CallInformation call)
        {
            Character character = this.ItemManager.GetItem<Character>(call.Client.EnsureCharacterIsSelected());
            
            return character.Description;
        }

        public PyDataType SetCharacterDescription(PyString newBio, CallInformation call)
        {
            Character character = this.ItemManager.GetItem<Character>(call.Client.EnsureCharacterIsSelected());

            character.Description = newBio;
            character.Persist();
            
            return null;
        }

        public PyDataType GetRecentShipKillsAndLosses(PyInteger count, PyInteger startIndex, CallInformation call)
        {
            // limit number of records to 100 at maximum
            if (count > 100)
                count = 100;
            
            return this.DB.GetRecentShipKillsAndLosses(call.Client.EnsureCharacterIsSelected(), count, startIndex);
        }

        public PyDataType GetCharacterAppearanceList(PyList ids, CallInformation call)
        {
            PyList result = new PyList(ids.Count);

            int index = 0;
            
            foreach (PyInteger id in ids.GetEnumerable<PyInteger>())
            {
                Rowset dbResult = this.DB.GetCharacterAppearanceInfo(id);

                if (dbResult.Rows.Count != 0)
                    result[index] = dbResult;

                index++;
            }

            return result;
        }

        public PyDataType GetNote(PyInteger characterID, CallInformation call)
        {
            return this.DB.GetNote(characterID, call.Client.EnsureCharacterIsSelected());
        }

        public PyDataType SetNote(PyInteger characterID, PyString note, CallInformation call)
        {
            this.DB.SetNote(characterID, call.Client.EnsureCharacterIsSelected(), note);

            return null;
        }
    }
}