using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invGroups")]
[Index("GraphicId", Name = "graphicID")]
[Index("CategoryId", Name = "invGroups_IX_category")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvGroup
{
    [Key]
    [Column("groupID", TypeName = "smallint(6)")]
    public short GroupId { get; set; }

    [Column("categoryID", TypeName = "tinyint(3) unsigned")]
    public byte? CategoryId { get; set; }

    [Column("groupName")]
    [StringLength(100)]
    public string? GroupName { get; set; }

    [Column("description")]
    [StringLength(3000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("useBasePrice")]
    public bool? UseBasePrice { get; set; }

    [Column("allowManufacture")]
    public bool? AllowManufacture { get; set; }

    [Column("allowRecycler")]
    public bool? AllowRecycler { get; set; }

    [Column("anchored")]
    public bool? Anchored { get; set; }

    [Column("anchorable")]
    public bool? Anchorable { get; set; }

    [Column("fittableNonSingleton")]
    public bool? FittableNonSingleton { get; set; }

    [Column("published")]
    public bool? Published { get; set; }
}
