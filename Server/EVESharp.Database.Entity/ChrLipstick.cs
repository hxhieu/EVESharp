using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrLipsticks")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrLipstick
{
    [Key]
    [Column("lipstickID", TypeName = "int(10) unsigned")]
    public uint LipstickId { get; set; }

    [Column("lipstickName")]
    [StringLength(100)]
    public string LipstickName { get; set; } = null!;
}
