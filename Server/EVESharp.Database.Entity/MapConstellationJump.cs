using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FromConstellationId", "ToConstellationId")]
[Table("mapConstellationJumps")]
[Index("FromConstellationId", "FromRegionId", Name = "fromConstellationID")]
[Index("FromRegionId", Name = "mapConstellationJumps_IX_fromRegion")]
[Index("ToConstellationId", "ToRegionId", Name = "toConstellationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapConstellationJump
{
    [Column("fromRegionID", TypeName = "int(11)")]
    public int? FromRegionId { get; set; }

    [Key]
    [Column("fromConstellationID", TypeName = "int(11)")]
    public int FromConstellationId { get; set; }

    [Key]
    [Column("toConstellationID", TypeName = "int(11)")]
    public int ToConstellationId { get; set; }

    [Column("toRegionID", TypeName = "int(11)")]
    public int? ToRegionId { get; set; }
}
