using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("dgmAttributeTypes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class DgmAttributeType
{
    [Key]
    [Column("attributeID", TypeName = "int(10) unsigned")]
    public uint AttributeId { get; set; }

    [Column("attributeName")]
    [StringLength(100)]
    public string? AttributeName { get; set; }

    [Column("attributeCategory", TypeName = "int(10) unsigned")]
    public uint? AttributeCategory { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("maxAttributeID", TypeName = "int(10) unsigned")]
    public uint? MaxAttributeId { get; set; }

    [Column("attributeIdx", TypeName = "int(10) unsigned")]
    public uint? AttributeIdx { get; set; }

    [Column("graphicID", TypeName = "int(10) unsigned")]
    public uint? GraphicId { get; set; }

    [Column("chargeRechargeTimeID", TypeName = "int(10) unsigned")]
    public uint? ChargeRechargeTimeId { get; set; }

    [Column("defaultValue")]
    public double? DefaultValue { get; set; }

    [Column("published", TypeName = "int(10) unsigned")]
    public uint? Published { get; set; }

    [Column("displayName")]
    [StringLength(100)]
    public string? DisplayName { get; set; }

    [Column("unitID", TypeName = "int(10) unsigned")]
    public uint? UnitId { get; set; }

    [Column("stackable", TypeName = "int(10) unsigned")]
    public uint? Stackable { get; set; }

    [Column("highIsGood", TypeName = "int(10) unsigned")]
    public uint? HighIsGood { get; set; }

    [Column("categoryID", TypeName = "int(10) unsigned")]
    public uint? CategoryId { get; set; }
}
