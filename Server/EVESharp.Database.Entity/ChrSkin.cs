using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrSkins")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrSkin
{
    [Key]
    [Column("skinID", TypeName = "int(10) unsigned")]
    public uint SkinId { get; set; }

    [Column("skinName")]
    [StringLength(100)]
    public string SkinName { get; set; } = null!;
}
