using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("agtMissions")]
[Index("MissionLevel", Name = "missionLevel")]
[Index("MissionTypeId", Name = "missionTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtMission
{
    [Key]
    [Column("missionID", TypeName = "int(10) unsigned")]
    public uint MissionId { get; set; }

    [Column("missionName")]
    [StringLength(255)]
    public string MissionName { get; set; } = null!;

    [Column("missionLevel", TypeName = "tinyint(3) unsigned")]
    public byte MissionLevel { get; set; }

    [Column("missionTypeID", TypeName = "int(10) unsigned")]
    public uint MissionTypeId { get; set; }

    [Column("importantMission", TypeName = "tinyint(3) unsigned")]
    public byte ImportantMission { get; set; }
}
