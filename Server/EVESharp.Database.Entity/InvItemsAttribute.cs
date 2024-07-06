using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("ItemId", "AttributeId")]
[Table("invItemsAttributes")]
[Index("AttributeId", Name = "attributeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvItemsAttribute
{
    [Key]
    [Column("itemID", TypeName = "int(10) unsigned")]
    public uint ItemId { get; set; }

    [Key]
    [Column("attributeID", TypeName = "int(10) unsigned")]
    public uint AttributeId { get; set; }

    [Column("valueInt", TypeName = "bigint(20) unsigned")]
    public ulong? ValueInt { get; set; }

    [Column("valueFloat", TypeName = "double unsigned")]
    public double? ValueFloat { get; set; }
}
