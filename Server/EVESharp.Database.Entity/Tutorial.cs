using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("tutorials")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class Tutorial
{
    [Key]
    [Column("tutorialID", TypeName = "int(10) unsigned")]
    public uint TutorialId { get; set; }

    [Column("tutorialName")]
    [StringLength(100)]
    public string TutorialName { get; set; } = null!;

    [Column("nextTutorialID", TypeName = "int(10) unsigned")]
    public uint? NextTutorialId { get; set; }

    [Column("categoryID", TypeName = "int(10) unsigned")]
    public uint CategoryId { get; set; }
}
