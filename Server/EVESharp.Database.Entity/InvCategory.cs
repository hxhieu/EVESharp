using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invCategories")]
[Index("GraphicId", Name = "graphicID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvCategory
{
    [Key]
    [Column("categoryID", TypeName = "tinyint(3) unsigned")]
    public byte CategoryId { get; set; }

    [Column("categoryName")]
    [StringLength(100)]
    public string? CategoryName { get; set; }

    [Column("description")]
    [StringLength(3000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("published")]
    public bool? Published { get; set; }
}
