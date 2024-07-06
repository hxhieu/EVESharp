using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapSolarSystems")]
[Index("FactionId", Name = "factionID")]
[Index("ConstellationId", Name = "mapSolarSystems_IX_constellation")]
[Index("RegionId", Name = "mapSolarSystems_IX_region")]
[Index("Security", Name = "mapSolarSystems_IX_security")]
[Index("SolarSystemId", "ConstellationId", "RegionId", Name = "solarSystemID", IsUnique = true)]
[Index("SunTypeId", Name = "sunTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapSolarSystem
{
    [Column("regionID", TypeName = "int(11)")]
    public int? RegionId { get; set; }

    [Column("constellationID", TypeName = "int(11)")]
    public int? ConstellationId { get; set; }

    [Key]
    [Column("solarSystemID", TypeName = "int(11)")]
    public int SolarSystemId { get; set; }

    [Column("solarSystemName")]
    [StringLength(100)]
    public string? SolarSystemName { get; set; }

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

    [Column("luminosity")]
    public double? Luminosity { get; set; }

    [Column("border")]
    public bool? Border { get; set; }

    [Column("fringe")]
    public bool? Fringe { get; set; }

    [Column("corridor")]
    public bool? Corridor { get; set; }

    [Column("hub")]
    public bool? Hub { get; set; }

    [Column("international")]
    public bool? International { get; set; }

    [Column("regional")]
    public bool? Regional { get; set; }

    [Column("constellation")]
    public bool? Constellation { get; set; }

    [Column("security")]
    public double? Security { get; set; }

    [Column("factionID", TypeName = "int(11)")]
    public int? FactionId { get; set; }

    [Column("radius")]
    public double? Radius { get; set; }

    [Column("sunTypeID", TypeName = "smallint(6)")]
    public short? SunTypeId { get; set; }

    [Column("securityClass")]
    [StringLength(2)]
    public string? SecurityClass { get; set; }
}
