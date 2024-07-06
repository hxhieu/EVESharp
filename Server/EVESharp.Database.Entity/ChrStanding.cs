using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CharacterId", "ToId")]
[Table("chrStandings")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrStanding
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Key]
    [Column("toID", TypeName = "int(10) unsigned")]
    public uint ToId { get; set; }

    [Column("standing")]
    public double Standing { get; set; }
}
