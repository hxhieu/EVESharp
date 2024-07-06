using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FromId", "ToId")]
[Table("npcStandings")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class NpcStanding
{
    [Key]
    [Column("fromID", TypeName = "int(10) unsigned")]
    public uint FromId { get; set; }

    [Key]
    [Column("toID", TypeName = "int(10) unsigned")]
    public uint ToId { get; set; }

    [Column("standing")]
    public double Standing { get; set; }
}
