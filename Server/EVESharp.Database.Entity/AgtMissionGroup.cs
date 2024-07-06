using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CorporationId", "DivisionId", "Level")]
[Table("agtMissionGroups")]
[Index("DivisionId", Name = "divisionID")]
[Index("MissionId", Name = "missionID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtMissionGroup
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Key]
    [Column("divisionID", TypeName = "int(10) unsigned")]
    public uint DivisionId { get; set; }

    [Key]
    [Column("level", TypeName = "int(10) unsigned")]
    public uint Level { get; set; }

    [Column("missionID", TypeName = "int(10) unsigned")]
    public uint? MissionId { get; set; }
}
