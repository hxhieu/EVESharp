using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FromRegionId", "ToRegionId")]
[Table("mapRegionJumps")]
[Index("ToRegionId", Name = "toRegionID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapRegionJump
{
    [Key]
    [Column("fromRegionID", TypeName = "int(11)")]
    public int FromRegionId { get; set; }

    [Key]
    [Column("toRegionID", TypeName = "int(11)")]
    public int ToRegionId { get; set; }
}
