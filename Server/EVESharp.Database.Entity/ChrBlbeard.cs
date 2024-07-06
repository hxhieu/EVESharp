using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("BloodlineId", "Gender", "BeardId")]
[Table("chrBLBeards")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrBlbeard
{
    [Key]
    [Column("bloodlineID", TypeName = "int(10) unsigned")]
    public uint BloodlineId { get; set; }

    [Key]
    [Column("gender", TypeName = "int(10) unsigned")]
    public uint Gender { get; set; }

    [Key]
    [Column("beardID", TypeName = "int(10) unsigned")]
    public uint BeardId { get; set; }

    [Column("npc", TypeName = "int(10) unsigned")]
    public uint Npc { get; set; }
}
