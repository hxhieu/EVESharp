using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("SpawnId", "PointIndex")]
[Table("spawnBounds")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class SpawnBound
{
    [Key]
    [Column("spawnID", TypeName = "int(10) unsigned")]
    public uint SpawnId { get; set; }

    [Key]
    [Column("pointIndex", TypeName = "tinyint(3) unsigned")]
    public byte PointIndex { get; set; }

    [Column("x")]
    public double X { get; set; }

    [Column("y")]
    public double Y { get; set; }

    [Column("z")]
    public double Z { get; set; }
}
