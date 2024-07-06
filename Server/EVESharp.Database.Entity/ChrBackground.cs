using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrBackgrounds")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrBackground
{
    [Key]
    [Column("backgroundID", TypeName = "int(10) unsigned")]
    public uint BackgroundId { get; set; }

    [Column("backgroundName")]
    [StringLength(100)]
    public string BackgroundName { get; set; } = null!;
}
