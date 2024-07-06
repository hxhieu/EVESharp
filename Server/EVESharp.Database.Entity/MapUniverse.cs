using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapUniverse")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapUniverse
{
    [Key]
    [Column("universeID", TypeName = "int(11)")]
    public int UniverseId { get; set; }

    [Column("universeName")]
    [StringLength(100)]
    public string? UniverseName { get; set; }

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

    [Column("radius")]
    public double? Radius { get; set; }
}
