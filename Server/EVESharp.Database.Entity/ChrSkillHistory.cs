using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CharacterId", "SkillTypeId", "EventId", "LogDateTime")]
[Table("chrSkillHistory")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrSkillHistory
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Key]
    [Column("skillTypeID", TypeName = "int(10) unsigned")]
    public uint SkillTypeId { get; set; }

    [Key]
    [Column("eventID", TypeName = "int(10)")]
    public int EventId { get; set; }

    [Key]
    [Column("logDateTime", TypeName = "bigint(20)")]
    public long LogDateTime { get; set; }

    [Column("absolutePoints")]
    public double AbsolutePoints { get; set; }
}
