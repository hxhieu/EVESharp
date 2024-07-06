using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invMarketGroups")]
[Index("GraphicId", Name = "graphicID")]
[Index("ParentGroupId", Name = "parentGroupID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvMarketGroup
{
    [Key]
    [Column("marketGroupID", TypeName = "smallint(6)")]
    public short MarketGroupId { get; set; }

    [Column("parentGroupID", TypeName = "smallint(6)")]
    public short? ParentGroupId { get; set; }

    [Column("marketGroupName")]
    [StringLength(100)]
    public string? MarketGroupName { get; set; }

    [Column("description")]
    [StringLength(3000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("hasTypes")]
    public bool? HasTypes { get; set; }
}
