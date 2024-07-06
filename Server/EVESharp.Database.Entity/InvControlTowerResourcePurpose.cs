using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invControlTowerResourcePurposes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvControlTowerResourcePurpose
{
    [Key]
    [Column("purpose", TypeName = "tinyint(4)")]
    public sbyte Purpose { get; set; }

    [Column("purposeText")]
    [StringLength(100)]
    public string? PurposeText { get; set; }
}
