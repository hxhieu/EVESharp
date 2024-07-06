using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("TutorialId", "CriteriaId")]
[Table("tutorials_criterias")]
[Index("CriteriaId", Name = "criteriaID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TutorialsCriteria
{
    [Key]
    [Column("tutorialID", TypeName = "int(10) unsigned")]
    public uint TutorialId { get; set; }

    [Key]
    [Column("criteriaID", TypeName = "int(10) unsigned")]
    public uint CriteriaId { get; set; }
}
