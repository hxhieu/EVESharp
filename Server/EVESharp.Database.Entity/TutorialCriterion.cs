using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("tutorial_criteria")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TutorialCriterion
{
    [Key]
    [Column("criteriaID", TypeName = "int(10) unsigned")]
    public uint CriteriaId { get; set; }

    [Column("criteriaName")]
    [StringLength(100)]
    public string CriteriaName { get; set; } = null!;

    [Column("messageText", TypeName = "mediumtext")]
    public string MessageText { get; set; } = null!;

    [Column("audioPath")]
    [StringLength(200)]
    public string? AudioPath { get; set; }
}
