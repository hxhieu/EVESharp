using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapRegions")]
[Index("FactionId", Name = "factionID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapRegion
{
    [Key]
    [Column("regionID", TypeName = "int(11)")]
    public int RegionId { get; set; }

    [Column("regionName")]
    [StringLength(100)]
    public string? RegionName { get; set; }

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
