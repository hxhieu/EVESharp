using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("SpawnGroupId", "NpcTypeId")]
[Table("spawnGroupEntries")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class SpawnGroupEntry
{
    [Key]
    [Column("spawnGroupID", TypeName = "int(10) unsigned")]
    public uint SpawnGroupId { get; set; }

    [Key]
    [Column("npcTypeID", TypeName = "int(10) unsigned")]
    public uint NpcTypeId { get; set; }

    [Column("quantity", TypeName = "tinyint(3) unsigned")]
    public byte Quantity { get; set; }

    [Column("probability")]
    public float Probability { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }
}
