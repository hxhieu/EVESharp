using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrInformation")]
[Index("AccountId", Name = "FK_CHARACTER__ACCOUNTS")]
[Index("AccessoryId", Name = "FK_CHARACTER__CHRACCESSORIES")]
[Index("AncestryId", Name = "FK_CHARACTER__CHRANCESTRIES")]
[Index("BackgroundId", Name = "FK_CHARACTER__CHRBACKGROUNDS")]
[Index("BeardId", Name = "FK_CHARACTER__CHRBEARDS")]
[Index("CareerId", Name = "FK_CHARACTER__CHRCAREERS")]
[Index("CareerSpecialityId", Name = "FK_CHARACTER__CHRCAREERSPECIALITIES")]
[Index("CostumeId", Name = "FK_CHARACTER__CHRCOSTUMES")]
[Index("DecoId", Name = "FK_CHARACTER__CHRDECOS")]
[Index("EyebrowsId", Name = "FK_CHARACTER__CHREYEBROWS")]
[Index("EyesId", Name = "FK_CHARACTER__CHREYES")]
[Index("HairId", Name = "FK_CHARACTER__CHRHAIRS")]
[Index("LightId", Name = "FK_CHARACTER__CHRLIGHTS")]
[Index("LipstickId", Name = "FK_CHARACTER__CHRLIPSTICKS")]
[Index("MakeupId", Name = "FK_CHARACTER__CHRMAKEUPS")]
[Index("SchoolId", Name = "FK_CHARACTER__CHRSCHOOLS")]
[Index("SkinId", Name = "FK_CHARACTER__CHRSKINS")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrInformation
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Column("accountID", TypeName = "int(10) unsigned")]
    public uint? AccountId { get; set; }

    [Column("activeCloneID", TypeName = "int(10) unsigned")]
    public uint? ActiveCloneId { get; set; }

    [Column("timeLastJump", TypeName = "bigint(20)")]
    public long TimeLastJump { get; set; }

    [Column("title")]
    [StringLength(85)]
    public string Title { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    [Column("bounty")]
    public double Bounty { get; set; }

    [Column("securityRating")]
    public double SecurityRating { get; set; }

    [Column("petitionMessage")]
    [StringLength(85)]
    public string PetitionMessage { get; set; } = null!;

    [Column("logonMinutes", TypeName = "int(10) unsigned")]
    public uint LogonMinutes { get; set; }

    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Column("titleMask", TypeName = "int(20) unsigned")]
    public uint TitleMask { get; set; }

    [Column("roles", TypeName = "bigint(20) unsigned")]
    public ulong Roles { get; set; }

    [Column("rolesAtBase", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtBase { get; set; }

    [Column("rolesAtHQ", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtHq { get; set; }

    [Column("rolesAtOther", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtOther { get; set; }

    [Column("corporationDateTime", TypeName = "bigint(20) unsigned")]
    public ulong CorporationDateTime { get; set; }

    [Column("startDateTime", TypeName = "bigint(20) unsigned")]
    public ulong StartDateTime { get; set; }

    [Column("createDateTime", TypeName = "bigint(20) unsigned")]
    public ulong CreateDateTime { get; set; }

    [Column("ancestryID", TypeName = "int(10) unsigned")]
    public uint AncestryId { get; set; }

    [Column("careerID", TypeName = "int(10) unsigned")]
    public uint CareerId { get; set; }

    [Column("schoolID", TypeName = "int(10) unsigned")]
    public uint SchoolId { get; set; }

    [Column("careerSpecialityID", TypeName = "int(10) unsigned")]
    public uint CareerSpecialityId { get; set; }

    [Column("gender")]
    public bool Gender { get; set; }

    [Column("accessoryID", TypeName = "int(10) unsigned")]
    public uint? AccessoryId { get; set; }

    [Column("beardID", TypeName = "int(10) unsigned")]
    public uint? BeardId { get; set; }

    [Column("costumeID", TypeName = "int(10) unsigned")]
    public uint CostumeId { get; set; }

    [Column("decoID", TypeName = "int(10) unsigned")]
    public uint? DecoId { get; set; }

    [Column("eyebrowsID", TypeName = "int(10) unsigned")]
    public uint EyebrowsId { get; set; }

    [Column("eyesID", TypeName = "int(10) unsigned")]
    public uint EyesId { get; set; }

    [Column("hairID", TypeName = "int(10) unsigned")]
    public uint HairId { get; set; }

    [Column("lipstickID", TypeName = "int(10) unsigned")]
    public uint? LipstickId { get; set; }

    [Column("makeupID", TypeName = "int(10) unsigned")]
    public uint? MakeupId { get; set; }

    [Column("skinID", TypeName = "int(10) unsigned")]
    public uint SkinId { get; set; }

    [Column("backgroundID", TypeName = "int(10) unsigned")]
    public uint BackgroundId { get; set; }

    [Column("lightID", TypeName = "int(10) unsigned")]
    public uint LightId { get; set; }

    [Column("headRotation1")]
    public double HeadRotation1 { get; set; }

    [Column("headRotation2")]
    public double HeadRotation2 { get; set; }

    [Column("headRotation3")]
    public double HeadRotation3 { get; set; }

    [Column("eyeRotation1")]
    public double EyeRotation1 { get; set; }

    [Column("eyeRotation2")]
    public double EyeRotation2 { get; set; }

    [Column("eyeRotation3")]
    public double EyeRotation3 { get; set; }

    [Column("camPos1")]
    public double CamPos1 { get; set; }

    [Column("camPos2")]
    public double CamPos2 { get; set; }

    [Column("camPos3")]
    public double CamPos3 { get; set; }

    [Column("morph1e")]
    public double? Morph1e { get; set; }

    [Column("morph1n")]
    public double? Morph1n { get; set; }

    [Column("morph1s")]
    public double? Morph1s { get; set; }

    [Column("morph1w")]
    public double? Morph1w { get; set; }

    [Column("morph2e")]
    public double? Morph2e { get; set; }

    [Column("morph2n")]
    public double? Morph2n { get; set; }

    [Column("morph2s")]
    public double? Morph2s { get; set; }

    [Column("morph2w")]
    public double? Morph2w { get; set; }

    [Column("morph3e")]
    public double? Morph3e { get; set; }

    [Column("morph3n")]
    public double? Morph3n { get; set; }

    [Column("morph3s")]
    public double? Morph3s { get; set; }

    [Column("morph3w")]
    public double? Morph3w { get; set; }

    [Column("morph4e")]
    public double? Morph4e { get; set; }

    [Column("morph4n")]
    public double? Morph4n { get; set; }

    [Column("morph4s")]
    public double? Morph4s { get; set; }

    [Column("morph4w")]
    public double? Morph4w { get; set; }

    [Column("stationID", TypeName = "int(10) unsigned")]
    public uint StationId { get; set; }

    [Column("solarSystemID", TypeName = "int(10) unsigned")]
    public uint SolarSystemId { get; set; }

    [Column("constellationID", TypeName = "int(10) unsigned")]
    public uint ConstellationId { get; set; }

    [Column("regionID", TypeName = "int(10) unsigned")]
    public uint RegionId { get; set; }

    [Column("online")]
    public bool Online { get; set; }

    [Column("nextRespecTime", TypeName = "bigint(20)")]
    public long NextRespecTime { get; set; }

    [Column("freeRespecs", TypeName = "int(11)")]
    public int FreeRespecs { get; set; }

    [Column("lastOnline", TypeName = "bigint(20)")]
    public long LastOnline { get; set; }

    [Column("warfactionID", TypeName = "int(11)")]
    public int? WarfactionId { get; set; }

    [Column("logonDateTime", TypeName = "bigint(20)")]
    public long LogonDateTime { get; set; }

    [Column("logoffDateTime", TypeName = "bigint(20)")]
    public long LogoffDateTime { get; set; }

    [Column("corpAccountKey", TypeName = "int(10)")]
    public int CorpAccountKey { get; set; }

    [Column("corpStasisTime", TypeName = "bigint(20)")]
    public long? CorpStasisTime { get; set; }

    [Column("blockRoles", TypeName = "tinyint(4)")]
    public sbyte? BlockRoles { get; set; }

    [Column("grantableRoles", TypeName = "bigint(20)")]
    public long GrantableRoles { get; set; }

    [Column("grantableRolesAtHQ", TypeName = "bigint(20)")]
    public long GrantableRolesAtHq { get; set; }

    [Column("grantableRolesAtBase", TypeName = "bigint(20)")]
    public long GrantableRolesAtBase { get; set; }

    [Column("grantableRolesAtOther", TypeName = "bigint(20)")]
    public long GrantableRolesAtOther { get; set; }

    [Column("baseID", TypeName = "int(11)")]
    public int? BaseId { get; set; }

    [InverseProperty("Character")]
    public virtual ICollection<ChrFriend> ChrFriendCharacters { get; set; } = new List<ChrFriend>();

    [InverseProperty("Friend")]
    public virtual ICollection<ChrFriend> ChrFriendFriends { get; set; } = new List<ChrFriend>();
}
