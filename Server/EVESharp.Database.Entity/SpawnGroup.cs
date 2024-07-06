using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("spawnGroups")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class SpawnGroup
{
    [Key]
    [Column("spawnGroupID", TypeName = "int(10) unsigned")]
    public uint SpawnGroupId { get; set; }

    [Column("spawnGroupName")]
    [StringLength(85)]
    public string SpawnGroupName { get; set; } = null!;

    [Column("formation", TypeName = "int(10) unsigned")]
    public uint Formation { get; set; }
}
