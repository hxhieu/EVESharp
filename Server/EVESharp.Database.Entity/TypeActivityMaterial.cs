using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("TypeId", "ActivityId", "RequiredTypeId")]
[Table("typeActivityMaterials")]
[Index("RequiredTypeId", Name = "requiredTypeID")]
[Index("ActivityId", Name = "typeActivityMaterials_IX_activity")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TypeActivityMaterial
{
    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }

    [Key]
    [Column("activityID", TypeName = "tinyint(3) unsigned")]
    public byte ActivityId { get; set; }

    [Key]
    [Column("requiredTypeID", TypeName = "smallint(6)")]
    public short RequiredTypeId { get; set; }

    [Column("quantity", TypeName = "int(11)")]
    public int? Quantity { get; set; }

    [Column("damagePerJob")]
    public double? DamagePerJob { get; set; }

    [Column("recycle")]
    public bool? Recycle { get; set; }
}
