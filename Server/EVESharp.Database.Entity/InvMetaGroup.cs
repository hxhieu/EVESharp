using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invMetaGroups")]
[Index("GraphicId", Name = "graphicID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvMetaGroup
{
    [Key]
    [Column("metaGroupID", TypeName = "smallint(6)")]
    public short MetaGroupId { get; set; }

    [Column("metaGroupName")]
    [StringLength(100)]
    public string? MetaGroupName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }
}
