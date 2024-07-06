using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapLandmarks")]
[Index("GraphicId", Name = "graphicID")]
[Index("LocationId", Name = "locationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapLandmark
{
    [Key]
    [Column("landmarkID", TypeName = "smallint(6)")]
    public short LandmarkId { get; set; }

    [Column("landmarkName")]
    [StringLength(100)]
    public string? LandmarkName { get; set; }

    [Column("description")]
    [StringLength(7000)]
    public string? Description { get; set; }

    [Column("locationID", TypeName = "int(11)")]
    public int? LocationId { get; set; }

    [Column("x")]
    public double? X { get; set; }

    [Column("y")]
    public double? Y { get; set; }

    [Column("z")]
    public double? Z { get; set; }

    [Column("radius")]
    public double? Radius { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("importance", TypeName = "tinyint(4)")]
    public sbyte? Importance { get; set; }

    [Column("url2d")]
    [StringLength(255)]
    public string? Url2d { get; set; }
}
