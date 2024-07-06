using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FactionId", "TypeId")]
[Table("invContrabandTypes")]
[Index("TypeId", Name = "invContrabandTypes_IX_type")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvContrabandType
{
    [Key]
    [Column("factionID", TypeName = "int(11)")]
    public int FactionId { get; set; }

    [Key]
    [Column("typeID", TypeName = "smallint(6)")]
    public short TypeId { get; set; }

    [Column("standingLoss")]
    public double? StandingLoss { get; set; }

    [Column("confiscateMinSec")]
    public double? ConfiscateMinSec { get; set; }

    [Column("fineByValue")]
    public double? FineByValue { get; set; }

    [Column("attackMinSec")]
    public double? AttackMinSec { get; set; }
}
