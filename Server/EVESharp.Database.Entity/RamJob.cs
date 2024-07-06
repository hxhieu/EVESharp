using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("ramJobs")]
[Index("AssemblyLineId", Name = "RAMJOBS_ASSEMBLYLINES")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamJob
{
    [Key]
    [Column("jobID", TypeName = "int(10) unsigned")]
    public uint JobId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("installerID", TypeName = "int(10) unsigned")]
    public uint InstallerId { get; set; }

    [Column("assemblyLineID", TypeName = "int(10) unsigned")]
    public uint AssemblyLineId { get; set; }

    [Column("installedItemID", TypeName = "int(10) unsigned")]
    public uint InstalledItemId { get; set; }

    [Column("installTime", TypeName = "bigint(20) unsigned")]
    public ulong InstallTime { get; set; }

    [Column("beginProductionTime", TypeName = "bigint(20) unsigned")]
    public ulong BeginProductionTime { get; set; }

    [Column("pauseProductionTime", TypeName = "bigint(20) unsigned")]
    public ulong? PauseProductionTime { get; set; }

    [Column("endProductionTime", TypeName = "bigint(20) unsigned")]
    public ulong EndProductionTime { get; set; }

    [Column("description")]
    [StringLength(250)]
    public string Description { get; set; } = null!;

    [Column("runs", TypeName = "int(10) unsigned")]
    public uint Runs { get; set; }

    [Column("outputFlag", TypeName = "int(10) unsigned")]
    public uint OutputFlag { get; set; }

    [Column("completedStatusID", TypeName = "int(10) unsigned")]
    public uint CompletedStatusId { get; set; }

    [Column("installedInSolarSystemID", TypeName = "int(10) unsigned")]
    public uint InstalledInSolarSystemId { get; set; }

    [Column("licensedProductionRuns", TypeName = "int(10)")]
    public int? LicensedProductionRuns { get; set; }
}
