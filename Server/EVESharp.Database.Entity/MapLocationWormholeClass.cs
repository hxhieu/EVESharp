using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapLocationWormholeClasses")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapLocationWormholeClass
{
    [Key]
    [Column("locationID", TypeName = "int(10) unsigned")]
    public uint LocationId { get; set; }

    [Column("wormholeClassID", TypeName = "int(10) unsigned")]
    public uint WormholeClassId { get; set; }
}
