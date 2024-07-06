using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("PageId", "CriteriaId")]
[Table("tutorial_page_criteria")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TutorialPageCriterion
{
    [Key]
    [Column("pageID", TypeName = "int(10) unsigned")]
    public uint PageId { get; set; }

    [Key]
    [Column("criteriaID", TypeName = "int(10) unsigned")]
    public uint CriteriaId { get; set; }
}
