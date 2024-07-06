using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrEyes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrEye
{
    [Key]
    [Column("eyesID", TypeName = "int(10) unsigned")]
    public uint EyesId { get; set; }

    [Column("eyesName")]
    [StringLength(100)]
    public string EyesName { get; set; } = null!;
}
