using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveNames")]
[Index("CategoryId", Name = "categoryID")]
[Index("GroupId", Name = "groupID")]
[Index("TypeId", Name = "typeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveName
{
    [Key]
    [Column("itemID", TypeName = "int(11)")]
    public int ItemId { get; set; }

    [Column("itemName")]
    [StringLength(100)]
    public string? ItemName { get; set; }

    [Column("categoryID", TypeName = "tinyint(3) unsigned")]
    public byte? CategoryId { get; set; }

    [Column("groupID", TypeName = "smallint(6)")]
    public short? GroupId { get; set; }

    [Column("typeID", TypeName = "smallint(6)")]
    public short? TypeId { get; set; }
}
