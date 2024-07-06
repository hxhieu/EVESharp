using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("cacheLocations")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CacheLocation
{
    [Key]
    [Column("locationID", TypeName = "int(10) unsigned")]
    public uint LocationId { get; set; }

    [Column("locationName")]
    [StringLength(100)]
    public string LocationName { get; set; } = null!;

    [Column("x")]
    public double X { get; set; }

    [Column("y")]
    public double Y { get; set; }

    [Column("z")]
    public double Z { get; set; }
}
