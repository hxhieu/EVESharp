using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("spawns")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class Spawn
{
    [Key]
    [Column("spawnID", TypeName = "int(10) unsigned")]
    public uint SpawnId { get; set; }

    [Column("solarSystemID", TypeName = "int(10) unsigned")]
    public uint SolarSystemId { get; set; }

    [Column("spawnGroupID", TypeName = "int(10) unsigned")]
    public uint SpawnGroupId { get; set; }

    [Column("spawnBoundType", TypeName = "int(10) unsigned")]
    public uint SpawnBoundType { get; set; }

    [Column("spawnTimer", TypeName = "int(10) unsigned")]
    public uint SpawnTimer { get; set; }

    [Column("respawnTimeMin", TypeName = "int(10) unsigned")]
    public uint RespawnTimeMin { get; set; }

    [Column("respawnTimeMax", TypeName = "int(10) unsigned")]
    public uint RespawnTimeMax { get; set; }
}
