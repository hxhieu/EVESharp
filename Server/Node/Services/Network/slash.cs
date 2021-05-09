﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Common.Constants;
using Common.Logging;
using Common.Services;
using EVE;
using Node.Database;
using Node.Exceptions.slash;
using Node.Inventory;
using Node.Inventory.Items;
using Node.Inventory.Items.Types;
using Node.Market;
using Node.Network;
using Node.Notifications.Client.Inventory;
using Node.Notifications.Client.Skills;
using Node.Services.Account;
using Node.StaticData;
using Node.StaticData.Inventory;
using PythonTypes.Types.Collections;
using PythonTypes.Types.Primitives;
using Type = Node.StaticData.Inventory.Type;

namespace Node.Services.Network
{
    public class slash : IService
    {
        private TypeManager TypeManager => this.ItemFactory.TypeManager;
        private ItemFactory ItemFactory { get; }
        private Channel Log { get; }
        private MarketDB MarketDB { get; }
        private CharacterDB CharacterDB { get; }
        private ItemDB ItemDB { get; }
        private NotificationManager NotificationManager { get; }
        private WalletManager WalletManager { get; }

        private readonly Dictionary<string, Action<string[], CallInformation>> mCommands =
            new Dictionary<string, Action<string[], CallInformation>>();
        
        public slash(Logger logger, ItemFactory itemFactory, MarketDB marketDB, CharacterDB characterDB, ItemDB itemDB, NotificationManager notificationManager, WalletManager walletManager)
        {
            this.Log = logger.CreateLogChannel("Slash");
            this.ItemFactory = itemFactory;
            this.MarketDB = marketDB;
            this.CharacterDB = characterDB;
            this.ItemDB = itemDB;
            this.NotificationManager = notificationManager;
            this.WalletManager = walletManager;

                // register commands
            this.mCommands["create"] = CreateCmd;
            this.mCommands["createitem"] = CreateCmd;
            this.mCommands["giveskills"] = GiveSkillCmd;
            this.mCommands["giveskill"] = GiveSkillCmd;
            this.mCommands["giveisk"] = GiveIskCmd;
        }

        private string GetCommandListForClient()
        {
            string result = "";

            foreach (KeyValuePair<string, Action<string[], CallInformation>> pair in this.mCommands)
                result += $"'{pair.Key}',";

            return $"[{result}]";
        }
        
        public PyDataType SlashCmd(PyString line, CallInformation call)
        {
            if ((call.Client.Role & (int) Roles.ROLE_ADMIN) != (int) Roles.ROLE_ADMIN)
                throw new SlashError("Only admins can run slash commands!");

            try
            {
                string[] parts = line.Value.Split(' ');

                // get the command name
                string command = parts[0].TrimStart('/');

                // only a "/" means the client is requesting the list of commands available
                if (command.Length == 0 || this.mCommands.ContainsKey(command) == false)
                    throw new SlashError("Commands: " + this.GetCommandListForClient());

                this.mCommands[command].Invoke(parts, call);
            }
            catch (SlashError)
            {
                throw;
            }
            catch (Exception e)
            {
                this.Log.Error(e.Message);
                this.Log.Error(e.StackTrace);
                
                throw new SlashError($"Runtime error: {e.Message}");
            }
            
            return null;
        }

        private void GiveIskCmd(string[] argv, CallInformation call)
        {
            if (argv.Length < 3)
                throw new SlashError("giveisk takes two arguments");

            string targetCharacter = argv[1];
            
            if (double.TryParse(argv[2], out double iskQuantity) == false)
                throw new SlashError("giveisk second argument must be the ISK quantity to give");

            int targetCharacterID = 0;
            int originCharacterID = call.Client.EnsureCharacterIsSelected();
            double finalBalance = 0;
            
            if (targetCharacter == "me")
            {
                targetCharacterID = originCharacterID;
            }
            else
            {
                List<int> matches = this.CharacterDB.FindCharacters(targetCharacter);

                if (matches.Count > 1)
                    throw new SlashError("There's more than one character that matches the search criteria, please narrow it down");

                targetCharacterID = matches[0];
            }

            using Wallet wallet = this.WalletManager.AcquireWallet(targetCharacterID, 1000);
            {
                if (iskQuantity < 0)
                {
                    wallet.EnsureEnoughBalance(iskQuantity);
                    wallet.CreateJournalRecord(MarketReference.GMCashTransfer, this.ItemFactory.OwnerSCC.ID, null, -iskQuantity);
                }
                else
                {
                    wallet.CreateJournalRecord(MarketReference.GMCashTransfer, this.ItemFactory.OwnerSCC.ID, targetCharacterID, null, iskQuantity);
                }
            }
        }

        private void CreateCmd(string[] argv, CallInformation call)
        {
            if (argv.Length < 2)
                throw new SlashError("create takes at least one argument");
            
            int typeID = int.Parse(argv[1]);
            int quantity = 1;
            
            if (argv.Length > 2)
                quantity = int.Parse(argv[2]);

            if (call.Client.StationID == null)
                throw new SlashError("Creating items can only be done at station");
            // ensure the typeID exists
            if (this.TypeManager.ContainsKey(typeID) == false)
                throw new SlashError("The specified typeID doesn't exist");
            
            // create a new item with the correct locationID
            Station location = this.ItemFactory.GetStaticStation((int) call.Client.StationID);
            Character character = this.ItemFactory.GetItem<Character>(call.Client.EnsureCharacterIsSelected());
            
            Type itemType = this.TypeManager[typeID];
            ItemEntity item = this.ItemFactory.CreateSimpleItem(itemType, character, location, Flags.Hangar, quantity);

            item.Persist();
            
            // send client a notification so they can display the item in the hangar
            call.Client.NotifyMultiEvent(OnItemChange.BuildNewItemChange(item));
        }

        private void GiveSkillCmd(string[] argv, CallInformation call)
        {
            // TODO: NOT NODE-SAFE, MUST REIMPLEMENT TAKING THAT INTO ACCOUNT!
            if (argv.Length != 4)
                throw new SlashError("GiveSkill must have 4 arguments");

            string target = argv[1].Trim(new [] { '"', ' '});
            string skillType = argv[2];
            int level = int.Parse(argv[3]);

            if (target != "me")
                throw new SlashError("giveskill only supports me for now");

            Character character = this.ItemFactory.GetItem<Character>(call.Client.EnsureCharacterIsSelected());
            
            if (skillType == "all")
            {
                // player wants all the skills!
                IEnumerable<KeyValuePair<int, Type>> skillTypes =
                    this.TypeManager.Where(x => x.Value.Group.Category.ID == (int) Categories.Skill && x.Value.Published == true);

                Dictionary<int, Skill> injectedSkills = character.InjectedSkillsByTypeID;

                foreach (KeyValuePair<int, Type> pair in skillTypes)
                {
                    // skill already injected, train it to the desired level
                    if (injectedSkills.ContainsKey(pair.Key) == true)
                    {
                        Skill skill = injectedSkills[pair.Key];

                        skill.Level = level;
                        skill.Persist();
                        call.Client.NotifyMultiEvent(new OnSkillTrained(skill));
                    }
                    else
                    {
                        // skill not injected, create it, inject and done
                        Skill skill = this.ItemFactory.CreateSkill(pair.Value, character, level,
                            SkillHistoryReason.GMGiveSkill);

                        call.Client.NotifyMultiEvent(OnItemChange.BuildNewItemChange(skill));
                        call.Client.NotifyMultiEvent(new OnSkillInjected());
                    }
                }
            }
            else
            {
                int skillTypeID = int.Parse(skillType);
                Dictionary<int, Skill> injectedSkills = character.InjectedSkillsByTypeID;

                if (injectedSkills.ContainsKey(skillTypeID) == true)
                {
                    Skill skill = injectedSkills[skillTypeID];

                    skill.Level = level;
                    skill.Persist();
                    call.Client.NotifyMultiEvent(new OnSkillTrained(skill));
                }
                else
                {
                    // skill not injected, create it, inject and done
                    Skill skill = this.ItemFactory.CreateSkill(this.TypeManager[skillTypeID], character, level,
                        SkillHistoryReason.GMGiveSkill);

                    call.Client.NotifyMultiEvent(OnItemChange.BuildNewItemChange(skill));
                    call.Client.NotifyMultiEvent(new OnSkillInjected());
                }
            }
        }
    }
}