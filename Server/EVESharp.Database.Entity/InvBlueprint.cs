using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invBlueprints")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvBlueprint
{
    [Key]
    [Column("itemID", TypeName = "int(10) unsigned")]
    public uint ItemId { get; set; }

    [Column("copy", TypeName = "tinyint(1) unsigned")]
    public byte Copy { get; set; }

    [Column("materialLevel", TypeName = "int(10) unsigned")]
    public uint MaterialLevel { get; set; }

    [Column("productivityLevel", TypeName = "int(10) unsigned")]
    public uint ProductivityLevel { get; set; }

    [Column("licensedProductionRunsRemaining", TypeName = "int(10)")]
    public int LicensedProductionRunsRemaining { get; set; }
}
