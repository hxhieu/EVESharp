using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("ramAssemblyLineStationCostLogs")]
[Index("StationId", Name = "stationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamAssemblyLineStationCostLog
{
    [Key]
    [Column("assemblyLineTypeID", TypeName = "int(11)")]
    public int AssemblyLineTypeId { get; set; }

    [Column("stationID", TypeName = "int(11)")]
    public int StationId { get; set; }

    [Column("logDateTime")]
    [StringLength(20)]
    public string LogDateTime { get; set; } = null!;

    [Column("_usage")]
    public double Usage { get; set; }

    [Column("costPerHour")]
    public float CostPerHour { get; set; }
}
