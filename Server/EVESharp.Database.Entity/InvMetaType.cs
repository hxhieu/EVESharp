using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invMetaTypes")]
[Index("MetaGroupId", Name = "metaGroupID")]
[Index("ParentTypeId", Name = "parentTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvMetaType
{
    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }

    [Column("parentTypeID", TypeName = "smallint(6)")]
    public short? ParentTypeId { get; set; }

    [Column("metaGroupID", TypeName = "smallint(6)")]
    public short? MetaGroupId { get; set; }
}
