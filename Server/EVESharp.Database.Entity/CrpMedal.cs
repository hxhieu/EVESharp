using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpMedals")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpMedal
{
    [Key]
    [Column("medalID", TypeName = "int(11)")]
    public int MedalId { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int CorporationId { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string? Title { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("date", TypeName = "bigint(20)")]
    public long? Date { get; set; }

    [Column("creatorID", TypeName = "int(11)")]
    public int? CreatorId { get; set; }

    [Column("noRecepients", TypeName = "int(11)")]
    public int? NoRecepients { get; set; }
}
