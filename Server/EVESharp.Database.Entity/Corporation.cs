using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("corporation")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class Corporation
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Column("corporationName")]
    [StringLength(100)]
    public string CorporationName { get; set; } = null!;

    [Column("description", TypeName = "mediumtext")]
    public string Description { get; set; } = null!;

    [Column("tickerName")]
    [StringLength(8)]
    public string TickerName { get; set; } = null!;

    [Column("url", TypeName = "mediumtext")]
    public string Url { get; set; } = null!;

    [Column("taxRate")]
    public double TaxRate { get; set; }

    [Column("minimumJoinStanding")]
    public double MinimumJoinStanding { get; set; }

    [Column("corporationType", TypeName = "int(10) unsigned")]
    public uint CorporationType { get; set; }

    [Column("hasPlayerPersonnelManager", TypeName = "tinyint(3) unsigned")]
    public byte HasPlayerPersonnelManager { get; set; }

    [Column("sendCharTerminationMessage", TypeName = "tinyint(3) unsigned")]
    public byte SendCharTerminationMessage { get; set; }

    [Column("creatorID", TypeName = "int(10) unsigned")]
    public uint CreatorId { get; set; }

    [Column("ceoID", TypeName = "int(10) unsigned")]
    public uint CeoId { get; set; }

    [Column("stationID", TypeName = "int(10) unsigned")]
    public uint StationId { get; set; }

    [Column("raceID", TypeName = "int(10) unsigned")]
    public uint? RaceId { get; set; }

    [Column("allianceID", TypeName = "int(10) unsigned")]
    public uint? AllianceId { get; set; }

    [Column("shares", TypeName = "bigint(20) unsigned")]
    public ulong Shares { get; set; }

    [Column("memberCount", TypeName = "int(10) unsigned")]
    public uint MemberCount { get; set; }

    [Column("memberLimit", TypeName = "int(10) unsigned")]
    public uint MemberLimit { get; set; }

    [Column("allowedMemberRaceIDs", TypeName = "int(10) unsigned")]
    public uint AllowedMemberRaceIds { get; set; }

    [Column("graphicID", TypeName = "int(10) unsigned")]
    public uint GraphicId { get; set; }

    [Column("shape1", TypeName = "int(10) unsigned")]
    public uint? Shape1 { get; set; }

    [Column("shape2", TypeName = "int(10) unsigned")]
    public uint? Shape2 { get; set; }

    [Column("shape3", TypeName = "int(10) unsigned")]
    public uint? Shape3 { get; set; }

    [Column("color1", TypeName = "int(10) unsigned")]
    public uint? Color1 { get; set; }

    [Column("color2", TypeName = "int(10) unsigned")]
    public uint? Color2 { get; set; }

    [Column("color3", TypeName = "int(10) unsigned")]
    public uint? Color3 { get; set; }

    [Column("typeface")]
    [StringLength(11)]
    public string? Typeface { get; set; }

    [Column("division1")]
    [StringLength(100)]
    public string? Division1 { get; set; }

    [Column("division2")]
    [StringLength(100)]
    public string? Division2 { get; set; }

    [Column("division3")]
    [StringLength(100)]
    public string? Division3 { get; set; }

    [Column("division4")]
    [StringLength(100)]
    public string? Division4 { get; set; }

    [Column("division5")]
    [StringLength(100)]
    public string? Division5 { get; set; }

    [Column("division6")]
    [StringLength(100)]
    public string? Division6 { get; set; }

    [Column("division7")]
    [StringLength(100)]
    public string? Division7 { get; set; }

    [Column("walletDivision1")]
    [StringLength(100)]
    public string? WalletDivision1 { get; set; }

    [Column("walletDivision2")]
    [StringLength(100)]
    public string? WalletDivision2 { get; set; }

    [Column("walletDivision3")]
    [StringLength(100)]
    public string? WalletDivision3 { get; set; }

    [Column("walletDivision4")]
    [StringLength(100)]
    public string? WalletDivision4 { get; set; }

    [Column("walletDivision5")]
    [StringLength(100)]
    public string? WalletDivision5 { get; set; }

    [Column("walletDivision6")]
    [StringLength(100)]
    public string? WalletDivision6 { get; set; }

    [Column("walletDivision7")]
    [StringLength(100)]
    public string? WalletDivision7 { get; set; }

    [Column("deleted", TypeName = "tinyint(3) unsigned")]
    public byte Deleted { get; set; }

    [Column("startDate", TypeName = "bigint(20)")]
    public long? StartDate { get; set; }

    [Column("chosenExecutorID", TypeName = "int(11)")]
    public int? ChosenExecutorId { get; set; }
}
