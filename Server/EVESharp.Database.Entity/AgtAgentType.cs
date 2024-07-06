using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("agtAgentTypes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtAgentType
{
    [Key]
    [Column("agentTypeID", TypeName = "tinyint(3) unsigned")]
    public byte AgentTypeId { get; set; }

    [Column("agentType")]
    [StringLength(50)]
    public string? AgentType { get; set; }
}
