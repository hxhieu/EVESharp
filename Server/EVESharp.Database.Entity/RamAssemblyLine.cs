using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("ramAssemblyLines")]
[Index("ActivityId", Name = "activityID")]
[Index("AssemblyLineTypeId", Name = "assemblyLineTypeID")]
[Index("ContainerId", Name = "ramAssemblyLines_IX_container")]
[Index("OwnerId", Name = "ramAssemblyLines_IX_owner")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamAssemblyLine
{
    [Key]
    [Column("assemblyLineID", TypeName = "int(11)")]
    public int AssemblyLineId { get; set; }

    [Column("assemblyLineTypeID", TypeName = "tinyint(3) unsigned")]
    public byte? AssemblyLineTypeId { get; set; }

    [Column("containerID", TypeName = "int(11)")]
    public int? ContainerId { get; set; }

    [Column("nextFreeTime", TypeName = "bigint(20)")]
    public long? NextFreeTime { get; set; }

    [Column("UIGroupingID", TypeName = "tinyint(3) unsigned")]
    public byte? UigroupingId { get; set; }

    [Column("costInstall")]
    public double? CostInstall { get; set; }

    [Column("costPerHour")]
    public double? CostPerHour { get; set; }

    [Column("restrictionMask", TypeName = "tinyint(4)")]
    public sbyte? RestrictionMask { get; set; }

    [Column("discountPerGoodStandingPoint")]
    public double? DiscountPerGoodStandingPoint { get; set; }

    [Column("surchargePerBadStandingPoint")]
    public double? SurchargePerBadStandingPoint { get; set; }

    [Column("minimumStanding")]
    public double? MinimumStanding { get; set; }

    [Column("minimumCharSecurity")]
    public double? MinimumCharSecurity { get; set; }

    [Column("minimumCorpSecurity")]
    public double? MinimumCorpSecurity { get; set; }

    [Column("maximumCharSecurity")]
    public double? MaximumCharSecurity { get; set; }

    [Column("maximumCorpSecurity")]
    public double? MaximumCorpSecurity { get; set; }

    [Column("ownerID", TypeName = "int(11)")]
    public int? OwnerId { get; set; }

    [Column("activityID", TypeName = "tinyint(3) unsigned")]
    public byte? ActivityId { get; set; }
}
