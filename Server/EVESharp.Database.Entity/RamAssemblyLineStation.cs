using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("StationId", "AssemblyLineTypeId")]
[Table("ramAssemblyLineStations")]
[Index("AssemblyLineTypeId", Name = "assemblyLineTypeID")]
[Index("OwnerId", Name = "ramAssemblyLineStations_IX_owner")]
[Index("RegionId", Name = "ramAssemblyLineStations_IX_region")]
[Index("SolarSystemId", Name = "solarSystemID")]
[Index("StationTypeId", Name = "stationTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamAssemblyLineStation
{
    [Key]
    [Column("stationID", TypeName = "int(11)")]
    public int StationId { get; set; }

    [Key]
    [Column("assemblyLineTypeID", TypeName = "tinyint(3) unsigned")]
    public byte AssemblyLineTypeId { get; set; }

    [Column("quantity", TypeName = "tinyint(4)")]
    public sbyte? Quantity { get; set; }

    [Column("stationTypeID", TypeName = "smallint(6)")]
    public short? StationTypeId { get; set; }

    [Column("ownerID", TypeName = "int(11)")]
    public int? OwnerId { get; set; }

    [Column("solarSystemID", TypeName = "int(11)")]
    public int? SolarSystemId { get; set; }

    [Column("regionID", TypeName = "int(11)")]
    public int? RegionId { get; set; }
}
