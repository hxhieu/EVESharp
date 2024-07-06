using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("MedalId", "Index")]
[Table("crpMedalParts")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpMedalPart
{
    [Key]
    [Column("medalID", TypeName = "int(11)")]
    public int MedalId { get; set; }

    [Key]
    [Column("index", TypeName = "int(11)")]
    public int Index { get; set; }

    [Column("part", TypeName = "int(11)")]
    public int Part { get; set; }

    [Column("graphic")]
    [StringLength(50)]
    public string? Graphic { get; set; }

    [Column("color", TypeName = "int(11)")]
    public int? Color { get; set; }
}
