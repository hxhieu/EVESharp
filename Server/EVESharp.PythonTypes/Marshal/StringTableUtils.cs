using System.Collections.Generic;

namespace EVESharp.PythonTypes.Marshal
{
    /// <summary>
    /// Utils for using strings on the StringTable
    /// </summary>
    public static class StringTableUtils
    {
        public enum EntryList
        {
            _corpid,
            _locationid,
            age,
            Asteroid,
            authentication,
            ballID,
            beyonce,
            bloodlineID,
            capacity,
            categoryID,
            character,
            characterID,
            characterName,
            characterType,
            charID,
            chatx,
            clientID,
            config,
            contraband,
            corporationDateTime,
            corporationID,
            createDateTime,
            customInfo,
            description,
            divisionID,
            DoDestinyUpdate,
            dogmaIM,
            EVE_System,
            flag,
            foo_SlimItem,
            gangID,
            Gemini,
            gender,
            graphicID,
            groupID,
            header,
            idName,
            invbroker,
            itemID,
            items,
            jumps,
            line,
            lines,
            locationID,
            locationName,
            macho_CallReq,
            macho_CallRsp,
            macho_MachoAddress,
            macho_Notification,
            macho_SessionChangeNotification,
            modules,
            name,
            objectCaching,
            objectCaching_CachedObject,
            OnChatJoin,
            OnChatLeave,
            OnChatSpeak,
            OnGodmaShipEffect,
            OnItemChange,
            OnModuleAttributeChange,
            OnMultiEvent,
            orbitID,
            ownerID,
            ownerName,
            quantity,
            raceID,
            RowClass,
            securityStatus,
            Sentry_Gun,
            sessionchange,
            singleton,
            skillEffect,
            squadronID,
            typeID,
            used,
            userID,
            util_CachedObject,
            util_IndexRowset,
            util_Moniker,
            util_Row,
            util_Rowset,
            _multicastID,
            AddBalls,
            AttackHit3,
            AttackHit3R,
            AttackHit4R,
            DoDestinyUpdates,
            GetLocationsEx,
            InvalidateCachedObjects,
            JoinChannel,
            LSC,
            LaunchMissile,
            LeaveChannel,
            OIDplus,
            OIDminus,
            OnAggressionChange,
            OnCharGangChange,
            OnCharNoLongerInStation,
            OnCharNowInStation,
            OnDamageMessage,
            OnDamageStateChange,
            OnEffectHit,
            OnGangDamageStateChange,
            OnLSC,
            OnSpecialFX,
            OnTarget,
            RemoveBalls,
            SendMessage,
            SetMaxSpeed,
            SetSpeedFraction,
            TerminalExplosion,
            address,
            alert,
            allianceID,
            allianceid,
            bid,
            bookmark,
            bounty,
            channel,
            charid,
            constellationid,
            corpID,
            corpid,
            corprole,
            damage,
            duration,
            effects_Laser,
            gangid,
            gangrole,
            hqID,
            issued,
            jit,
            languageID,
            locationid,
            machoVersion,
            marketProxy,
            minVolume,
            orderID,
            price,
            range,
            regionID,
            regionid,
            role,
            rolesAtAll,
            rolesAtBase,
            rolesAtHQ,
            rolesAtOther,
            shipid,
            sn,
            solarSystemID,
            solarsystemid,
            solarsystemid2,
            source,
            splash,
            stationID,
            stationid,
            target,
            userType,
            userid,
            volEntered,
            volRemaining,
            weapon,
            agent_missionTemplatizedContent_BasicKillMission,
            agent_missionTemplatizedContent_ResearchKillMission,
            agent_missionTemplatizedContent_StorylineKillMission,
            agent_missionTemplatizedContent_GenericStorylineKillMission,
            agent_missionTemplatizedContent_BasicCourierMission,
            agent_missionTemplatizedContent_ResearchCourierMission,
            agent_missionTemplatizedContent_StorylineCourierMission,
            agent_missionTemplatizedContent_GenericStorylineCourierMission,
            agent_missionTemplatizedContent_BasicTradeMission,
            agent_missionTemplatizedContent_ResearchTradeMission,
            agent_missionTemplatizedContent_StorylineTradeMission,
            agent_missionTemplatizedContent_GenericStorylineTradeMission,
            agent_offerTemplatizedContent_BasicExchangeOffer,
            agent_offerTemplatizedContent_BasicExchangeOffer_ContrabandDemand,
            agent_offerTemplatizedContent_BasicExchangeOffer_Crafting,
            agent_LoyaltyPoints,
            agent_ResearchPoints,
            agent_Credits,
            agent_Item,
            agent_Entity,
            agent_Objective,
            agent_FetchObjective,
            agent_EncounterObjective,
            agent_DungeonObjective,
            agent_TransportObjective,
            agent_Reward,
            agent_TimeBonusReward,
            agent_MissionReferral,
            agent_Location,
            agent_StandardMissionDetails,
            agent_OfferDetails,
            agent_ResearchMissionDetails,
            agent_StorylineMissionDetails,
        }
        
        public static readonly Dictionary<string,EntryList> LookupTable = new Dictionary<string, EntryList>()
        {
            {"*corpid", EntryList._corpid},
            {"*locationid", EntryList._locationid},
            {"age", EntryList.age},
            {"Asteroid", EntryList.Asteroid},
            {"authentication", EntryList.authentication},
            {"ballID", EntryList.ballID},
            {"beyonce", EntryList.beyonce},
            {"bloodlineID", EntryList.bloodlineID},
            {"capacity", EntryList.capacity},
            {"categoryID", EntryList.categoryID},
            {"character", EntryList.character},
            {"characterID", EntryList.characterID},
            {"characterName", EntryList.characterName},
            {"characterType", EntryList.characterType},
            {"charID", EntryList.charID},
            {"chatx", EntryList.chatx},
            {"clientID", EntryList.clientID},
            {"config", EntryList.config},
            {"contraband", EntryList.contraband},
            {"corporationDateTime", EntryList.corporationDateTime},
            {"corporationID", EntryList.corporationID},
            {"createDateTime", EntryList.createDateTime},
            {"customInfo", EntryList.customInfo},
            {"description", EntryList.description},
            {"divisionID", EntryList.divisionID},
            {"DoDestinyUpdate", EntryList.DoDestinyUpdate},
            {"dogmaIM", EntryList.dogmaIM},
            {"EVE System", EntryList.EVE_System},
            {"flag", EntryList.flag},
            {"foo.SlimItem", EntryList.foo_SlimItem},
            {"gangID", EntryList.gangID},
            {"Gemini", EntryList.Gemini},
            {"gender", EntryList.gender},
            {"graphicID", EntryList.graphicID},
            {"groupID", EntryList.groupID},
            {"header", EntryList.header},
            {"idName", EntryList.idName},
            {"invbroker", EntryList.invbroker},
            {"itemID", EntryList.itemID},
            {"items", EntryList.items},
            {"jumps", EntryList.jumps},
            {"line", EntryList.line},
            {"lines", EntryList.lines},
            {"locationID", EntryList.locationID},
            {"locationName", EntryList.locationName},
            {"macho.CallReq", EntryList.macho_CallReq},
            {"macho.CallRsp", EntryList.macho_CallRsp},
            {"macho.MachoAddress", EntryList.macho_MachoAddress},
            {"macho.Notification", EntryList.macho_Notification},
            {"macho.SessionChangeNotification", EntryList.macho_SessionChangeNotification},
            {"modules", EntryList.modules},
            {"name", EntryList.name},
            {"objectCaching", EntryList.objectCaching},
            {"objectCaching.CachedObject", EntryList.objectCaching_CachedObject},
            {"OnChatJoin", EntryList.OnChatJoin},
            {"OnChatLeave", EntryList.OnChatLeave},
            {"OnChatSpeak", EntryList.OnChatSpeak},
            {"OnGodmaShipEffect", EntryList.OnGodmaShipEffect},
            {"OnItemChange", EntryList.OnItemChange},
            {"OnModuleAttributeChange", EntryList.OnModuleAttributeChange},
            {"OnMultiEvent", EntryList.OnMultiEvent},
            {"orbitID", EntryList.orbitID},
            {"ownerID", EntryList.ownerID},
            {"ownerName", EntryList.ownerName},
            {"quantity", EntryList.quantity},
            {"raceID", EntryList.raceID},
            {"RowClass", EntryList.RowClass},
            {"securityStatus", EntryList.securityStatus},
            {"Sentry Gun", EntryList.Sentry_Gun},
            {"sessionchange", EntryList.sessionchange},
            {"singleton", EntryList.singleton},
            {"skillEffect", EntryList.skillEffect},
            {"squadronID", EntryList.squadronID},
            {"typeID", EntryList.typeID},
            {"used", EntryList.used},
            {"userID", EntryList.userID},
            {"util.CachedObject", EntryList.util_CachedObject},
            {"util.IndexRowset", EntryList.util_IndexRowset},
            {"util.Moniker", EntryList.util_Moniker},
            {"util.Row", EntryList.util_Row},
            {"util.Rowset", EntryList.util_Rowset},
            {"*multicastID", EntryList._multicastID},
            {"AddBalls", EntryList.AddBalls},
            {"AttackHit3", EntryList.AttackHit3},
            {"AttackHit3R", EntryList.AttackHit3R},
            {"AttackHit4R", EntryList.AttackHit4R},
            {"DoDestinyUpdates", EntryList.DoDestinyUpdates},
            {"GetLocationsEx", EntryList.GetLocationsEx},
            {"InvalidateCachedObjects", EntryList.InvalidateCachedObjects},
            {"JoinChannel", EntryList.JoinChannel},
            {"LSC", EntryList.LSC},
            {"LaunchMissile", EntryList.LaunchMissile},
            {"LeaveChannel", EntryList.LeaveChannel},
            {"OID+", EntryList.OIDplus},
            {"OID-", EntryList.OIDminus},
            {"OnAggressionChange", EntryList.OnAggressionChange},
            {"OnCharGangChange", EntryList.OnCharGangChange},
            {"OnCharNoLongerInStation", EntryList.OnCharNoLongerInStation},
            {"OnCharNowInStation", EntryList.OnCharNowInStation},
            {"OnDamageMessage", EntryList.OnDamageMessage},
            {"OnDamageStateChange", EntryList.OnDamageStateChange},
            {"OnEffectHit", EntryList.OnEffectHit},
            {"OnGangDamageStateChange", EntryList.OnGangDamageStateChange},
            {"OnLSC", EntryList.OnLSC},
            {"OnSpecialFX", EntryList.OnSpecialFX},
            {"OnTarget", EntryList.OnTarget},
            {"RemoveBalls", EntryList.RemoveBalls},
            {"SendMessage", EntryList.SendMessage},
            {"SetMaxSpeed", EntryList.SetMaxSpeed},
            {"SetSpeedFraction", EntryList.SetSpeedFraction},
            {"TerminalExplosion", EntryList.TerminalExplosion},
            {"address", EntryList.address},
            {"alert", EntryList.alert},
            {"allianceID", EntryList.allianceID},
            {"allianceid", EntryList.allianceid},
            {"bid", EntryList.bid},
            {"bookmark", EntryList.bookmark},
            {"bounty", EntryList.bounty},
            {"channel", EntryList.channel},
            {"charid", EntryList.charid},
            {"constellationid", EntryList.constellationid},
            {"corpID", EntryList.corpID},
            {"corpid", EntryList.corpid},
            {"corprole", EntryList.corprole},
            {"damage", EntryList.damage},
            {"duration", EntryList.duration},
            {"effects.Laser", EntryList.effects_Laser},
            {"gangid", EntryList.gangid},
            {"gangrole", EntryList.gangrole},
            {"hqID", EntryList.hqID},
            {"issued", EntryList.issued},
            {"jit", EntryList.jit},
            {"languageID", EntryList.languageID},
            {"locationid", EntryList.locationid},
            {"machoVersion", EntryList.machoVersion},
            {"marketProxy", EntryList.marketProxy},
            {"minVolume", EntryList.minVolume},
            {"orderID", EntryList.orderID},
            {"price", EntryList.price},
            {"range", EntryList.range},
            {"regionID", EntryList.regionID},
            {"regionid", EntryList.regionid},
            {"role", EntryList.role},
            {"rolesAtAll", EntryList.rolesAtAll},
            {"rolesAtBase", EntryList.rolesAtBase},
            {"rolesAtHQ", EntryList.rolesAtHQ},
            {"rolesAtOther", EntryList.rolesAtOther},
            {"shipid", EntryList.shipid},
            {"sn", EntryList.sn},
            {"solarSystemID", EntryList.solarSystemID},
            {"solarsystemid", EntryList.solarsystemid},
            {"solarsystemid2", EntryList.solarsystemid2},
            {"source", EntryList.source},
            {"splash", EntryList.splash},
            {"stationID", EntryList.stationID},
            {"stationid", EntryList.stationid},
            {"target", EntryList.target},
            {"userType", EntryList.userType},
            {"userid", EntryList.userid},
            {"volEntered", EntryList.volEntered},
            {"volRemaining", EntryList.volRemaining},
            {"weapon", EntryList.weapon},
            {"agent.missionTemplatizedContent_BasicKillMission", EntryList.agent_missionTemplatizedContent_BasicKillMission},
            {"agent.missionTemplatizedContent_ResearchKillMission", EntryList.agent_missionTemplatizedContent_ResearchKillMission},
            {"agent.missionTemplatizedContent_StorylineKillMission", EntryList.agent_missionTemplatizedContent_StorylineKillMission},
            {"agent.missionTemplatizedContent_GenericStorylineKillMission", EntryList.agent_missionTemplatizedContent_GenericStorylineKillMission},
            {"agent.missionTemplatizedContent_BasicCourierMission", EntryList.agent_missionTemplatizedContent_BasicCourierMission},
            {"agent.missionTemplatizedContent_ResearchCourierMission", EntryList.agent_missionTemplatizedContent_ResearchCourierMission},
            {"agent.missionTemplatizedContent_StorylineCourierMission", EntryList.agent_missionTemplatizedContent_StorylineCourierMission},
            {"agent.missionTemplatizedContent_GenericStorylineCourierMission", EntryList.agent_missionTemplatizedContent_GenericStorylineCourierMission},
            {"agent.missionTemplatizedContent_BasicTradeMission", EntryList.agent_missionTemplatizedContent_BasicTradeMission},
            {"agent.missionTemplatizedContent_ResearchTradeMission", EntryList.agent_missionTemplatizedContent_ResearchTradeMission},
            {"agent.missionTemplatizedContent_StorylineTradeMission", EntryList.agent_missionTemplatizedContent_StorylineTradeMission},
            {"agent.missionTemplatizedContent_GenericStorylineTradeMission", EntryList.agent_missionTemplatizedContent_GenericStorylineTradeMission},
            {"agent.offerTemplatizedContent_BasicExchangeOffer", EntryList.agent_offerTemplatizedContent_BasicExchangeOffer},
            {"agent.offerTemplatizedContent_BasicExchangeOffer_ContrabandDemand", EntryList.agent_offerTemplatizedContent_BasicExchangeOffer_ContrabandDemand},
            {"agent.offerTemplatizedContent_BasicExchangeOffer_Crafting", EntryList.agent_offerTemplatizedContent_BasicExchangeOffer_Crafting},
            {"agent.LoyaltyPoints", EntryList.agent_LoyaltyPoints},
            {"agent.ResearchPoints", EntryList.agent_ResearchPoints},
            {"agent.Credits", EntryList.agent_Credits},
            {"agent.Item", EntryList.agent_Item},
            {"agent.Entity", EntryList.agent_Entity},
            {"agent.Objective", EntryList.agent_Objective},
            {"agent.FetchObjective", EntryList.agent_FetchObjective},
            {"agent.EncounterObjective", EntryList.agent_EncounterObjective},
            {"agent.DungeonObjective", EntryList.agent_DungeonObjective},
            {"agent.TransportObjective", EntryList.agent_TransportObjective},
            {"agent.Reward", EntryList.agent_Reward},
            {"agent.TimeBonusReward", EntryList.agent_TimeBonusReward},
            {"agent.MissionReferral", EntryList.agent_MissionReferral},
            {"agent.Location", EntryList.agent_Location},
            {"agent.StandardMissionDetails", EntryList.agent_StandardMissionDetails},
            {"agent.OfferDetails", EntryList.agent_OfferDetails},
            {"agent.ResearchMissionDetails", EntryList.agent_ResearchMissionDetails},
            {"agent.StorylineMissionDetails", EntryList.agent_StorylineMissionDetails},
        };

        public static readonly List<string> Entries = new List<string>
        {
            "*corpid",
            "*locationid",
            "age",
            "Asteroid",
            "authentication",
            "ballID",
            "beyonce",
            "bloodlineID",
            "capacity",
            "categoryID",
            "character",
            "characterID",
            "characterName",
            "characterType",
            "charID",
            "chatx",
            "clientID",
            "config",
            "contraband",
            "corporationDateTime",
            "corporationID",
            "createDateTime",
            "customInfo",
            "description",
            "divisionID",
            "DoDestinyUpdate",
            "dogmaIM",
            "EVE System",
            "flag",
            "foo.SlimItem",
            "gangID",
            "Gemini",
            "gender",
            "graphicID",
            "groupID",
            "header",
            "idName",
            "invbroker",
            "itemID",
            "items",
            "jumps",
            "line",
            "lines",
            "locationID",
            "locationName",
            "macho.CallReq",
            "macho.CallRsp",
            "macho.MachoAddress",
            "macho.Notification",
            "macho.SessionChangeNotification",
            "modules",
            "name",
            "objectCaching",
            "objectCaching.CachedObject",
            "OnChatJoin",
            "OnChatLeave",
            "OnChatSpeak",
            "OnGodmaShipEffect",
            "OnItemChange",
            "OnModuleAttributeChange",
            "OnMultiEvent",
            "orbitID",
            "ownerID",
            "ownerName",
            "quantity",
            "raceID",
            "RowClass",
            "securityStatus",
            "Sentry Gun",
            "sessionchange",
            "singleton",
            "skillEffect",
            "squadronID",
            "typeID",
            "used",
            "userID",
            "util.CachedObject",
            "util.IndexRowset",
            "util.Moniker",
            "util.Row",
            "util.Rowset",
            "*multicastID",
            "AddBalls",
            "AttackHit3",
            "AttackHit3R",
            "AttackHit4R",
            "DoDestinyUpdates",
            "GetLocationsEx",
            "InvalidateCachedObjects",
            "JoinChannel",
            "LSC",
            "LaunchMissile",
            "LeaveChannel",
            "OID+",
            "OID-",
            "OnAggressionChange",
            "OnCharGangChange",
            "OnCharNoLongerInStation",
            "OnCharNowInStation",
            "OnDamageMessage",
            "OnDamageStateChange",
            "OnEffectHit",
            "OnGangDamageStateChange",
            "OnLSC",
            "OnSpecialFX",
            "OnTarget",
            "RemoveBalls",
            "SendMessage",
            "SetMaxSpeed",
            "SetSpeedFraction",
            "TerminalExplosion",
            "address",
            "alert",
            "allianceID",
            "allianceid",
            "bid",
            "bookmark",
            "bounty",
            "channel",
            "charid",
            "constellationid",
            "corpID",
            "corpid",
            "corprole",
            "damage",
            "duration",
            "effects.Laser",
            "gangid",
            "gangrole",
            "hqID",
            "issued",
            "jit",
            "languageID",
            "locationid",
            "machoVersion",
            "marketProxy",
            "minVolume",
            "orderID",
            "price",
            "range",
            "regionID",
            "regionid",
            "role",
            "rolesAtAll",
            "rolesAtBase",
            "rolesAtHQ",
            "rolesAtOther",
            "shipid",
            "sn",
            "solarSystemID",
            "solarsystemid",
            "solarsystemid2",
            "source",
            "splash",
            "stationID",
            "stationid",
            "target",
            "userType",
            "userid",
            "volEntered",
            "volRemaining",
            "weapon",
            "agent.missionTemplatizedContent_BasicKillMission",
            "agent.missionTemplatizedContent_ResearchKillMission",
            "agent.missionTemplatizedContent_StorylineKillMission",
            "agent.missionTemplatizedContent_GenericStorylineKillMission",
            "agent.missionTemplatizedContent_BasicCourierMission",
            "agent.missionTemplatizedContent_ResearchCourierMission",
            "agent.missionTemplatizedContent_StorylineCourierMission",
            "agent.missionTemplatizedContent_GenericStorylineCourierMission",
            "agent.missionTemplatizedContent_BasicTradeMission",
            "agent.missionTemplatizedContent_ResearchTradeMission",
            "agent.missionTemplatizedContent_StorylineTradeMission",
            "agent.missionTemplatizedContent_GenericStorylineTradeMission",
            "agent.offerTemplatizedContent_BasicExchangeOffer",
            "agent.offerTemplatizedContent_BasicExchangeOffer_ContrabandDemand",
            "agent.offerTemplatizedContent_BasicExchangeOffer_Crafting",
            "agent.LoyaltyPoints",
            "agent.ResearchPoints",
            "agent.Credits",
            "agent.Item",
            "agent.Entity",
            "agent.Objective",
            "agent.FetchObjective",
            "agent.EncounterObjective",
            "agent.DungeonObjective",
            "agent.TransportObjective",
            "agent.Reward",
            "agent.TimeBonusReward",
            "agent.MissionReferral",
            "agent.Location",
            "agent.StandardMissionDetails",
            "agent.OfferDetails",
            "agent.ResearchMissionDetails",
            "agent.StorylineMissionDetails",
        };
    }
}