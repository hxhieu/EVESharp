using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("TypeId", "EffectId")]
[Table("dgmTypeEffects")]
[Index("EffectId", Name = "effectID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class DgmTypeEffect
{
    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }

    [Key]
    [Column("effectID", TypeName = "smallint(6)")]
    public short EffectId { get; set; }

    [Column("isDefault")]
    public bool? IsDefault { get; set; }
}
