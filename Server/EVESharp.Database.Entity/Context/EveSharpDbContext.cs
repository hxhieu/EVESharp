using System;
using System.Collections.Generic;
using EVESharp.Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity.Context;

public partial class EveSharpDbContext : DbContext
{
    public EveSharpDbContext(DbContextOptions<EveSharpDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AgtAgent> AgtAgents { get; set; }

    public virtual DbSet<AgtAgentType> AgtAgentTypes { get; set; }

    public virtual DbSet<AgtConfig> AgtConfigs { get; set; }

    public virtual DbSet<AgtMission> AgtMissions { get; set; }

    public virtual DbSet<AgtMissionGroup> AgtMissionGroups { get; set; }

    public virtual DbSet<AgtMissionType> AgtMissionTypes { get; set; }

    public virtual DbSet<AgtOffer> AgtOffers { get; set; }

    public virtual DbSet<AgtOfferGroup> AgtOfferGroups { get; set; }

    public virtual DbSet<AgtOfferRequired> AgtOfferRequireds { get; set; }

    public virtual DbSet<AgtOfferReward> AgtOfferRewards { get; set; }

    public virtual DbSet<AgtResearchAgent> AgtResearchAgents { get; set; }

    public virtual DbSet<AllRelationship> AllRelationships { get; set; }

    public virtual DbSet<BillType> BillTypes { get; set; }

    public virtual DbSet<BloodlineType> BloodlineTypes { get; set; }

    public virtual DbSet<CacheLocation> CacheLocations { get; set; }

    public virtual DbSet<CacheOwner> CacheOwners { get; set; }

    public virtual DbSet<ChrAccessory> ChrAccessories { get; set; }

    public virtual DbSet<ChrAncestry> ChrAncestries { get; set; }

    public virtual DbSet<ChrApplication> ChrApplications { get; set; }

    public virtual DbSet<ChrAttribute> ChrAttributes { get; set; }

    public virtual DbSet<ChrBackground> ChrBackgrounds { get; set; }

    public virtual DbSet<ChrBeard> ChrBeards { get; set; }

    public virtual DbSet<ChrBlaccessory> ChrBlaccessories { get; set; }

    public virtual DbSet<ChrBlbackground> ChrBlbackgrounds { get; set; }

    public virtual DbSet<ChrBlbeard> ChrBlbeards { get; set; }

    public virtual DbSet<ChrBlcostume> ChrBlcostumes { get; set; }

    public virtual DbSet<ChrBldeco> ChrBldecos { get; set; }

    public virtual DbSet<ChrBleye> ChrBleyes { get; set; }

    public virtual DbSet<ChrBleyebrow> ChrBleyebrows { get; set; }

    public virtual DbSet<ChrBlhair> ChrBlhairs { get; set; }

    public virtual DbSet<ChrBllight> ChrBllights { get; set; }

    public virtual DbSet<ChrBllipstick> ChrBllipsticks { get; set; }

    public virtual DbSet<ChrBlmakeup> ChrBlmakeups { get; set; }

    public virtual DbSet<ChrBloodline> ChrBloodlines { get; set; }

    public virtual DbSet<ChrBlskin> ChrBlskins { get; set; }

    public virtual DbSet<ChrBookmark> ChrBookmarks { get; set; }

    public virtual DbSet<ChrBounty> ChrBounties { get; set; }

    public virtual DbSet<ChrCareer> ChrCareers { get; set; }

    public virtual DbSet<ChrCareerSpeciality> ChrCareerSpecialities { get; set; }

    public virtual DbSet<ChrCertificate> ChrCertificates { get; set; }

    public virtual DbSet<ChrCombatLog> ChrCombatLogs { get; set; }

    public virtual DbSet<ChrCorporationRole> ChrCorporationRoles { get; set; }

    public virtual DbSet<ChrCostume> ChrCostumes { get; set; }

    public virtual DbSet<ChrDeco> ChrDecos { get; set; }

    public virtual DbSet<ChrDepartment> ChrDepartments { get; set; }

    public virtual DbSet<ChrEmployment> ChrEmployments { get; set; }

    public virtual DbSet<ChrEye> ChrEyes { get; set; }

    public virtual DbSet<ChrEyebrow> ChrEyebrows { get; set; }

    public virtual DbSet<ChrFaction> ChrFactions { get; set; }

    public virtual DbSet<ChrFriend> ChrFriends { get; set; }

    public virtual DbSet<ChrHair> ChrHairs { get; set; }

    public virtual DbSet<ChrInformation> ChrInformations { get; set; }

    public virtual DbSet<ChrLight> ChrLights { get; set; }

    public virtual DbSet<ChrLipstick> ChrLipsticks { get; set; }

    public virtual DbSet<ChrLpbalance> ChrLpbalances { get; set; }

    public virtual DbSet<ChrMakeup> ChrMakeups { get; set; }

    public virtual DbSet<ChrMedal> ChrMedals { get; set; }

    public virtual DbSet<ChrMissionState> ChrMissionStates { get; set; }

    public virtual DbSet<ChrNote> ChrNotes { get; set; }

    public virtual DbSet<ChrNpcstanding> ChrNpcstandings { get; set; }

    public virtual DbSet<ChrOffer> ChrOffers { get; set; }

    public virtual DbSet<ChrOwnerNote> ChrOwnerNotes { get; set; }

    public virtual DbSet<ChrRace> ChrRaces { get; set; }

    public virtual DbSet<ChrRaceSkill> ChrRaceSkills { get; set; }

    public virtual DbSet<ChrSchool> ChrSchools { get; set; }

    public virtual DbSet<ChrSchoolAgent> ChrSchoolAgents { get; set; }

    public virtual DbSet<ChrShipInsurance> ChrShipInsurances { get; set; }

    public virtual DbSet<ChrSkillHistory> ChrSkillHistories { get; set; }

    public virtual DbSet<ChrSkillQueue> ChrSkillQueues { get; set; }

    public virtual DbSet<ChrSkin> ChrSkins { get; set; }

    public virtual DbSet<ChrStanding> ChrStandings { get; set; }

    public virtual DbSet<ChrStandingTransaction> ChrStandingTransactions { get; set; }

    public virtual DbSet<ChrVote> ChrVotes { get; set; }

    public virtual DbSet<CluAddress> CluAddresses { get; set; }

    public virtual DbSet<Cluster> Clusters { get; set; }

    public virtual DbSet<ConBid> ConBids { get; set; }

    public virtual DbSet<ConContract> ConContracts { get; set; }

    public virtual DbSet<ConItem> ConItems { get; set; }

    public virtual DbSet<Corporation> Corporations { get; set; }

    public virtual DbSet<CourierMission> CourierMissions { get; set; }

    public virtual DbSet<CrpActivity> CrpActivities { get; set; }

    public virtual DbSet<CrpAlliance> CrpAlliances { get; set; }

    public virtual DbSet<CrpApplication> CrpApplications { get; set; }

    public virtual DbSet<CrpAuditLog> CrpAuditLogs { get; set; }

    public virtual DbSet<CrpAuditRole> CrpAuditRoles { get; set; }

    public virtual DbSet<CrpMedal> CrpMedals { get; set; }

    public virtual DbSet<CrpMedalPart> CrpMedalParts { get; set; }

    public virtual DbSet<CrpNpccorporation> CrpNpccorporations { get; set; }

    public virtual DbSet<CrpNpccorporationDivision> CrpNpccorporationDivisions { get; set; }

    public virtual DbSet<CrpNpccorporationResearchField> CrpNpccorporationResearchFields { get; set; }

    public virtual DbSet<CrpNpccorporationTrade> CrpNpccorporationTrades { get; set; }

    public virtual DbSet<CrpNpcdivision> CrpNpcdivisions { get; set; }

    public virtual DbSet<CrpNpctickerName> CrpNpctickerNames { get; set; }

    public virtual DbSet<CrpOffice> CrpOffices { get; set; }

    public virtual DbSet<CrpRecruitmentAd> CrpRecruitmentAds { get; set; }

    public virtual DbSet<CrpRecruitmentAdGroup> CrpRecruitmentAdGroups { get; set; }

    public virtual DbSet<CrpRecruitmentAdType> CrpRecruitmentAdTypes { get; set; }

    public virtual DbSet<CrpRole> CrpRoles { get; set; }

    public virtual DbSet<CrpRoleGroup> CrpRoleGroups { get; set; }

    public virtual DbSet<CrpShare> CrpShares { get; set; }

    public virtual DbSet<CrpStatic> CrpStatics { get; set; }

    public virtual DbSet<CrpTitle> CrpTitles { get; set; }

    public virtual DbSet<CrpTitlesTemplate> CrpTitlesTemplates { get; set; }

    public virtual DbSet<CrpVote> CrpVotes { get; set; }

    public virtual DbSet<CrpVoteOption> CrpVoteOptions { get; set; }

    public virtual DbSet<CrtCategory> CrtCategories { get; set; }

    public virtual DbSet<CrtCertificate> CrtCertificates { get; set; }

    public virtual DbSet<CrtClass> CrtClasses { get; set; }

    public virtual DbSet<CrtRecommendation> CrtRecommendations { get; set; }

    public virtual DbSet<CrtRelationship> CrtRelationships { get; set; }

    public virtual DbSet<DgmAttributeCategory> DgmAttributeCategories { get; set; }

    public virtual DbSet<DgmAttributeType> DgmAttributeTypes { get; set; }

    public virtual DbSet<DgmEffect> DgmEffects { get; set; }

    public virtual DbSet<DgmExpression> DgmExpressions { get; set; }

    public virtual DbSet<DgmTypeAttribute> DgmTypeAttributes { get; set; }

    public virtual DbSet<DgmTypeEffect> DgmTypeEffects { get; set; }

    public virtual DbSet<DroneState> DroneStates { get; set; }

    public virtual DbSet<EveConstant> EveConstants { get; set; }

    public virtual DbSet<EveGraphic> EveGraphics { get; set; }

    public virtual DbSet<EveLiveUpdate> EveLiveUpdates { get; set; }

    public virtual DbSet<EveMail> EveMails { get; set; }

    public virtual DbSet<EveMailMimeType> EveMailMimeTypes { get; set; }

    public virtual DbSet<EveMessage> EveMessages { get; set; }

    public virtual DbSet<EveName> EveNames { get; set; }

    public virtual DbSet<EveRole> EveRoles { get; set; }

    public virtual DbSet<EveUnit> EveUnits { get; set; }

    public virtual DbSet<FactionRace> FactionRaces { get; set; }

    public virtual DbSet<Intro> Intros { get; set; }

    public virtual DbSet<InvBlueprint> InvBlueprints { get; set; }

    public virtual DbSet<InvBlueprintType> InvBlueprintTypes { get; set; }

    public virtual DbSet<InvCategory> InvCategories { get; set; }

    public virtual DbSet<InvContrabandType> InvContrabandTypes { get; set; }

    public virtual DbSet<InvControlTowerResource> InvControlTowerResources { get; set; }

    public virtual DbSet<InvControlTowerResourcePurpose> InvControlTowerResourcePurposes { get; set; }

    public virtual DbSet<InvFlag> InvFlags { get; set; }

    public virtual DbSet<InvGroup> InvGroups { get; set; }

    public virtual DbSet<InvItem> InvItems { get; set; }

    public virtual DbSet<InvItemsAttribute> InvItemsAttributes { get; set; }

    public virtual DbSet<InvItemsLocked> InvItemsLockeds { get; set; }

    public virtual DbSet<InvMarketGroup> InvMarketGroups { get; set; }

    public virtual DbSet<InvMetaGroup> InvMetaGroups { get; set; }

    public virtual DbSet<InvMetaType> InvMetaTypes { get; set; }

    public virtual DbSet<InvPosition> InvPositions { get; set; }

    public virtual DbSet<InvShipType> InvShipTypes { get; set; }

    public virtual DbSet<InvType> InvTypes { get; set; }

    public virtual DbSet<InvTypeReaction> InvTypeReactions { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<LscChannelPermission> LscChannelPermissions { get; set; }

    public virtual DbSet<LscGeneralChannel> LscGeneralChannels { get; set; }

    public virtual DbSet<LscPrivateChannel> LscPrivateChannels { get; set; }

    public virtual DbSet<MapCelestialDescription> MapCelestialDescriptions { get; set; }

    public virtual DbSet<MapCelestialStatistic> MapCelestialStatistics { get; set; }

    public virtual DbSet<MapConstellation> MapConstellations { get; set; }

    public virtual DbSet<MapConstellationJump> MapConstellationJumps { get; set; }

    public virtual DbSet<MapDenormalize> MapDenormalizes { get; set; }

    public virtual DbSet<MapJump> MapJumps { get; set; }

    public virtual DbSet<MapLandmark> MapLandmarks { get; set; }

    public virtual DbSet<MapLocationWormholeClass> MapLocationWormholeClasses { get; set; }

    public virtual DbSet<MapPrecalculatedSolarSystemJump> MapPrecalculatedSolarSystemJumps { get; set; }

    public virtual DbSet<MapRegion> MapRegions { get; set; }

    public virtual DbSet<MapRegionJump> MapRegionJumps { get; set; }

    public virtual DbSet<MapSolarSystem> MapSolarSystems { get; set; }

    public virtual DbSet<MapSolarSystemJump> MapSolarSystemJumps { get; set; }

    public virtual DbSet<MapUniverse> MapUniverses { get; set; }

    public virtual DbSet<MarketRefType> MarketRefTypes { get; set; }

    public virtual DbSet<MktBill> MktBills { get; set; }

    public virtual DbSet<MktHistoryOld> MktHistoryOlds { get; set; }

    public virtual DbSet<MktJournal> MktJournals { get; set; }

    public virtual DbSet<MktKeyMap> MktKeyMaps { get; set; }

    public virtual DbSet<MktOrder> MktOrders { get; set; }

    public virtual DbSet<MktRefType> MktRefTypes { get; set; }

    public virtual DbSet<MktTransaction> MktTransactions { get; set; }

    public virtual DbSet<MktWallet> MktWallets { get; set; }

    public virtual DbSet<NpcStanding> NpcStandings { get; set; }

    public virtual DbSet<RamActivity> RamActivities { get; set; }

    public virtual DbSet<RamAssemblyLine> RamAssemblyLines { get; set; }

    public virtual DbSet<RamAssemblyLineStation> RamAssemblyLineStations { get; set; }

    public virtual DbSet<RamAssemblyLineStationCostLog> RamAssemblyLineStationCostLogs { get; set; }

    public virtual DbSet<RamAssemblyLineType> RamAssemblyLineTypes { get; set; }

    public virtual DbSet<RamAssemblyLineTypeDetailPerCategory> RamAssemblyLineTypeDetailPerCategories { get; set; }

    public virtual DbSet<RamAssemblyLineTypeDetailPerGroup> RamAssemblyLineTypeDetailPerGroups { get; set; }

    public virtual DbSet<RamCompletedStatus> RamCompletedStatuses { get; set; }

    public virtual DbSet<RamInstallationTypeDefaultContent> RamInstallationTypeDefaultContents { get; set; }

    public virtual DbSet<RamJob> RamJobs { get; set; }

    public virtual DbSet<RentalInfo> RentalInfos { get; set; }

    public virtual DbSet<RoidDistribution> RoidDistributions { get; set; }

    public virtual DbSet<Spawn> Spawns { get; set; }

    public virtual DbSet<SpawnBound> SpawnBounds { get; set; }

    public virtual DbSet<SpawnGroup> SpawnGroups { get; set; }

    public virtual DbSet<SpawnGroupEntry> SpawnGroupEntries { get; set; }

    public virtual DbSet<StaOperation> StaOperations { get; set; }

    public virtual DbSet<StaOperationService> StaOperationServices { get; set; }

    public virtual DbSet<StaService> StaServices { get; set; }

    public virtual DbSet<StaStation> StaStations { get; set; }

    public virtual DbSet<StaStationType> StaStationTypes { get; set; }

    public virtual DbSet<TrnTranslation> TrnTranslations { get; set; }

    public virtual DbSet<TrnTranslationColumn> TrnTranslationColumns { get; set; }

    public virtual DbSet<Tutorial> Tutorials { get; set; }

    public virtual DbSet<TutorialCategory> TutorialCategories { get; set; }

    public virtual DbSet<TutorialCriterion> TutorialCriteria { get; set; }

    public virtual DbSet<TutorialPage> TutorialPages { get; set; }

    public virtual DbSet<TutorialPageCriterion> TutorialPageCriteria { get; set; }

    public virtual DbSet<TutorialsCriteria> TutorialsCriterias { get; set; }

    public virtual DbSet<TypeActivityMaterial> TypeActivityMaterials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PRIMARY");
        });

        modelBuilder.Entity<AgtAgent>(entity =>
        {
            entity.HasKey(e => e.AgentId).HasName("PRIMARY");

            entity.Property(e => e.AgentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AgtAgentType>(entity =>
        {
            entity.HasKey(e => e.AgentTypeId).HasName("PRIMARY");
        });

        modelBuilder.Entity<AgtConfig>(entity =>
        {
            entity.HasKey(e => new { e.AgentId, e.K })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<AgtMission>(entity =>
        {
            entity.HasKey(e => e.MissionId).HasName("PRIMARY");

            entity.Property(e => e.MissionName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<AgtMissionGroup>(entity =>
        {
            entity.HasKey(e => new { e.CorporationId, e.DivisionId, e.Level })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<AgtMissionType>(entity =>
        {
            entity.HasKey(e => e.MissionTypeId).HasName("PRIMARY");

            entity.Property(e => e.MissionTypeName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<AgtOffer>(entity =>
        {
            entity.HasKey(e => e.OfferId).HasName("PRIMARY");

            entity.Property(e => e.OfferName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<AgtOfferGroup>(entity =>
        {
            entity.HasKey(e => new { e.CorporationId, e.DivisionId, e.Level })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<AgtOfferRequired>(entity =>
        {
            entity.HasKey(e => new { e.OfferId, e.TypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<AgtOfferReward>(entity =>
        {
            entity.HasKey(e => new { e.OfferId, e.TypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<AgtResearchAgent>(entity =>
        {
            entity.HasKey(e => new { e.AgentId, e.TypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<AllRelationship>(entity =>
        {
            entity.HasKey(e => new { e.FromId, e.ToId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<BillType>(entity =>
        {
            entity.HasKey(e => e.BillTypeId).HasName("PRIMARY");

            entity.Property(e => e.BillTypeId).ValueGeneratedNever();
            entity.Property(e => e.BillTypeName).HasDefaultValueSql("''");
            entity.Property(e => e.Description).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<BloodlineType>(entity =>
        {
            entity.HasKey(e => e.BloodlineId).HasName("PRIMARY");

            entity.Property(e => e.BloodlineId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CacheLocation>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PRIMARY");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
            entity.Property(e => e.LocationName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<CacheOwner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PRIMARY");

            entity.Property(e => e.OwnerId).ValueGeneratedNever();
            entity.Property(e => e.OwnerName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrAccessory>(entity =>
        {
            entity.HasKey(e => e.AccessoryId).HasName("PRIMARY");

            entity.Property(e => e.AccessoryId).ValueGeneratedNever();
            entity.Property(e => e.AccessoryName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrAncestry>(entity =>
        {
            entity.HasKey(e => e.AncestryId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrApplication>(entity =>
        {
            entity.HasKey(e => new { e.CorporationId, e.CharacterId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrAttribute>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrBackground>(entity =>
        {
            entity.HasKey(e => e.BackgroundId).HasName("PRIMARY");

            entity.Property(e => e.BackgroundId).ValueGeneratedNever();
            entity.Property(e => e.BackgroundName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrBeard>(entity =>
        {
            entity.HasKey(e => e.BeardId).HasName("PRIMARY");

            entity.Property(e => e.BeardId).ValueGeneratedNever();
            entity.Property(e => e.BeardName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrBlaccessory>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.AccessoryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBlbackground>(entity =>
        {
            entity.HasKey(e => e.BackgroundId).HasName("PRIMARY");

            entity.Property(e => e.BackgroundId).ValueGeneratedNever();
            entity.Property(e => e.BackgroundName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrBlbeard>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.BeardId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBlcostume>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.CostumeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBldeco>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.DecoId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBleye>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.EyesId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBleyebrow>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.EyebrowsId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBlhair>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.HairId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBllight>(entity =>
        {
            entity.HasKey(e => e.LightId).HasName("PRIMARY");

            entity.Property(e => e.LightId).ValueGeneratedNever();
            entity.Property(e => e.LightName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrBllipstick>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.LipstickId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBlmakeup>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.MakeupId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBloodline>(entity =>
        {
            entity.HasKey(e => e.BloodlineId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrBlskin>(entity =>
        {
            entity.HasKey(e => new { e.BloodlineId, e.Gender, e.SkinId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrBookmark>(entity =>
        {
            entity.HasKey(e => e.BookmarkId).HasName("PRIMARY");

            entity.Property(e => e.Comment).HasDefaultValueSql("'0'");
            entity.Property(e => e.Memo).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrBounty>(entity =>
        {
            entity.HasKey(e => e.BountyId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrCareer>(entity =>
        {
            entity.HasKey(e => e.CareerId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrCareerSpeciality>(entity =>
        {
            entity.HasKey(e => e.SpecialityId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrCertificate>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.CertificateId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrCombatLog>(entity =>
        {
            entity.HasKey(e => e.KillId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrCorporationRole>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("PRIMARY");

            entity.Property(e => e.CharacterId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ChrCostume>(entity =>
        {
            entity.HasKey(e => e.CostumeId).HasName("PRIMARY");

            entity.Property(e => e.CostumeId).ValueGeneratedNever();
            entity.Property(e => e.CostumeName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrDeco>(entity =>
        {
            entity.HasKey(e => e.DecoId).HasName("PRIMARY");

            entity.Property(e => e.DecoId).ValueGeneratedNever();
            entity.Property(e => e.DecoName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
            entity.Property(e => e.DepartmentName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrEmployment>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.CorporationId, e.StartDate })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<ChrEye>(entity =>
        {
            entity.HasKey(e => e.EyesId).HasName("PRIMARY");

            entity.Property(e => e.EyesId).ValueGeneratedNever();
            entity.Property(e => e.EyesName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrEyebrow>(entity =>
        {
            entity.HasKey(e => e.EyebrowsId).HasName("PRIMARY");

            entity.Property(e => e.EyebrowsId).ValueGeneratedNever();
            entity.Property(e => e.EyebrowsName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrFaction>(entity =>
        {
            entity.HasKey(e => e.FactionId).HasName("PRIMARY");

            entity.Property(e => e.FactionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ChrFriend>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.FriendId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.HasOne(d => d.Character).WithMany(p => p.ChrFriendCharacters)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_characterID");

            entity.HasOne(d => d.Friend).WithMany(p => p.ChrFriendFriends)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_friendID");
        });

        modelBuilder.Entity<ChrHair>(entity =>
        {
            entity.HasKey(e => e.HairId).HasName("PRIMARY");

            entity.Property(e => e.HairId).ValueGeneratedNever();
            entity.Property(e => e.HairName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrInformation>(entity =>
        {
            entity.HasKey(e => e.CharacterId).HasName("PRIMARY");

            entity.Property(e => e.CharacterId).ValueGeneratedNever();
            entity.Property(e => e.CorpAccountKey).HasDefaultValueSql("'1000'");
            entity.Property(e => e.FreeRespecs).HasDefaultValueSql("'2'");
            entity.Property(e => e.PetitionMessage).HasDefaultValueSql("''");
            entity.Property(e => e.Title).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrLight>(entity =>
        {
            entity.HasKey(e => e.LightId).HasName("PRIMARY");

            entity.Property(e => e.LightId).ValueGeneratedNever();
            entity.Property(e => e.LightName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrLipstick>(entity =>
        {
            entity.HasKey(e => e.LipstickId).HasName("PRIMARY");

            entity.Property(e => e.LipstickId).ValueGeneratedNever();
            entity.Property(e => e.LipstickName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrLpbalance>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.CorporationId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrMakeup>(entity =>
        {
            entity.HasKey(e => e.MakeupId).HasName("PRIMARY");

            entity.Property(e => e.MakeupId).ValueGeneratedNever();
            entity.Property(e => e.MakeupName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrMedal>(entity =>
        {
            entity.HasKey(e => new { e.MedalId, e.OwnerId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrMissionState>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.MissionId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrNpcstanding>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.FromId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrOffer>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.OfferId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrOwnerNote>(entity =>
        {
            entity.Property(e => e.NoteId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ChrRace>(entity =>
        {
            entity.HasKey(e => e.RaceId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrRaceSkill>(entity =>
        {
            entity.HasKey(e => new { e.RaceId, e.SkillTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrSchool>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrSchoolAgent>(entity =>
        {
            entity.HasKey(e => new { e.SchoolId, e.AgentIndex })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrShipInsurance>(entity =>
        {
            entity.HasKey(e => e.InsuranceId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ChrSkillHistory>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.SkillTypeId, e.EventId, e.LogDateTime })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0, 0 });
        });

        modelBuilder.Entity<ChrSkin>(entity =>
        {
            entity.HasKey(e => e.SkinId).HasName("PRIMARY");

            entity.Property(e => e.SkinId).ValueGeneratedNever();
            entity.Property(e => e.SkinName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ChrStanding>(entity =>
        {
            entity.HasKey(e => new { e.CharacterId, e.ToId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<ChrStandingTransaction>(entity =>
        {
            entity.HasKey(e => new { e.EventId, e.FromId, e.ToId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.Property(e => e.EventId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ChrVote>(entity =>
        {
            entity.HasKey(e => new { e.OptionId, e.CharacterId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CluAddress>(entity =>
        {
            entity.HasKey(e => new { e.Type, e.ObjectId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.Type).IsFixedLength();
        });

        modelBuilder.Entity<Cluster>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Ip).IsFixedLength();
            entity.Property(e => e.Role).IsFixedLength();
        });

        modelBuilder.Entity<ConBid>(entity =>
        {
            entity.HasKey(e => e.BidId).HasName("PRIMARY");
        });

        modelBuilder.Entity<ConContract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PRIMARY");

            entity.Property(e => e.AcceptorWalletKey).HasDefaultValueSql("'0'");
            entity.Property(e => e.CrateId).HasDefaultValueSql("'0'");
            entity.Property(e => e.IssuerAllianceId).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<ConItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Corporation>(entity =>
        {
            entity.HasKey(e => e.CorporationId).HasName("PRIMARY");

            entity.Property(e => e.CorporationId).ValueGeneratedNever();
            entity.Property(e => e.CorporationName).HasDefaultValueSql("''");
            entity.Property(e => e.Division1).HasDefaultValueSql("'1st Division'");
            entity.Property(e => e.Division2).HasDefaultValueSql("'2nd Division'");
            entity.Property(e => e.Division3).HasDefaultValueSql("'3rd Division'");
            entity.Property(e => e.Division4).HasDefaultValueSql("'4th Division'");
            entity.Property(e => e.Division5).HasDefaultValueSql("'5th Division'");
            entity.Property(e => e.Division6).HasDefaultValueSql("'6th Division'");
            entity.Property(e => e.Division7).HasDefaultValueSql("'7th Division'");
            entity.Property(e => e.MemberLimit).HasDefaultValueSql("'10'");
            entity.Property(e => e.SendCharTerminationMessage).HasDefaultValueSql("'1'");
            entity.Property(e => e.Shares).HasDefaultValueSql("'1000'");
            entity.Property(e => e.TickerName).HasDefaultValueSql("''");
            entity.Property(e => e.WalletDivision1).HasDefaultValueSql("'Master wallet'");
            entity.Property(e => e.WalletDivision2).HasDefaultValueSql("'2nd Wallet Division'");
            entity.Property(e => e.WalletDivision3).HasDefaultValueSql("'3rd Wallet Division'");
            entity.Property(e => e.WalletDivision4).HasDefaultValueSql("'4th Wallet Division'");
            entity.Property(e => e.WalletDivision5).HasDefaultValueSql("'5th Wallet Division'");
            entity.Property(e => e.WalletDivision6).HasDefaultValueSql("'6th Wallet Division'");
            entity.Property(e => e.WalletDivision7).HasDefaultValueSql("'7th Wallet Division'");
        });

        modelBuilder.Entity<CourierMission>(entity =>
        {
            entity.HasKey(e => e.MissionId).HasName("PRIMARY");
        });

        modelBuilder.Entity<CrpActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PRIMARY");
        });

        modelBuilder.Entity<CrpAlliance>(entity =>
        {
            entity.HasKey(e => e.AllianceId).HasName("PRIMARY");

            entity.Property(e => e.AllianceId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasDefaultValueSql("'0'");
            entity.Property(e => e.ExecutorCorpId).HasDefaultValueSql("'0'");
            entity.Property(e => e.ShortName).HasDefaultValueSql("''");
            entity.Property(e => e.Url).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<CrpApplication>(entity =>
        {
            entity.HasKey(e => e.CorporationId).HasName("PRIMARY");

            entity.Property(e => e.CorporationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CrpAuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<CrpAuditRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<CrpMedal>(entity =>
        {
            entity.HasKey(e => e.MedalId).HasName("PRIMARY");
        });

        modelBuilder.Entity<CrpMedalPart>(entity =>
        {
            entity.HasKey(e => new { e.MedalId, e.Index })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CrpNpccorporation>(entity =>
        {
            entity.HasKey(e => e.CorporationId).HasName("PRIMARY");

            entity.Property(e => e.CorporationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CrpNpccorporationDivision>(entity =>
        {
            entity.HasKey(e => new { e.CorporationId, e.DivisionId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CrpNpccorporationResearchField>(entity =>
        {
            entity.HasKey(e => new { e.SkillId, e.CorporationId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CrpNpcdivision>(entity =>
        {
            entity.HasKey(e => e.DivisionId).HasName("PRIMARY");
        });

        modelBuilder.Entity<CrpNpctickerName>(entity =>
        {
            entity.HasKey(e => e.CorporationId).HasName("PRIMARY");

            entity.Property(e => e.CorporationId).ValueGeneratedNever();
            entity.Property(e => e.TickerName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<CrpOffice>(entity =>
        {
            entity.HasKey(e => new { e.CorporationId, e.StationId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CrpRecruitmentAd>(entity =>
        {
            entity.HasKey(e => e.AdId).HasName("PRIMARY");

            entity.Property(e => e.Description).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<CrpRecruitmentAdGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PRIMARY");

            entity.Property(e => e.GroupName).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<CrpRecruitmentAdType>(entity =>
        {
            entity.HasKey(e => e.TypeMask).HasName("PRIMARY");

            entity.Property(e => e.TypeMask).ValueGeneratedNever();
        });

        modelBuilder.Entity<CrpRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasDefaultValueSql("''");
            entity.Property(e => e.ShortDescription).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<CrpRoleGroup>(entity =>
        {
            entity.HasKey(e => e.RoleGroupId).HasName("PRIMARY");

            entity.Property(e => e.RoleGroupId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CrpShare>(entity =>
        {
            entity.HasKey(e => new { e.OwnerId, e.CorporationId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CrpStatic>(entity =>
        {
            entity.HasKey(e => e.CorporationId).HasName("PRIMARY");

            entity.Property(e => e.CorporationName).HasDefaultValueSql("''");
            entity.Property(e => e.Division1).HasDefaultValueSql("'1st division'");
            entity.Property(e => e.Division2).HasDefaultValueSql("'2nd division'");
            entity.Property(e => e.Division3).HasDefaultValueSql("'3rd division'");
            entity.Property(e => e.Division4).HasDefaultValueSql("'4th division'");
            entity.Property(e => e.Division5).HasDefaultValueSql("'5th division'");
            entity.Property(e => e.Division6).HasDefaultValueSql("'6th division'");
            entity.Property(e => e.Division7).HasDefaultValueSql("'7th division'");
            entity.Property(e => e.TickerName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<CrpTitle>(entity =>
        {
            entity.HasKey(e => new { e.CorporationId, e.TitleId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CrpTitlesTemplate>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("PRIMARY");

            entity.Property(e => e.TitleId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CrpVote>(entity =>
        {
            entity.HasKey(e => e.VoteCaseId).HasName("PRIMARY");

            entity.Property(e => e.Description).HasDefaultValueSql("''");
            entity.Property(e => e.VoteCaseText).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<CrpVoteOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PRIMARY");

            entity.Property(e => e.OptionText).HasDefaultValueSql("''");
            entity.Property(e => e.Parameter1).HasDefaultValueSql("'0'");
            entity.Property(e => e.Parameter2).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<CrtCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");
        });

        modelBuilder.Entity<CrtCertificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PRIMARY");

            entity.Property(e => e.CertificateId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CrtClass>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PRIMARY");

            entity.Property(e => e.ClassId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CrtRecommendation>(entity =>
        {
            entity.HasKey(e => new { e.ShipTypeId, e.CertificateId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<CrtRelationship>(entity =>
        {
            entity.HasKey(e => e.RelationshipId).HasName("PRIMARY");

            entity.Property(e => e.RelationshipId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DgmAttributeCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");
        });

        modelBuilder.Entity<DgmAttributeType>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PRIMARY");

            entity.Property(e => e.AttributeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DgmEffect>(entity =>
        {
            entity.HasKey(e => e.EffectId).HasName("PRIMARY");

            entity.Property(e => e.EffectId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DgmExpression>(entity =>
        {
            entity.HasKey(e => e.ExpressionId).HasName("PRIMARY");

            entity.Property(e => e.ExpressionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<DgmTypeAttribute>(entity =>
        {
            entity.HasKey(e => new { e.TypeId, e.AttributeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<DgmTypeEffect>(entity =>
        {
            entity.HasKey(e => new { e.TypeId, e.EffectId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<DroneState>(entity =>
        {
            entity.HasKey(e => e.DroneId).HasName("PRIMARY");

            entity.Property(e => e.DroneId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EveConstant>(entity =>
        {
            entity.HasKey(e => e.ConstantId).HasName("PRIMARY");

            entity.Property(e => e.ConstantId).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<EveGraphic>(entity =>
        {
            entity.HasKey(e => e.GraphicId).HasName("PRIMARY");

            entity.Property(e => e.GraphicId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EveLiveUpdate>(entity =>
        {
            entity.HasKey(e => e.UpdateId).HasName("PRIMARY");
        });

        modelBuilder.Entity<EveMail>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PRIMARY");

            entity.Property(e => e.Body).HasDefaultValueSql("'0'");
            entity.Property(e => e.Subject).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<EveMailMimeType>(entity =>
        {
            entity.HasKey(e => e.MimeTypeId).HasName("PRIMARY");
        });

        modelBuilder.Entity<EveMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PRIMARY");

            entity.Property(e => e.MessageId).HasDefaultValueSql("''");
            entity.Property(e => e.MessageType).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<EveName>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EveRole>(entity =>
        {
            entity.HasKey(e => e.RoleName).HasName("PRIMARY");

            entity.Property(e => e.RoleName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<EveUnit>(entity =>
        {
            entity.HasKey(e => e.UnitId).HasName("PRIMARY");
        });

        modelBuilder.Entity<FactionRace>(entity =>
        {
            entity.HasKey(e => new { e.FactionId, e.RaceId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<InvBlueprint>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
            entity.Property(e => e.LicensedProductionRunsRemaining).HasDefaultValueSql("-1");
        });

        modelBuilder.Entity<InvBlueprintType>(entity =>
        {
            entity.HasKey(e => e.BlueprintTypeId).HasName("PRIMARY");

            entity.Property(e => e.BlueprintTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");
        });

        modelBuilder.Entity<InvContrabandType>(entity =>
        {
            entity.HasKey(e => new { e.FactionId, e.TypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<InvControlTowerResource>(entity =>
        {
            entity.HasKey(e => new { e.ControlTowerTypeId, e.ResourceTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<InvControlTowerResourcePurpose>(entity =>
        {
            entity.HasKey(e => e.Purpose).HasName("PRIMARY");

            entity.Property(e => e.Purpose).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvFlag>(entity =>
        {
            entity.HasKey(e => e.FlagId).HasName("PRIMARY");
        });

        modelBuilder.Entity<InvGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PRIMARY");

            entity.Property(e => e.GroupId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");
        });

        modelBuilder.Entity<InvItemsAttribute>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.AttributeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<InvItemsLocked>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvMarketGroup>(entity =>
        {
            entity.HasKey(e => e.MarketGroupId).HasName("PRIMARY");

            entity.Property(e => e.MarketGroupId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvMetaGroup>(entity =>
        {
            entity.HasKey(e => e.MetaGroupId).HasName("PRIMARY");

            entity.Property(e => e.MetaGroupId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvMetaType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.Property(e => e.TypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvPosition>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvShipType>(entity =>
        {
            entity.HasKey(e => e.ShipTypeId).HasName("PRIMARY");

            entity.Property(e => e.ShipTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.Property(e => e.TypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<InvTypeReaction>(entity =>
        {
            entity.HasKey(e => new { e.ReactionTypeId, e.Input, e.TypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PRIMARY");

            entity.Property(e => e.LanguageId).HasDefaultValueSql("''");
            entity.Property(e => e.LanguageName).HasDefaultValueSql("''");
            entity.Property(e => e.TranslatedLanguageName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<LscChannelPermission>(entity =>
        {
            entity.HasKey(e => new { e.ChannelId, e.Accessor })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<LscGeneralChannel>(entity =>
        {
            entity.HasKey(e => e.ChannelId).HasName("PRIMARY");
        });

        modelBuilder.Entity<LscPrivateChannel>(entity =>
        {
            entity.HasKey(e => e.ChannelId).HasName("PRIMARY");
        });

        modelBuilder.Entity<MapCelestialDescription>(entity =>
        {
            entity.HasKey(e => e.CelestialId).HasName("PRIMARY");

            entity.Property(e => e.CelestialId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapCelestialStatistic>(entity =>
        {
            entity.HasKey(e => e.CelestialId).HasName("PRIMARY");

            entity.Property(e => e.CelestialId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapConstellation>(entity =>
        {
            entity.HasKey(e => e.ConstellationId).HasName("PRIMARY");

            entity.Property(e => e.ConstellationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapConstellationJump>(entity =>
        {
            entity.HasKey(e => new { e.FromConstellationId, e.ToConstellationId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<MapDenormalize>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapJump>(entity =>
        {
            entity.HasKey(e => e.StargateId).HasName("PRIMARY");

            entity.Property(e => e.StargateId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapLandmark>(entity =>
        {
            entity.HasKey(e => e.LandmarkId).HasName("PRIMARY");

            entity.Property(e => e.LandmarkId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapLocationWormholeClass>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PRIMARY");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapPrecalculatedSolarSystemJump>(entity =>
        {
            entity.HasKey(e => new { e.FromSolarSystemId, e.ToSolarSystemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<MapRegion>(entity =>
        {
            entity.HasKey(e => e.RegionId).HasName("PRIMARY");

            entity.Property(e => e.RegionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapRegionJump>(entity =>
        {
            entity.HasKey(e => new { e.FromRegionId, e.ToRegionId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<MapSolarSystem>(entity =>
        {
            entity.HasKey(e => e.SolarSystemId).HasName("PRIMARY");

            entity.Property(e => e.SolarSystemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MapSolarSystemJump>(entity =>
        {
            entity.HasKey(e => new { e.FromSolarSystemId, e.ToSolarSystemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<MapUniverse>(entity =>
        {
            entity.HasKey(e => e.UniverseId).HasName("PRIMARY");

            entity.Property(e => e.UniverseId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MarketRefType>(entity =>
        {
            entity.HasKey(e => e.RefTypeId).HasName("PRIMARY");

            entity.Property(e => e.RefTypeId).ValueGeneratedNever();
            entity.Property(e => e.RefTypeText).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<MktBill>(entity =>
        {
            entity.HasKey(e => e.BillId).HasName("PRIMARY");

            entity.Property(e => e.ExternalId).HasDefaultValueSql("-1");
            entity.Property(e => e.ExternalId2).HasDefaultValueSql("-1");
        });

        modelBuilder.Entity<MktJournal>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.Property(e => e.CharId).HasDefaultValueSql("'0'");
            entity.Property(e => e.OwnerId1).HasDefaultValueSql("'0'");
            entity.Property(e => e.OwnerId2).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<MktKeyMap>(entity =>
        {
            entity.HasKey(e => e.AccountKey).HasName("PRIMARY");

            entity.Property(e => e.AccountKey).ValueGeneratedNever();
            entity.Property(e => e.AccountName).HasDefaultValueSql("''");
            entity.Property(e => e.AccountType).HasDefaultValueSql("''");
            entity.Property(e => e.Description).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<MktOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");
        });

        modelBuilder.Entity<MktRefType>(entity =>
        {
            entity.HasKey(e => e.RefTypeId).HasName("PRIMARY");

            entity.Property(e => e.RefTypeId).ValueGeneratedNever();
            entity.Property(e => e.RefTypeText).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<MktTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PRIMARY");

            entity.Property(e => e.AccountKey).HasDefaultValueSql("'1000'");
        });

        modelBuilder.Entity<MktWallet>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.OwnerId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<NpcStanding>(entity =>
        {
            entity.HasKey(e => new { e.FromId, e.ToId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<RamActivity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PRIMARY");
        });

        modelBuilder.Entity<RamAssemblyLine>(entity =>
        {
            entity.HasKey(e => e.AssemblyLineId).HasName("PRIMARY");

            entity.Property(e => e.AssemblyLineId).ValueGeneratedNever();
            entity.Property(e => e.NextFreeTime).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<RamAssemblyLineStation>(entity =>
        {
            entity.HasKey(e => new { e.StationId, e.AssemblyLineTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<RamAssemblyLineStationCostLog>(entity =>
        {
            entity.HasKey(e => e.AssemblyLineTypeId).HasName("PRIMARY");

            entity.Property(e => e.AssemblyLineTypeId).ValueGeneratedNever();
            entity.Property(e => e.LogDateTime)
                .HasDefaultValueSql("''")
                .IsFixedLength();
        });

        modelBuilder.Entity<RamAssemblyLineType>(entity =>
        {
            entity.HasKey(e => e.AssemblyLineTypeId).HasName("PRIMARY");
        });

        modelBuilder.Entity<RamAssemblyLineTypeDetailPerCategory>(entity =>
        {
            entity.HasKey(e => new { e.AssemblyLineTypeId, e.CategoryId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<RamAssemblyLineTypeDetailPerGroup>(entity =>
        {
            entity.HasKey(e => new { e.AssemblyLineTypeId, e.GroupId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<RamCompletedStatus>(entity =>
        {
            entity.HasKey(e => e.CompletedStatusId).HasName("PRIMARY");

            entity.Property(e => e.CompletedStatusId).ValueGeneratedNever();
            entity.Property(e => e.CompletedStatusName).HasDefaultValueSql("''");
            entity.Property(e => e.CompletedStatusText).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<RamInstallationTypeDefaultContent>(entity =>
        {
            entity.HasKey(e => e.InstallationTypeId).HasName("PRIMARY");

            entity.Property(e => e.InstallationTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<RamJob>(entity =>
        {
            entity.HasKey(e => e.JobId).HasName("PRIMARY");

            entity.Property(e => e.Description).HasDefaultValueSql("'blah'");
        });

        modelBuilder.Entity<RentalInfo>(entity =>
        {
            entity.HasKey(e => new { e.StationId, e.SlotNumber })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<Spawn>(entity =>
        {
            entity.HasKey(e => e.SpawnId).HasName("PRIMARY");
        });

        modelBuilder.Entity<SpawnBound>(entity =>
        {
            entity.HasKey(e => new { e.SpawnId, e.PointIndex })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<SpawnGroup>(entity =>
        {
            entity.HasKey(e => e.SpawnGroupId).HasName("PRIMARY");

            entity.Property(e => e.SpawnGroupName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<SpawnGroupEntry>(entity =>
        {
            entity.HasKey(e => new { e.SpawnGroupId, e.NpcTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.Property(e => e.Probability).HasDefaultValueSql("'1'");
            entity.Property(e => e.Quantity).HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<StaOperation>(entity =>
        {
            entity.HasKey(e => e.OperationId).HasName("PRIMARY");
        });

        modelBuilder.Entity<StaOperationService>(entity =>
        {
            entity.HasKey(e => new { e.OperationId, e.ServiceId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<StaService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PRIMARY");

            entity.Property(e => e.ServiceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<StaStation>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PRIMARY");

            entity.Property(e => e.StationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<StaStationType>(entity =>
        {
            entity.HasKey(e => e.StationTypeId).HasName("PRIMARY");

            entity.Property(e => e.StationTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TrnTranslation>(entity =>
        {
            entity.HasKey(e => new { e.TcId, e.KeyId, e.LanguageId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.Property(e => e.LanguageId).IsFixedLength();
        });

        modelBuilder.Entity<TrnTranslationColumn>(entity =>
        {
            entity.HasKey(e => e.TcId).HasName("PRIMARY");

            entity.Property(e => e.TcId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tutorial>(entity =>
        {
            entity.HasKey(e => e.TutorialId).HasName("PRIMARY");

            entity.Property(e => e.TutorialId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TutorialCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TutorialCriterion>(entity =>
        {
            entity.HasKey(e => e.CriteriaId).HasName("PRIMARY");

            entity.Property(e => e.CriteriaId).ValueGeneratedNever();
            entity.Property(e => e.CriteriaName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TutorialPage>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PRIMARY");

            entity.Property(e => e.PageId).ValueGeneratedNever();
            entity.Property(e => e.AudioPath).HasDefaultValueSql("''");
            entity.Property(e => e.PageName).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TutorialPageCriterion>(entity =>
        {
            entity.HasKey(e => new { e.PageId, e.CriteriaId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<TutorialsCriteria>(entity =>
        {
            entity.HasKey(e => new { e.TutorialId, e.CriteriaId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
        });

        modelBuilder.Entity<TypeActivityMaterial>(entity =>
        {
            entity.HasKey(e => new { e.TypeId, e.ActivityId, e.RequiredTypeId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
