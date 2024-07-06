using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Keyless]
[Table("roidDistribution")]
[Index("SystemSec", Name = "systemSec")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RoidDistribution
{
    [Column("systemSec")]
    [StringLength(2)]
    public string SystemSec { get; set; } = null!;

    [Column("roidID", TypeName = "int(10) unsigned")]
    public uint RoidId { get; set; }

    [Column("percent")]
    public double Percent { get; set; }
}
