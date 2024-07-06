using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrBeards")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrBeard
{
    [Key]
    [Column("beardID", TypeName = "int(10) unsigned")]
    public uint BeardId { get; set; }

    [Column("beardName")]
    [StringLength(100)]
    public string BeardName { get; set; } = null!;
}
