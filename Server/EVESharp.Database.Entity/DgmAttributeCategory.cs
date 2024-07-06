using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("dgmAttributeCategories")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class DgmAttributeCategory
{
    [Key]
    [Column("categoryID", TypeName = "tinyint(3) unsigned")]
    public byte CategoryId { get; set; }

    [Column("categoryName")]
    [StringLength(50)]
    public string? CategoryName { get; set; }

    [Column("categoryDescription")]
    [StringLength(200)]
    public string? CategoryDescription { get; set; }
}
