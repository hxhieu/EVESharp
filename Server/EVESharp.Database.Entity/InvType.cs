using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invTypes")]
[Index("GraphicId", Name = "graphicID")]
[Index("GroupId", Name = "invTypes_IX_Group")]
[Index("MarketGroupId", Name = "marketGroupID")]
[Index("RaceId", Name = "raceID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvType
{
    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }

    [Column("groupID", TypeName = "smallint(6)")]
    public short? GroupId { get; set; }

    [Column("typeName")]
    [StringLength(100)]
    public string? TypeName { get; set; }

    [Column("description")]
    [StringLength(3000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("radius")]
    public double? Radius { get; set; }

    [Column("mass")]
    public double? Mass { get; set; }

    [Column("volume")]
    public double? Volume { get; set; }

    [Column("capacity")]
    public double? Capacity { get; set; }

    [Column("portionSize", TypeName = "int(11)")]
    public int? PortionSize { get; set; }

    [Column("raceID", TypeName = "tinyint(3) unsigned")]
    public byte? RaceId { get; set; }

    [Column("basePrice")]
    public double? BasePrice { get; set; }

    [Column("published")]
    public bool? Published { get; set; }

    [Column("marketGroupID", TypeName = "smallint(6)")]
    public short? MarketGroupId { get; set; }

    [Column("chanceOfDuplicating")]
    public double? ChanceOfDuplicating { get; set; }

    [Column("dataID", TypeName = "int(10) unsigned")]
    public uint DataId { get; set; }
}
