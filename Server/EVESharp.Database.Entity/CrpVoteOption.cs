using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpVoteOptions")]
[Index("VoteCaseId", Name = "voteCaseID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpVoteOption
{
    [Key]
    [Column("optionID", TypeName = "int(10) unsigned")]
    public uint OptionId { get; set; }

    [Column("voteCaseID", TypeName = "int(11)")]
    public int? VoteCaseId { get; set; }

    [Column("optionText", TypeName = "text")]
    public string OptionText { get; set; } = null!;

    [Column("parameter", TypeName = "int(11)")]
    public int Parameter { get; set; }

    [Column("parameter1", TypeName = "int(11)")]
    public int? Parameter1 { get; set; }

    [Column("parameter2", TypeName = "int(11)")]
    public int? Parameter2 { get; set; }
}
