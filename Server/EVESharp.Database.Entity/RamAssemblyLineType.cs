using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("ramAssemblyLineTypes")]
[Index("ActivityId", Name = "activityID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamAssemblyLineType
{
    [Key]
    [Column("assemblyLineTypeID", TypeName = "tinyint(3) unsigned")]
    public byte AssemblyLineTypeId { get; set; }

    [Column("assemblyLineTypeName")]
    [StringLength(100)]
    public string? AssemblyLineTypeName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("baseTimeMultiplier")]
    public double? BaseTimeMultiplier { get; set; }

    [Column("baseMaterialMultiplier")]
    public double? BaseMaterialMultiplier { get; set; }

    [Column("volume")]
    public double? Volume { get; set; }

    [Column("activityID", TypeName = "tinyint(3) unsigned")]
    public byte? ActivityId { get; set; }

    [Column("minCostPerHour")]
    public double? MinCostPerHour { get; set; }
}
