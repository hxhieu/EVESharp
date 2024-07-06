using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("SkillId", "CorporationId")]
[Table("crpNPCCorporationResearchFields")]
[Index("CorporationId", Name = "corporationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpNpccorporationResearchField
{
    [Key]
    [Column("skillID", TypeName = "smallint(6)")]
    public short SkillId { get; set; }

    [Key]
    [Column("corporationID", TypeName = "int(11)")]
    public int CorporationId { get; set; }
}
