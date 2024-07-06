using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrBloodlines")]
[Index("CorporationId", Name = "corporationID")]
[Index("GraphicId", Name = "graphicID")]
[Index("RaceId", Name = "raceID")]
[Index("ShipTypeId", Name = "shipTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrBloodline
{
    [Key]
    [Column("bloodlineID", TypeName = "tinyint(3) unsigned")]
    public byte BloodlineId { get; set; }

    [Column("bloodlineName")]
    [StringLength(100)]
    public string? BloodlineName { get; set; }

    [Column("raceID", TypeName = "tinyint(3) unsigned")]
    public byte? RaceId { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("maleDescription")]
    [StringLength(1000)]
    public string? MaleDescription { get; set; }

    [Column("femaleDescription")]
    [StringLength(1000)]
    public string? FemaleDescription { get; set; }

    [Column("shipTypeID", TypeName = "smallint(6)")]
    public short? ShipTypeId { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int? CorporationId { get; set; }

    [Column("perception", TypeName = "tinyint(4)")]
    public sbyte? Perception { get; set; }

    [Column("willpower", TypeName = "tinyint(4)")]
    public sbyte? Willpower { get; set; }

    [Column("charisma", TypeName = "tinyint(4)")]
    public sbyte? Charisma { get; set; }

    [Column("memory", TypeName = "tinyint(4)")]
    public sbyte? Memory { get; set; }

    [Column("intelligence", TypeName = "tinyint(4)")]
    public sbyte? Intelligence { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("shortDescription")]
    [StringLength(500)]
    public string? ShortDescription { get; set; }

    [Column("shortMaleDescription")]
    [StringLength(500)]
    public string? ShortMaleDescription { get; set; }

    [Column("shortFemaleDescription")]
    [StringLength(500)]
    public string? ShortFemaleDescription { get; set; }

    [Column("dataID", TypeName = "int(10) unsigned")]
    public uint DataId { get; set; }
}
