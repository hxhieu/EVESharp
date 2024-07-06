using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpNPCCorporations")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpNpccorporation
{
    [Key]
    [Column("corporationID", TypeName = "int(11)")]
    public int CorporationId { get; set; }

    [Column("mainActivityID", TypeName = "int(11)")]
    public int? MainActivityId { get; set; }

    [Column("secondaryActivityID", TypeName = "int(11)")]
    public int? SecondaryActivityId { get; set; }

    [Column("size")]
    [StringLength(1)]
    public string? Size { get; set; }

    [Column("extent")]
    [StringLength(1)]
    public string? Extent { get; set; }

    [Column("solarSystemID", TypeName = "int(11)")]
    public int? SolarSystemId { get; set; }

    [Column("investorID1", TypeName = "int(11)")]
    public int? InvestorId1 { get; set; }

    [Column("investorShares1", TypeName = "int(11)")]
    public int? InvestorShares1 { get; set; }

    [Column("investorID2", TypeName = "int(11)")]
    public int? InvestorId2 { get; set; }

    [Column("investorShares2", TypeName = "int(11)")]
    public int? InvestorShares2 { get; set; }

    [Column("investorID3", TypeName = "int(11)")]
    public int? InvestorId3 { get; set; }

    [Column("investorShares3", TypeName = "int(11)")]
    public int? InvestorShares3 { get; set; }

    [Column("investorID4", TypeName = "int(11)")]
    public int? InvestorId4 { get; set; }

    [Column("investorShares4", TypeName = "int(11)")]
    public int? InvestorShares4 { get; set; }

    [Column("friendID", TypeName = "int(11)")]
    public int? FriendId { get; set; }

    [Column("enemyID", TypeName = "int(11)")]
    public int? EnemyId { get; set; }

    [Column("publicShares", TypeName = "int(11)")]
    public int? PublicShares { get; set; }

    [Column("initialPrice", TypeName = "int(11)")]
    public int? InitialPrice { get; set; }

    [Column("minSecurity")]
    public double? MinSecurity { get; set; }

    [Column("scattered", TypeName = "int(11)")]
    public int? Scattered { get; set; }

    [Column("fringe", TypeName = "int(11)")]
    public int? Fringe { get; set; }

    [Column("corridor", TypeName = "int(11)")]
    public int? Corridor { get; set; }

    [Column("hub", TypeName = "int(11)")]
    public int? Hub { get; set; }

    [Column("border", TypeName = "int(11)")]
    public int? Border { get; set; }

    [Column("factionID", TypeName = "int(11)")]
    public int? FactionId { get; set; }

    [Column("sizeFactor")]
    public double? SizeFactor { get; set; }

    [Column("stationCount", TypeName = "int(11)")]
    public int? StationCount { get; set; }

    [Column("stationSystemCount", TypeName = "int(11)")]
    public int? StationSystemCount { get; set; }
}
