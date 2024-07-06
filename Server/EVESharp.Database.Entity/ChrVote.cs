using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("OptionId", "CharacterId")]
[Table("chrVotes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrVote
{
    [Key]
    [Column("optionID", TypeName = "int(11)")]
    public int OptionId { get; set; }

    [Key]
    [Column("characterID", TypeName = "int(11)")]
    public int CharacterId { get; set; }
}
