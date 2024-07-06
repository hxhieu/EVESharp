using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrDecos")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrDeco
{
    [Key]
    [Column("decoID", TypeName = "int(10) unsigned")]
    public uint DecoId { get; set; }

    [Column("decoName")]
    [StringLength(100)]
    public string DecoName { get; set; } = null!;
}
