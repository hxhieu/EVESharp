using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapJumps")]
[Index("CelestialId", Name = "celestialID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapJump
{
    [Key]
    [Column("stargateID", TypeName = "int(11)")]
    public int StargateId { get; set; }

    [Column("celestialID", TypeName = "int(11)")]
    public int? CelestialId { get; set; }
}
