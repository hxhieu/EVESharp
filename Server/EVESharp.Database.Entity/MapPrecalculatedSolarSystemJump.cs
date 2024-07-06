using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FromSolarSystemId", "ToSolarSystemId")]
[Table("mapPrecalculatedSolarSystemJumps")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapPrecalculatedSolarSystemJump
{
    [Key]
    [Column("fromSolarSystemID", TypeName = "int(11)")]
    public int FromSolarSystemId { get; set; }

    [Key]
    [Column("toSolarSystemID", TypeName = "int(11)")]
    public int ToSolarSystemId { get; set; }

    [Column("jumps", TypeName = "int(11)")]
    public int? Jumps { get; set; }
}
