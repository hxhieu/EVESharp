using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrBLLights")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrBllight
{
    [Key]
    [Column("lightID", TypeName = "int(10) unsigned")]
    public uint LightId { get; set; }

    [Column("lightName")]
    [StringLength(100)]
    public string LightName { get; set; } = null!;
}
