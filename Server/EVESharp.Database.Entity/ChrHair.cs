using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrHairs")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrHair
{
    [Key]
    [Column("hairID", TypeName = "int(10) unsigned")]
    public uint HairId { get; set; }

    [Column("hairName")]
    [StringLength(100)]
    public string HairName { get; set; } = null!;
}
