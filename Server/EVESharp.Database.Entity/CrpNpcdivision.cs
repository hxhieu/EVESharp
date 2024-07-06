using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpNPCDivisions")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpNpcdivision
{
    [Key]
    [Column("divisionID", TypeName = "tinyint(3) unsigned")]
    public byte DivisionId { get; set; }

    [Column("divisionName")]
    [StringLength(100)]
    public string? DivisionName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("leaderType")]
    [StringLength(100)]
    public string? LeaderType { get; set; }
}
