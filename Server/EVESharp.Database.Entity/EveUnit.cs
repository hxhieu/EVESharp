using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveUnits")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveUnit
{
    [Key]
    [Column("unitID", TypeName = "tinyint(3) unsigned")]
    public byte UnitId { get; set; }

    [Column("unitName")]
    [StringLength(100)]
    public string? UnitName { get; set; }

    [Column("displayName")]
    [StringLength(20)]
    public string? DisplayName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }
}
