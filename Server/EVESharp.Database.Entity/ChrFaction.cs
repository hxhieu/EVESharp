using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrFactions")]
[Index("CorporationId", Name = "corporationID")]
[Index("MilitiaCorporationId", Name = "militiaCorporationID")]
[Index("SolarSystemId", Name = "solarSystemID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrFaction
{
    [Key]
    [Column("factionID", TypeName = "int(11)")]
    public int FactionId { get; set; }

    [Column("factionName")]
    [StringLength(100)]
    public string? FactionName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("raceIDs", TypeName = "int(11)")]
    public int? RaceIds { get; set; }

    [Column("solarSystemID", TypeName = "int(11)")]
    public int? SolarSystemId { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int? CorporationId { get; set; }

    [Column("sizeFactor")]
    public double? SizeFactor { get; set; }

    [Column("stationCount", TypeName = "smallint(6)")]
    public short? StationCount { get; set; }

    [Column("stationSystemCount", TypeName = "smallint(6)")]
    public short? StationSystemCount { get; set; }

    [Column("militiaCorporationID", TypeName = "int(11)")]
    public int? MilitiaCorporationId { get; set; }
}
