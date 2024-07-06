using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapDenormalize")]
[Index("ConstellationId", Name = "mapDenormalize_IX_constellation")]
[Index("GroupId", "ConstellationId", Name = "mapDenormalize_IX_groupConstellation")]
[Index("GroupId", "RegionId", Name = "mapDenormalize_IX_groupRegion")]
[Index("GroupId", "SolarSystemId", Name = "mapDenormalize_IX_groupSystem")]
[Index("OrbitId", Name = "mapDenormalize_IX_orbit")]
[Index("RegionId", Name = "mapDenormalize_IX_region")]
[Index("SolarSystemId", Name = "mapDenormalize_IX_system")]
[Index("TypeId", Name = "typeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapDenormalize
{
    [Key]
    [Column("itemID", TypeName = "int(11)")]
    public int ItemId { get; set; }

    [Column("typeID", TypeName = "smallint(6)")]
    public short? TypeId { get; set; }

    [Column("groupID", TypeName = "smallint(6)")]
    public short? GroupId { get; set; }

    [Column("solarSystemID", TypeName = "int(11)")]
    public int? SolarSystemId { get; set; }

    [Column("constellationID", TypeName = "int(11)")]
    public int? ConstellationId { get; set; }

    [Column("regionID", TypeName = "int(11)")]
    public int? RegionId { get; set; }

    [Column("orbitID", TypeName = "int(11)")]
    public int? OrbitId { get; set; }

    [Column("x")]
    public double? X { get; set; }

    [Column("y")]
    public double? Y { get; set; }

    [Column("z")]
    public double? Z { get; set; }

    [Column("radius")]
    public double? Radius { get; set; }

    [Column("itemName")]
    [StringLength(100)]
    public string? ItemName { get; set; }

    [Column("security")]
    public double? Security { get; set; }

    [Column("celestialIndex", TypeName = "tinyint(4)")]
    public sbyte? CelestialIndex { get; set; }

    [Column("orbitIndex", TypeName = "tinyint(4)")]
    public sbyte? OrbitIndex { get; set; }
}
