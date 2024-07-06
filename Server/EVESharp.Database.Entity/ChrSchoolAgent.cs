using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("SchoolId", "AgentIndex")]
[Table("chrSchoolAgents")]
[Index("AgentId", Name = "agentID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrSchoolAgent
{
    [Key]
    [Column("schoolID", TypeName = "tinyint(3) unsigned")]
    public byte SchoolId { get; set; }

    [Key]
    [Column("agentIndex", TypeName = "tinyint(4)")]
    public sbyte AgentIndex { get; set; }

    [Column("agentID", TypeName = "int(11)")]
    public int? AgentId { get; set; }
}
