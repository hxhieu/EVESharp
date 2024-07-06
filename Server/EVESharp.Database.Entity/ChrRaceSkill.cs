using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("RaceId", "SkillTypeId")]
[Table("chrRaceSkills")]
[Index("SkillTypeId", Name = "skillTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrRaceSkill
{
    [Key]
    [Column("raceID", TypeName = "tinyint(3) unsigned")]
    public byte RaceId { get; set; }

    [Key]
    [Column("skillTypeID", TypeName = "smallint(6)")]
    public short SkillTypeId { get; set; }

    [Column("levels", TypeName = "tinyint(4)")]
    public sbyte? Levels { get; set; }
}
