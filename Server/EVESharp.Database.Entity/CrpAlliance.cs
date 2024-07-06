using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpAlliances")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpAlliance
{
    [Key]
    [Column("allianceID", TypeName = "int(11)")]
    public int AllianceId { get; set; }

    [Column("shortName")]
    [StringLength(50)]
    public string ShortName { get; set; } = null!;

    [Column("description", TypeName = "mediumtext")]
    public string Description { get; set; } = null!;

    [Column("url")]
    [StringLength(255)]
    public string Url { get; set; } = null!;

    [Column("executorCorpID", TypeName = "int(11)")]
    public int? ExecutorCorpId { get; set; }

    [Column("creatorCorpID", TypeName = "int(11)")]
    public int CreatorCorpId { get; set; }

    [Column("creatorCharID", TypeName = "int(11)")]
    public int CreatorCharId { get; set; }

    [Column("dictatorial", TypeName = "tinyint(4)")]
    public sbyte Dictatorial { get; set; }

    [Column("startDate", TypeName = "bigint(20)")]
    public long StartDate { get; set; }

    [Column("deleted", TypeName = "tinyint(4)")]
    public sbyte Deleted { get; set; }
}
