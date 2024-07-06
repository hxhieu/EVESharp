using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpRecruitmentAds")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpRecruitmentAd
{
    [Key]
    [Column("adID", TypeName = "int(11)")]
    public int AdId { get; set; }

    [Column("expiryDateTime", TypeName = "bigint(20)")]
    public long ExpiryDateTime { get; set; }

    [Column("createDateTime", TypeName = "bigint(20)")]
    public long CreateDateTime { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int CorporationId { get; set; }

    [Column("typeMask", TypeName = "int(11)")]
    public int TypeMask { get; set; }

    [Column("raceMask", TypeName = "int(11)")]
    public int RaceMask { get; set; }

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    [Column("minimumSkillPoints")]
    public double MinimumSkillPoints { get; set; }

    [Column("stationID", TypeName = "int(11)")]
    public int StationId { get; set; }
}
