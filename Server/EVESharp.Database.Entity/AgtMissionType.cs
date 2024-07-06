using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("agtMissionTypes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtMissionType
{
    [Key]
    [Column("missionTypeID", TypeName = "int(10) unsigned")]
    public uint MissionTypeId { get; set; }

    [Column("missionTypeName")]
    [StringLength(255)]
    public string MissionTypeName { get; set; } = null!;
}
