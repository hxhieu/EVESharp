using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("TypeId", "AttributeId")]
[Table("dgmTypeAttributes")]
[Index("AttributeId", Name = "attributeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class DgmTypeAttribute
{
    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }

    [Key]
    [Column("attributeID", TypeName = "smallint(6)")]
    public short AttributeId { get; set; }

    [Column("valueInt", TypeName = "int(11)")]
    public int? ValueInt { get; set; }

    [Column("valueFloat")]
    public double? ValueFloat { get; set; }
}
