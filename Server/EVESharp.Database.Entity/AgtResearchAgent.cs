using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("AgentId", "TypeId")]
[Table("agtResearchAgents")]
[Index("TypeId", Name = "agtResearchAgents_IX_type")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtResearchAgent
{
    [Key]
    [Column("agentID", TypeName = "int(11)")]
    public int AgentId { get; set; }

    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }
}
