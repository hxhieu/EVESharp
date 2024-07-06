using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("tutorial_pages")]
[Index("TutorialId", "PageNumber", Name = "tutorialID", IsUnique = true)]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TutorialPage
{
    [Key]
    [Column("pageID", TypeName = "int(10) unsigned")]
    public uint PageId { get; set; }

    [Column("pageNumber", TypeName = "int(10) unsigned")]
    public uint PageNumber { get; set; }

    [Column("pageName")]
    [StringLength(100)]
    public string PageName { get; set; } = null!;

    [Column("text", TypeName = "mediumtext")]
    public string Text { get; set; } = null!;

    [Column("imagePath")]
    [StringLength(200)]
    public string? ImagePath { get; set; }

    [Column("audioPath")]
    [StringLength(200)]
    public string AudioPath { get; set; } = null!;

    [Column("tutorialID", TypeName = "int(10) unsigned")]
    public uint TutorialId { get; set; }
}
