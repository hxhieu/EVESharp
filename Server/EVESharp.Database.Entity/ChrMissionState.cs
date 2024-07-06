using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CharacterId", "MissionId")]
[Table("chrMissionState")]
[Index("MissionId", Name = "missionID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrMissionState
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Key]
    [Column("missionID", TypeName = "int(10) unsigned")]
    public uint MissionId { get; set; }

    [Column("missionState", TypeName = "tinyint(3) unsigned")]
    public byte MissionState { get; set; }

    [Column("expirationTime", TypeName = "bigint(20) unsigned")]
    public ulong ExpirationTime { get; set; }
}
