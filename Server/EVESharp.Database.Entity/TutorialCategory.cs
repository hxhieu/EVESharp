using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("tutorial_categories")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TutorialCategory
{
    [Key]
    [Column("categoryID", TypeName = "int(10) unsigned")]
    public uint CategoryId { get; set; }

    [Column("categoryName")]
    [StringLength(100)]
    public string CategoryName { get; set; } = null!;

    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; } = null!;
}
