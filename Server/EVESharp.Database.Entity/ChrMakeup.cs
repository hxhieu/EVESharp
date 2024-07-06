using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrMakeups")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrMakeup
{
    [Key]
    [Column("makeupID", TypeName = "int(10) unsigned")]
    public uint MakeupId { get; set; }

    [Column("makeupName")]
    [StringLength(100)]
    public string MakeupName { get; set; } = null!;
}
