using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapCelestialStatistics")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapCelestialStatistic
{
    [Key]
    [Column("celestialID", TypeName = "int(11)")]
    public int CelestialId { get; set; }

    [Column("temperature")]
    public double? Temperature { get; set; }

    [Column("spectralClass")]
    [StringLength(10)]
    public string? SpectralClass { get; set; }

    [Column("luminosity")]
    public double? Luminosity { get; set; }

    [Column("age")]
    public double? Age { get; set; }

    [Column("life")]
    public double? Life { get; set; }

    [Column("orbitRadius")]
    public double? OrbitRadius { get; set; }

    [Column("eccentricity")]
    public double? Eccentricity { get; set; }

    [Column("massDust")]
    public double? MassDust { get; set; }

    [Column("massGas")]
    public double? MassGas { get; set; }

    [Column("fragmented")]
    public bool? Fragmented { get; set; }

    [Column("density")]
    public double? Density { get; set; }

    [Column("surfaceGravity")]
    public double? SurfaceGravity { get; set; }

    [Column("escapeVelocity")]
    public double? EscapeVelocity { get; set; }

    [Column("orbitPeriod")]
    public double? OrbitPeriod { get; set; }

    [Column("rotationRate")]
    public double? RotationRate { get; set; }

    [Column("locked")]
    public bool? Locked { get; set; }

    [Column("pressure")]
    public double? Pressure { get; set; }

    [Column("radius")]
    public double? Radius { get; set; }

    [Column("mass")]
    public double? Mass { get; set; }
}
