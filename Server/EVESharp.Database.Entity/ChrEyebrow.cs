using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrEyebrows")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrEyebrow
{
    [Key]
    [Column("eyebrowsID", TypeName = "int(10) unsigned")]
    public uint EyebrowsId { get; set; }

    [Column("eyebrowsName")]
    [StringLength(100)]
    public string EyebrowsName { get; set; } = null!;
}
