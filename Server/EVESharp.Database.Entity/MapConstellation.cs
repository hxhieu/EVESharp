using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapConstellations")]
[Index("ConstellationId", "RegionId", Name = "constellationID", IsUnique = true)]
[Index("FactionId", Name = "factionID")]
[Index("RegionId", Name = "mapConstellations_IX_region")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapConstellation
{
    [Column("regionID", TypeName = "int(11)")]
    public int? RegionId { get; set; }

    [Key]
    [Column("constellationID", TypeName = "int(11)")]
    public int ConstellationId { get; set; }

    [Column("constellationName")]
    [StringLength(100)]
    public string? ConstellationName { get; set; }

    [Column("x")]
    public double? X { get; set; }

    [Column("y")]
    public double? Y { get; set; }

    [Column("z")]
    public double? Z { get; set; }

    [Column("xMin")]
    public double? XMin { get; set; }

    [Column("xMax")]
    public double? XMax { get; set; }

    [Column("yMin")]
    public double? YMin { get; set; }

    [Column("yMax")]
    public double? YMax { get; set; }

    [Column("zMin")]
    public double? ZMin { get; set; }

    [Column("zMax")]
    public double? ZMax { get; set; }

    [Column("factionID", TypeName = "int(11)")]
    public int? FactionId { get; set; }

    [Column("radius")]
    public double? Radius { get; set; }
}
