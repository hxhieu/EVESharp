using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mapCelestialDescriptions")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MapCelestialDescription
{
    [Key]
    [Column("celestialID", TypeName = "int(11) unsigned")]
    public uint CelestialId { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }
}
