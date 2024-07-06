using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("MedalId", "OwnerId")]
[Table("chrMedals")]
[Index("IssuerId", Name = "issuerID")]
[Index("OwnerId", Name = "ownerID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrMedal
{
    [Key]
    [Column("medalID", TypeName = "int(10) unsigned")]
    public uint MedalId { get; set; }

    [Key]
    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("issuerID", TypeName = "int(10) unsigned")]
    public uint IssuerId { get; set; }

    [Column("date", TypeName = "bigint(20)")]
    public long Date { get; set; }

    [Column("reason", TypeName = "int(11)")]
    public int Reason { get; set; }

    [Column("status", TypeName = "int(11)")]
    public int Status { get; set; }
}
