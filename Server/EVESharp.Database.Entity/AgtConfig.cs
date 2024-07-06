using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("AgentId", "K")]
[Table("agtConfig")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtConfig
{
    [Key]
    [Column("agentID", TypeName = "int(11)")]
    public int AgentId { get; set; }

    [Key]
    [Column("k")]
    [StringLength(50)]
    public string K { get; set; } = null!;

    [Column("v")]
    [StringLength(4000)]
    public string? V { get; set; }
}
