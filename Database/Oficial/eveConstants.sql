/*Table structure for table `eveConstants` */

DROP TABLE IF EXISTS `eveConstants`;

CREATE TABLE `eveConstants` (
  `constantID` varchar(128) NOT NULL default '',
  `constantValue` int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (`constantID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `eveConstants` */

insert  into `eveConstants`(`constantID`,`constantValue`) values ('activityCopying',5),('activityDuplicating',6),('activityInventing',7),('activityInvention',8),('activityManufacturing',1),('activityNone',0),('activityPrototyping',6),('activityResearchingMaterialProductivity',4),('activityResearchingMineralProductivity',4),('activityResearchingTechnology',2),('activityResearchingTimeProductivity',3),('activityReverseEngineering',7),('agentRangeNeighboringConstellation',10),('agentRangeNeighboringConstellationSameRegion',9),('agentRangeNeighboringSystem',5),('agentRangeNeighboringSystemSameConstellation',4),('agentRangeSameConstellation',6),('agentRangeSameOrNeighboringConstellation',8),('agentRangeSameOrNeighboringConstellationSameRegion',7),('agentRangeSameOrNeighboringSystem',3),('agentRangeSameOrNeighboringSystemSameConstellation',2),('agentRangeSameSystem',1),('agentServiceForgeries',2),('agentServiceMissions',1),('agentServiceOffers',3),('agentServiceRequests',4),('agentTutorialContentID',2327),('agentTypeBasicAgent',2),('agentTypeCONCORDAgent',5),('agentTypeEventMissionAgent',8),('agentTypeGenericStorylineMissionAgent',6),('agentTypeNonAgent',1),('agentTypeResearchAgent',4),('agentTypeStorylineMissionAgent',7),('agentTypeTutorialAgent',3),('allianceApplicationAccepted',2),('allianceApplicationEffective',3),('allianceApplicationNew',1),('allianceApplicationRejected',4),('allianceCreationCost',1000000000),('allianceMembershipCost',2000000),('allianceRelationshipCompetitor',3),('allianceRelationshipEnemy',4),('allianceRelationshipFriend',2),('allianceRelationshipNAP',1),('ALSCActionAdd',6),('ALSCActionAssemble',1),('ALSCActionConfigure',10),('ALSCActionEnterPassword',9),('ALSCActionLock',7),('ALSCActionMove',4),('ALSCActionRepackage',2),('ALSCActionSetName',3),('ALSCActionSetPassword',5),('ALSCActionUnlock',8),('ALSCPasswordNeededToLock',2),('ALSCPasswordNeededToOpen',1),('ALSCPasswordNeededToUnlock',4),('ALSCPasswordNeededToViewAuditLog',8),('anchoringDelay',60000),('averageManufacturingCostPerUnitTime',0),('billMarketFine',1),('biomassLifetime',240),('blockAmarrCaldari',1),('blockGallenteMinmatar',2),('blockSmugglingCartel',3),('blockTerrorist',4),('blueprintTimeUnit',10000000),('cacheAccRefTypes',1),('cacheActBillTypes',2),('cacheAutStatus',3),('cacheAutTypes',4),('cacheCargoContainers',10007),('cacheChrAncestries',10016),('cacheChrAttributes',10021),('cacheChrBloodlines',10015),('cacheChrDepartments',10018),('cacheChrFactions',7),('cacheChrFields',10019),('cacheChrRaces',10014),('cacheChrSchools',10017),('cacheChrSpecialities',10020),('cacheCrpActivities',23),('cacheCrpNpcCorporations',8),('cacheCrpNpcDivisions',9),('cacheCrpRoleGroups',11),('cacheCrpRoles',10),('cacheEspAlliances',10004),('cacheEspCharacters',10002),('cacheEspCorporations',10003),('cacheEspSolarSystems',10005),('cacheEspUsers',10001),('cacheEveSettings',25),('cacheInvALSCActions',12),('cacheLogEventTypes',13),('cacheMktOrderStates',14),('cacheMlsLanguages',20),('cacheMlsStatuses',21),('cacheMlsTextsForGroup',10012),('cacheMlsTranslationClientPack',10013),('cacheMmsMimeTypes',15),('cachePetCategories',16),('cachePetQueues',17),('cachePriceHistory',10008),('cacheSolarSystemLoadRatios',24),('cacheSolarSystemObjects',10006),('cacheStaOperations',22),('cacheStaServices',18),('cacheTutCriterias',10009),('cacheTutorialVersions',10011),('cacheTutTutorials',10010),('cacheVcoStatuses',19),('cargoContainerLifetime',120),('characterCredits',0),('characterDeleteDelay',600),('characterTypeAgent',2),('characterTypeBroker',3),('characterTypePlayer',1),('chrattrCharisma',2),('chrattrIntelligence',1),('chrattrMemory',4),('chrattrPerception',3),('chrattrWillpower',5),('clusterGracePeriod',600),('completionTypeItem',2),('completionTypeType',1),('conAvailPrivate',1),('conAvailPublic',0),('concordAggressionPenalty',0),('concordPodKillPenalty',254),('concordPoliceAggressionPenalty',254),('concordPoliceKillPenalty',253),('concordSpamPreventionActISK',100),('conStatusCancelled',5),('conStatusExpired',8),('conStatusFailed',7),('conStatusFinished',4),('conStatusFinishedContractor',3),('conStatusFinishedIssuer',2),('conStatusInProgress',1),('conStatusOutstanding',0),('conStatusRejected',6),('containerBank',10007),('containerCharacter',10011),('containerCorpMarket',10012),('containerFactory',10006),('containerGlobal',10002),('containerHangar',10004),('containerOffices',10009),('containerRecycler',10008),('containerScrapHeap',10005),('containerSolarSystem',10003),('containerStationCharacters',10010),('containerWallet',10001),('conTypeAuction',2),('conTypeCourier',3),('conTypeFreeform',5),('conTypeItemExchange',1),('conTypeLoan',4),('conTypeNothing',0),('corpactivityAgriculture',1),('corpactivityBiotech',6),('corpactivityBureaucratic',13),('corpactivityChemical',4),('corpactivityConstruction',2),('corpactivityEducation',18),('corpactivityEntertainment',8),('corpactivityFinancial',17),('corpactivityHiTech',7),('corpactivityLegal',15),('corpactivityManufacture',19),('corpactivityMilitary',5),('corpactivityMining',3),('corpactivityPolitical',14),('corpactivityRetail',11),('corpactivitySecurity',16),('corpactivityShipyard',9),('corpactivityTrading',12),('corpactivityWarehouse',10),('corpdivisionAccounting',1),('corpdivisionAdministration',2),('corpdivisionAdvisory',3),('corpdivisionArchives',4),('corpdivisionAstrosurveying',5),('corpdivisionCommand',6),('corpdivisionDistribution',7),('corpdivisionFinancial',8),('corpdivisionIntelligence',9),('corpdivisionInternalSecurity',10),('corpdivisionLegal',11),('corpdivisionManufacturing',12),('corpdivisionMarketing',13),('corpdivisionMining',14),('corpdivisionPersonnel',15),('corpdivisionProduction',16),('corpdivisionPublicRelations',17),('corpdivisionRD',18),('corpdivisionSecurity',19),('corpdivisionStorage',20),('corpdivisionSurveillance',21),('corpLogoChangeCost',100),('corporationDeleted',1000001),('corporationStartupCost',1599800),('corpRoleAccountant',256),('corpRoleAccountCanQuery1',4294967295),('corpRoleAccountCanQuery2',4294967295),('corpRoleAccountCanQuery3',4294967295),('corpRoleAccountCanQuery4',4294967295),('corpRoleAccountCanQuery5',4294967295),('corpRoleAccountCanQuery6',4294967295),('corpRoleAccountCanQuery7',4294967295),('corpRoleAccountCanTake1',134217728),('corpRoleAccountCanTake2',268435456),('corpRoleAccountCanTake3',536870912),('corpRoleAccountCanTake4',1073741824),('corpRoleAccountCanTake5',2147483648),('corpRoleAccountCanTake6',4294967295),('corpRoleAccountCanTake7',4294967295),('corpRoleAuditor',4096),('corpRoleCanRentFactorySlot',4294967295),('corpRoleCanRentOffice',4294967295),('corpRoleCanRentResearchSlot',4294967295),('corpRoleChatManager',4294967295),('corpRoleContainerCanTake1',4294967295),('corpRoleContainerCanTake2',4294967295),('corpRoleContainerCanTake3',4294967295),('corpRoleContainerCanTake4',4294967295),('corpRoleContainerCanTake5',4294967295),('corpRoleContainerCanTake6',4294967295),('corpRoleContainerCanTake7',4294967295),('corpRoleDirector',1),('corpRoleEquipmentConfig',4294967295),('corpRoleFactoryManager',1024),('corpRoleHangarCanQuery1',1048576),('corpRoleHangarCanQuery2',2097152),('corpRoleHangarCanQuery3',4194304),('corpRoleHangarCanQuery4',8388608),('corpRoleHangarCanQuery5',16777216),('corpRoleHangarCanQuery6',33554432),('corpRoleHangarCanQuery7',67108864),('corpRoleHangarCanTake1',8192),('corpRoleHangarCanTake2',16384),('corpRoleHangarCanTake3',32768),('corpRoleHangarCanTake4',65536),('corpRoleHangarCanTake5',131072),('corpRoleHangarCanTake6',262144),('corpRoleHangarCanTake7',524288),('corpRoleJuniorAccountant',4294967295),('corpRoleLocationTypeBase',2),('corpRoleLocationTypeHQ',1),('corpRoleLocationTypeOther',3),('corpRolePersonnelManager',128),('corpRoleSecurityOfficer',512),('corpRoleStarbaseConfig',4294967295),('corpRoleStationManager',2048),('corpRoleTrader',4294967295),('corpStandingAggressionPenalty',0),('corpStationMgrGraceMinutes',60),('corpTitle1',1),('corpTitle2',2),('corpTitle3',4),('corpTitle4',8),('corpTitle5',16),('corpTitle6',32),('corpTitle7',64),('corpTitle8',128),('costCloneContract',5600),('costJumpClone',100000),('crpApplicationAcceptedByCharacter',2),('crpApplicationAcceptedByCorporation',6),('crpApplicationAppliedByCharacter',0),('crpApplicationRejectedByCharacter',3),('crpApplicationRejectedByCorporation',4),('crpApplicationRenegotiatedByCharacter',1),('crpApplicationRenegotiatedByCorporation',5),('CTPC_CHAT',8),('CTPC_MAIL',9),('CTPG_CASH',6),('CTPG_SHARES',7),('CTV_ADD',1),('CTV_COMMS',5),('CTV_GIVE',4),('CTV_REMOVE',2),('CTV_SET',3),('deftypeCapsule',670),('deftypeHouseWarmingGift',34),('dgmAssModAdd',2),('dgmAssModSub',3),('dgmAssPostDiv',5),('dgmAssPostMul',4),('dgmAssPostPercent',6),('dgmAssPreDiv',1),('dgmAssPreMul',0),('dgmEffActivation',1),('dgmEffArea',3),('dgmEffOnline',4),('dgmEffPassive',0),('dgmEffTarget',2),('dgmEnvArea',5),('dgmEnvChar',1),('dgmEnvOther',4),('dgmEnvSelf',0),('dgmEnvShip',2),('dgmEnvTarget',3),('dgmTauConstant',10000),('directorConcordSecurityLevelMax',1000),('directorConcordSecurityLevelMin',450),('directorConvoySecurityLevelMin',450),('directorPirateGateSecurityLevelMax',349),('directorPirateGateSecurityLevelMin',4294967295),('directorPirateSecurityLevelMax',849),('directorPirateSecurityLevelMin',4294967295),('directorTutorialSecurityLevelMin',1000),('dockingDelay',3000),('dockingProximity',200),('dockingSpeed',80),('dungeonGateUnlockPeriod',66),('ejectReasonBPLicensedProductionRunsUsed',5),('ejectReasonInstalledItemMissing',1),('ejectReasonInstalledItemRemoved',3),('ejectReasonJobHasCompleted',0),('ejectReasonJobUninstalled',10),('ejectReasonNotEnoughMaterialsToCopyBP',9),('ejectReasonNotEnoughResourcesAvailable',7),('ejectReasonNotEnoughResourcesInSlot',6),('ejectReasonSlotIsEmpty',2),('ejectReasonSlotLeaseExpired',4),('ejectReasonUnknownError',8),('entityApproaching',3),('entityCombat',1),('entityDeparting',4),('entityDeparting2',5),('entityFleeing',7),('entityIdle',0),('entityIncapacitated',0),('entityMining',2),('entityOperating',9),('entityPursuit',6),('entityUnanchored',254),('eventAllianceAcceptApplication',138),('eventAllianceAdd',131),('eventAllianceApply',133),('eventAllianceBecomeExecutor',136),('eventAllianceCHANGESHORTNAME',127),('eventAllianceDeclineApplication',139),('eventAllianceJoin',134),('eventAllianceLeave',135),('eventAllianceNoLongerExecutor',137),('eventAllianceRemove',132),('eventCharacterADD',1),('eventCharacterADDSUPER',18),('eventCharacterCANCELREMOVEPREPARE',41),('eventCharacterCHANGEAPPEARANCE',117),('eventCharacterCHANGEEMPLOYMENTRECORD',149),('eventCharacterCHANGEUSER',114),('eventCharacterImplantadded',94),('eventCharacterImplantremoved',95),('eventCharacterMAKESUPER',128),('eventCharacterPREPAREREMOVE',40),('eventCharacterREMOVE',3),('eventCharacterREMOVEEMPLOYMENTRECORD',150),('eventCharacterRESTORE',43),('eventCharacterSELECT',2),('eventControl TowerERROR',151),('eventControl TowerPlayerchange',152),('eventCorporationADDCORPORATION',12),('eventCorporationApplyforcorporationmembership',15),('eventCorporationBecomeaCEOinacorporation',16),('eventCorporationCHANGETICKER',115),('eventCorporationJoinCorporation',44),('eventCorporationLeaveCorporation',14),('eventCorporationQuitCEOposition',17),('eventCorporationREMOVECORPORATION',13),('eventCorporationUpdatemember',148),('eventCrimesStolefromJetcan',171),('eventDamageHeal',100),('eventDamagePodkill',9),('eventDamagePodkilled',10),('eventDamageSelfdestruct',42),('eventDamageShipkill',26),('eventDamageShipkilled',27),('eventDamageSuicide',11),('eventDungeonActivategate',147),('eventDungeonComplete',145),('eventDungeonCompleteAgent',146),('eventDungeonEnter',143),('eventDungeonEnterAgent',144),('eventItemCHANGENAME',31),('eventItemCreated',91),('eventItemEDIT',140),('eventItemEDITFROM',141),('eventItemEDITTO',142),('eventItemOwnerchanged',93),('eventItemREIMBURSE',113),('eventItemSingletonmade',92),('eventJump ClonesClonedestruction',166),('eventJump ClonesCloneimplantinstallation',168),('eventJump ClonesCloneinstallation',167),('eventJump ClonesClonejumptimereset',169),('eventMarketTransaction',129),('eventMissionAccepted',88),('eventMissionAllocationFailure_ItemDeclarationError',124),('eventMissionAllocationFailure_ItemResolutionFailure',123),('eventMissionAllocationFailure_SanityCheckFailure',122),('eventMissionAllocationFailure_UnexpectedException',125),('eventMissionDeclined',120),('eventMissionFailed',87),('eventMissionOffered',118),('eventMissionOfferExpired',121),('eventMissionQuit',119),('eventMissionSucceeded',86),('eventMovementClonejump',165),('eventMovementDock',4),('eventMovementJump',6),('eventMovementStationmove',7),('eventMovementSystemmove',8),('eventMovementTransfer',99),('eventMovementUndock',5),('eventResearchBlueprintAccepted',106),('eventResearchBlueprintOffered',101),('eventResearchBlueprintOfferExpired',105),('eventResearchBlueprintOfferInvalid',111),('eventResearchBlueprintOfferRejectedIncompatibleAgent',110),('eventResearchBlueprintOfferRejectedInvalidBlueprint',109),('eventResearchBlueprintOfferRejectedRecently',108),('eventResearchBlueprintOfferRejectedTooLowStandings',107),('eventResearchBlueprintRejected',102),('eventResearchStarted',103),('eventResearchStopped',104),('eventScience & IndustryEditassemblyline',170),('eventSkillGMGiveSkill',39),('eventSkillSkillclonepenalty',34),('eventSkillSkillgift',24),('eventSkillSkillreceivedincharactercreation',33),('eventSkillSkilltaskmaster',35),('eventSkillSkilltrainingcancelled',38),('eventSkillSkilltrainingcomplete',37),('eventSkillSkilltrainingstarted',36),('eventSkillUpdateskill',32),('eventSlashSetqty',30),('eventSlashSpawn',28),('eventSlashUnspawn',29),('eventStandingAgentBuyOff',71),('eventStandingAgentDonation',72),('eventStandingAgentMissionBonus',80),('eventStandingAgentMissionCompleted',73),('eventStandingAgentMissionDeclined',75),('eventStandingAgentMissionFailed',74),('eventStandingAgentMissionFailedRollback',97),('eventStandingAgentMissionOfferExpired',90),('eventStandingCombatAggression',76),('eventStandingCombatAssistance',112),('eventStandingCombatOther',79),('eventStandingCombatPodKill',78),('eventStandingCombatShipKill',77),('eventStandingContrabandTrafficking',126),('eventStandingDecay',49),('eventStandingDerivedModificationNegative',83),('eventStandingDerivedModificationPositive',82),('eventStandingInitialCorpAgent',52),('eventStandingInitialFactionAlly',70),('eventStandingInitialFactionCorp',54),('eventStandingInitialFactionEnemy',69),('eventStandingPirateKillSecurityStatus',89),('eventStandingPlayerCorpSetStanding',68),('eventStandingPlayerSetStanding',65),('eventStandingPortedStanding',85),('eventStandingPropertyDamage',154),('eventStandingReCalcEntityKills',58),('eventStandingReCalcMissionFailure',61),('eventStandingReCalcMissionSuccess',55),('eventStandingReCalcPirateKills',57),('eventStandingReCalcPlayerSetStanding',67),('eventStandingSlashSet',84),('eventStandingStandingCorrection',96),('eventStandingStandingreset',25),('eventStandingStandingRollback',98),('eventStandingTutorialAgentInitial',81),('eventStandingUpdatestanding',45),('eventStarbaseDeploypermissions',163),('eventStarbaseForcefieldsettings',161),('eventStarbasePassword',160),('eventStarbaseSentrysettings',162),('eventStarbaseStatechange',159),('eventStarbaseUsagepermissions',164),('eventTutorialAborted',158),('eventTutorialApplicationclosed',157),('eventTutorialClosed',156),('eventTutorialCompleted',155),('eventUnspecifiedAddOffice',46),('eventUnspecifiedCOMMAND',153),('eventUnspecifiedCreditgift',22),('eventUnspecifiedDELETEBOOKMARK',116),('eventUnspecifiedDEPLOYMENT',19),('eventUnspecifiedGag',20),('eventUnspecifiedLootgift',23),('eventUnspecifiedNPCAttackPoliceArrivedwithlowfactionstanding',48),('eventUnspecifiedNPCAttackPoliceArrivedwithlowsecuritystatus',47),('eventUnspecifiedUngag',21),('factionAmarrEmpire',500003),('factionAmmatar',500007),('factionAngelCartel',500011),('factionCaldariState',500001),('factionCONCORD',500006),('factionCONCORDAssembly',500006),('factionGallenteFederation',500004),('factionGuristasPirates',500010),('factionInterBus',500013),('factionJoveEmpire',500005),('factionKhanidKingdom',500008),('factionMinmatarRepublic',500002),('factionMordusLegion',500018),('factionMordusLegionCommand',500018),('factionORE',500014),('factionOuterRingExcavations',500014),('factionSanshasNation',500019),('factionSerpentis',500020),('factionSistersOfEVE',500016),('factionSocietyOfConsciousThought',500017),('factionTheBloodRaiderCovenant',500012),('factionTheInterBus',500013),('factionTheServantSistersofEVE',500016),('factionTheSociety',500017),('factionTheSyndicate',500009),('factionThukkerTribe',500015),('factionUnknown',500021),('flagAutoFit',0),('flagFactoryActive',39),('flagFactoryIdle',0),('flagFactorySlotFirst',140),('flagFactorySlotLast',195),('flagFixedSlot',35),('flagHiSlot0',27),('flagHiSlot1',28),('flagOfficeSlotFirst',70),('flagOfficeSlotLast',85),('flagResearchFacilitySlotFirst',200),('flagResearchFacilitySlotLast',255),('flagSlotFirst',11),('flagSlotLast',35),('flagWallet',1),('frequencyDay',5),('frequencyHour',4),('frequencyMinute',1),('frequencyMinute15',3),('frequencyMinute5',2),('frequencyMonth',7),('frequencyQuarter',8),('frequencyWeek',6),('frequencyYear',9),('gang',1),('gangGroupingRange',300),('gangLeaderRole',1),('genderFemale',0),('genderMale',1),('genderNeutral',2),('graphicShipAmarrColor0',806),('graphicShipAmarrSecondColor0',934),('graphicShipCaldariColor0',742),('graphicShipCaldariSecondColor0',870),('graphicShipGallenteColor0',838),('graphicShipGallenteSecondColor0',966),('graphicShipLayerColor0',671),('graphicShipLayerShape0',415),('graphicShipMinmatarColor0',774),('graphicShipMinmatarSecondColor0',902),('graphicShipTagColor0',710),('graphicShipTagFont01',703),('graphicUnknown',0),('greetingTypeBadMood',6),('greetingTypeFirstTime',1),('greetingTypeGoodMood',5),('greetingTypeLongTime',4),('greetingTypeMission1',7),('greetingTypeShortTime',3),('greetingTypeVeryShortTime',2),('invulnerabilityDocking',3000),('invulnerabilityExploding',30000),('invulnerabilityJumping',5000),('invulnerabilityRestoring',60000),('invulnerabilityUndocking',30000),('invulnerabilityWarpingIn',10000),('invulnerabilityWarpingOut',5000),('itemCredits',14),('itemIsogen',18),('itemMegacyte',21),('itemMexallon',17),('itemNocxium',19),('itemPyerite',16),('itemTritanium',15),('itemZydrine',20),('ixCategoryID',9),('ixContraband',5),('ixCustomInfo',10),('ixFlag',4),('ixGroupID',8),('ixItemID',0),('ixLauncherCapacity',0),('ixLauncherChargeItem',2),('ixLauncherUsed',1),('ixLocationID',3),('ixOwnerID',2),('ixQuantity',7),('ixSingleton',6),('ixSubitems',11),('ixTypeID',1),('jumpRadiusFactor',130),('jumpRadiusRandom',15000),('lifetimeOfDefaultContainer',120),('lifetimeOfDurableContainers',525600),('limitCloneJumpHours',24),('locationAbstract',0),('locationAlliance',3007),('locationBank',2),('locationCharacterGraveyard',1501),('locationCharDelJunkyard',1401),('locationCorpDelJunkyard',1402),('locationCorporation',13),('locationCorporationGraveyard',1502),('locationGraveyard',8),('locationJunkyard',10),('locationKillJunkyard',1007),('locationMissionJunkyard',1010),('locationRAMInstalledItems',2003),('locationRecycler',6),('locationSingletonJunkyard',25),('locationSystem',1),('locationTemp',5),('locationTradeSessionJunkyard',1008),('locationTrading',7),('locationUniverse',9),('lockedContainerAccessTime',180000),('marketCommissionPercentage',1),('marketFinePercentage',10),('marketMaxNPCCargoShown',300),('marketNPCRefreshRate',60),('maxAgent',3999999),('maxBoardingDistance',6550),('maxBuildDistance',10000),('maxCargoContainerTransferDistance',1500),('maxConfigureDistance',5000),('maxConstellation',29999999),('maxCourierMissionPackage',20000),('maxDockingDistance',50000),('maxFaction',599999),('maxItemCountPerLocation',1000),('maxJumpInDistance',13000),('maxNPCCorporation',1999999),('maxOrderDuration',7),('maxPetitionsPerDay',8),('maxPlayerItem',2099999999),('maxRegion',19999999),('maxScenarioItem',99999999),('maxSelfDestruct',15000),('maxSolarSystem',39999999),('maxStargate',59999999),('maxStargateJumpingDistance',2500),('maxStation',69999999),('maxUniverseAsteroid',79999999),('maxUniverseCelestial',49999999),('maxWarpgateJumpingDistance',2000),('maxWarpInDistance',100000),('maxWarpSpeed',30),('minAgent',3000000),('minConstellation',20000000),('minFaction',500000),('minFakeItem',2100000000),('minJumpInDistance',12000),('minNPCCorporation',1000000),('minPlayerItem',100000000),('minRegion',10000000),('minScenarioItem',90000000),('minSolarSystem',30000000),('minSpawnContainerDelay',300000),('minStargate',50000000),('minStation',60000000),('minUniverseAsteroid',70000000),('minUniverseCelestial',40000000),('minValidCharLocation',60000000),('minValidLocation',30000000),('minValidShipLocation',30000000),('minWarpDistance',150000),('minWarpInDistance',15000),('missionCourierMaxExpiryDays',7),('mktMinimumFee',100),('MktMininumFee',100),('mktModificationDelay',300),('mktOrderCancelled',3),('mktOrderExpired',2),('mktOrderOpen',0),('mktTransactionTax',1),('newsGlobal',2),('npcCivilian',2),('npcCorpMax',1999999),('npcCorpMin',1000000),('npcDivisionAccounting',1),('npcDivisionAdministration',2),('npcDivisionAdvisory',3),('npcDivisionArchives',4),('npcDivisionAstrosurveying',5),('npcDivisionCommand',6),('npcDivisionDistribution',7),('npcDivisionFinancial',8),('npcDivisionIntelligence',9),('npcDivisionInternalSecurity',10),('npcDivisionLegal',11),('npcDivisionManufacturing',12),('npcDivisionMarketing',13),('npcDivisionMining',14),('npcDivisionPersonnel',15),('npcDivisionProduction',16),('npcDivisionPublicRelations',17),('npcDivisionRD',18),('npcDivisionSecurity',19),('npcDivisionStorage',20),('npcDivisionSurveillance',21),('npcDruglord',8),('npcFlagPersonalAttack',2),('npcFlagPirateAidingPirate',7),('npcFlagPirateDefendingPirate',6),('npcFlagPoliceAidingPolice',4),('npcFlagPoliceAttackingPublicEnemy',5),('npcFlagPoliceDefendingPolice',3),('npcFlagUnapprovedCombat',1),('npcMaxWanderRange',100000),('npcPirate',4),('npcPirateArrivalAttackChance',80),('npcPolice',1),('npcTagTeamSizeLimit',2),('officeBranch',20002),('officeHQ',20001),('onlineCapacitorChargeRatio',95),('onlineCapacitorRemainderRatio',33),('outlawSecurityStatus',251),('ownerBank',2),('ownerCONCORD',1000125),('ownerMarket',3),('ownerNone',0),('ownerNPC',11),('ownerSCC',1000132),('ownerSecureCommerceCommission',1000132),('ownerStation',4),('ownerSystem',1),('ownerUnknown',3006),('petitionMaxChatLogSize',200000),('petitionMaxCombatLogSize',200000),('ramActivityCopying',5),('ramActivityDuplicating',6),('ramActivityInvention',8),('ramActivityManufacturing',1),('ramActivityNone',0),('ramActivityResearchingMaterialProductivity',4),('ramActivityResearchingTechnology',2),('ramActivityResearchingTimeProductivity',3),('ramActivityReverseEngineering',7),('ramJobStatusDelivered',4),('ramJobStatusInProgress',2),('ramJobStatusPending',1),('ramJobStatusReady',3),('ramMaxCopyRuns',20),('ramMaxCostPerHour',100000000),('ramMaxInstallCost',100000000),('ramMaxProductionTimeInDays',30),('ramRestrictByAlliance',8),('ramRestrictByCorp',4),('ramRestrictBySecurity',1),('ramRestrictByStanding',2),('ramRestrictNone',0),('rangeBubble',2),('rangeConstellation',4),('rangeLong',20000),('rangeMedium',10000),('rangeRegion',32767),('rangeShort',5000),('rangeSolarSystem',0),('rangeStation',0),('rangeVeryLong',40000),('rangeWorld',6),('refAccelerationGateFee',53),('refAgentDonation',28),('refAgentLocationServices',27),('refAgentMiscellaneous',25),('refAgentMissionCollateralPaid',30),('refAgentMissionCollateralRefunded',31),('refAgentMissionReward',33),('refAgentMissionTimeBonusReward',34),('refAgentSecurityServices',29),('refAgentServicesRendered',43),('refAgents_preward',32),('refAgents_temporary',18),('refAllianceMaintainanceFee',50),('refAllianceRegistrationFee',48),('refATMDeposit',5),('refATMWithdraw',4),('refBackwardCompatible',6),('refBounty',16),('refBountyPrize',17),('refBrokerfee',46),('refCloneActivation',8),('refCloneTransfer',52),('refContrabandFine',51),('refCopying',60),('refCorporationAccountWithdrawal',37),('refCorporationBulkPayment',47),('refCorporationDividendPayment',38),('refCorporationLiquidation',45),('refCorporationLogoChangeCost',40),('refCorporationPayment',11),('refCorporationRegistrationFee',39),('refCourierMissionEscrow',23),('refCSPA',35),('refCSPAOfflineRefund',36),('refDockingFee',12),('refDuplicating',61),('refFactorySlotRentalFee',14),('refGMCashTransfer',3),('refInheritance',9),('refInsurance',19),('refJumpCloneInstallationFee',55),('refLAST_REF',62),('refManufacturing',56),('refMarketEscrow',42),('refMarketFinePaid',44),('refMarketTransaction',2),('refMiscellaneousPaymentToAgent',26),('refMissionCompletion',21),('refMissionCost',24),('refMissionExpiration',20),('refMissionReward',7),('refOfficeRentalFee',13),('refPlayerDonation',10),('refPlayerTrading',1),('refReleaseOfImpoundedProperty',41),('refRepairBill',15),('refResearchingMaterialProductivity',59),('refResearchingTechnology',57),('refResearchingTimeProductivity',58),('refReverseEngineering',62),('refShares',22),('refSkipLog',0),('refTransactionTax',54),('refUndefined',0),('refWarFee',49),('regionAldurende',10000020),('rentalPeriodFactorySlot',5),('rentalPeriodOffice',30),('rentalPeriodResearchFacilitySlot',5),('repairCostPercentage',100),('SCCPasswordTypeConfig',2),('SCCPasswordTypeGeneral',1),('secLevelForBounty',0),('sentryTargetSwitchDelay',40000),('shipHidingCombatDelay',120000),('shipHidingDelay',60000),('shipHidingPvpCombatDelay',900000),('simulationTimeStep',1000),('sizeHuge',8),('sizeLarge',4),('sizeMedium',2),('sizeSmall',1),('skillEventCharCreation',33),('skillEventClonePenalty',34),('skillEventGMGive',39),('skillEventTaskMaster',35),('skillEventTrainingCancelled',38),('skillEventTrainingComplete',37),('skillEventTrainingStarted',36),('skillPointMultiplier',250),('solarsystemTimeout',28800),('standingBadSecurityMilliPointsForgotten',100),('starbaseSecurityLimit',800),('stateDocking',5),('stateDying',8),('stateGateIn',6),('stateGateOut',7),('stateInCombat',9),('stateNormal',10),('stateRecall',1),('stateUndocking',4),('stateWarpIn',2),('stateWarpOut',3),('stationServiceAssassinationMissions',2),('stationServiceBlackMarket',128),('stationServiceBountyMissions',1),('stationServiceCloning',512),('stationServiceCourierMissions',4),('stationServiceDNATherapy',2048),('stationServiceDocking',2097152),('stationServiceFactory',8192),('stationServiceFitting',65536),('stationServiceGambling',32768),('stationServiceInsurance',1048576),('stationServiceInterbus',8),('stationServiceJumpCloneFacility',8388608),('stationServiceLaboratory',16384),('stationServiceMarket',64),('stationServiceNews',262144),('stationServiceOfficeRental',4194304),('stationServicePaintshop',131072),('stationServiceRefinery',32),('stationServiceRepairFacilities',4096),('stationServiceReprocessingPlant',16),('stationServiceStockExchange',256),('stationServiceStorage',524288),('stationServiceSurgery',1024),('terminalExplosionDelay',30),('timeframeDay',1),('timeframeDay10',4),('timeframeDay2',2),('timeframeDay5',3),('timeframeDecade',14),('timeframeMonth',5),('timeframeMonth2',6),('timeframeMonth3',7),('timeframeMonth6',8),('timeframeYear',9),('timeframeYear2',10),('timeframeYear3',11),('timeframeYear4',12),('timeframeYear5',13),('tutorialFitting',13),('tutorialHangar',8),('tutorialMap',14),('tutorialMarket',12),('tutorialSpace',16),('tutorialStation',17),('undockInvulnerabilityDelay',20000),('voteCEO',0),('voteGeneral',4),('voteItemLockdown',5),('voteItemUnlock',6),('voteKickMember',3),('voteShares',2),('voteWar',1),('wantCollisionDamage',0),('warpDisruptionGateDistance',20000),('warpDisruptionGlobalDistance',100000),('warpJitterRadius',2500),('warRelationshipAtWar',3),('warRelationshipAtWarCanFight',4),('warRelationshipUnknown',0),('warRelationshipYourAlliance',2),('warRelationshipYourCorp',1);
/* add locationMarket constant */
INSERT INTO `eveConstants`(`constantID`, `constantValue`) VALUES ('locationMarket', 3);
/* add conCourierMaxVolume constant */
INSERT INTO `eveConstants`(`constantID`, `constantValue`) VALUES ('conCourierMaxVolume', 120000);