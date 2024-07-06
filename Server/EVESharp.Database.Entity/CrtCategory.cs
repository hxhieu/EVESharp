using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crtCategories")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrtCategory
{
    [Key]
    [Column("categoryID", TypeName = "tinyint(3) unsigned")]
    public byte CategoryId { get; set; }

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; }

    [Column("categoryName")]
    [StringLength(256)]
    public string? CategoryName { get; set; }
}
