using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FromSolarSystemId", "ToSolarSystemId")]
[Table("mapSolarSystemJumps")]
[Index("FromSolarSystemId", "FromConstellationId", "FromRegionId", Name = "fromSolarSystemID")]
[Index("FromConstellationId", Name = "mapSolarSystemJumps_IX_fromConstellation")]
[Index("FromRegionId", Name = "mapSolarSystemJumps_IX_fromRegion")]
[Index("ToSolarSystemId", "ToConstellationId", "ToRegionId", Name = "toSolarSystemID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapSolarSystemJump
{
    [Column("fromRegionID", TypeName = "int(11)")]
    public int? FromRegionId { get; set; }

    [Column("fromConstellationID", TypeName = "int(11)")]
    public int? FromConstellationId { get; set; }

    [Key]
    [Column("fromSolarSystemID", TypeName = "int(11)")]
    public int FromSolarSystemId { get; set; }

    [Key]
    [Column("toSolarSystemID", TypeName = "int(11)")]
    public int ToSolarSystemId { get; set; }

    [Column("toConstellationID", TypeName = "int(11)")]
    public int? ToConstellationId { get; set; }

    [Column("toRegionID", TypeName = "int(11)")]
    public int? ToRegionId { get; set; }
}
