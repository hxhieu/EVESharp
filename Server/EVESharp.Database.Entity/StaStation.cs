using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("staStations")]
[Index("SolarSystemId", "ConstellationId", "RegionId", Name = "solarSystemID")]
[Index("ConstellationId", Name = "staStations_IX_constellation")]
[Index("CorporationId", Name = "staStations_IX_corporation")]
[Index("OperationId", Name = "staStations_IX_operation")]
[Index("RegionId", Name = "staStations_IX_region")]
[Index("SolarSystemId", Name = "staStations_IX_system")]
[Index("StationTypeId", Name = "staStations_IX_type")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class StaStation
{
    [Key]
    [Column("stationID", TypeName = "int(11)")]
    public int StationId { get; set; }

    [Column("security", TypeName = "smallint(6)")]
    public short? Security { get; set; }

    [Column("dockingCostPerVolume")]
    public double? DockingCostPerVolume { get; set; }

    [Column("maxShipVolumeDockable")]
    public double? MaxShipVolumeDockable { get; set; }

    [Column("officeRentalCost", TypeName = "int(11)")]
    public int? OfficeRentalCost { get; set; }

    [Column("operationID", TypeName = "tinyint(3) unsigned")]
    public byte? OperationId { get; set; }

    [Column("stationTypeID", TypeName = "smallint(6)")]
    public short? StationTypeId { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int? CorporationId { get; set; }

    [Column("solarSystemID", TypeName = "int(11)")]
    public int? SolarSystemId { get; set; }

    [Column("constellationID", TypeName = "int(11)")]
    public int? ConstellationId { get; set; }

    [Column("regionID", TypeName = "int(11)")]
    public int? RegionId { get; set; }

    [Column("stationName")]
    [StringLength(100)]
    public string? StationName { get; set; }

    [Column("x")]
    public double? X { get; set; }

    [Column("y")]
    public double? Y { get; set; }

    [Column("z")]
    public double? Z { get; set; }

    [Column("reprocessingEfficiency")]
    public double? ReprocessingEfficiency { get; set; }

    [Column("reprocessingStationsTake")]
    public double? ReprocessingStationsTake { get; set; }

    [Column("reprocessingHangarFlag", TypeName = "tinyint(4)")]
    public sbyte? ReprocessingHangarFlag { get; set; }
}
