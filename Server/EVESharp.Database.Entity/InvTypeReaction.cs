using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("ReactionTypeId", "Input", "TypeId")]
[Table("invTypeReactions")]
[Index("TypeId", Name = "typeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvTypeReaction
{
    [Key]
    [Column("reactionTypeID", TypeName = "smallint(6)")]
    public short ReactionTypeId { get; set; }

    [Key]
    [Column("input")]
    public bool Input { get; set; }

    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }

    [Column("quantity", TypeName = "smallint(6)")]
    public short? Quantity { get; set; }
}
