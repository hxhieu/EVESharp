using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpRecruitmentAdGroups")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpRecruitmentAdGroup
{
    [Key]
    [Column("groupID", TypeName = "int(11)")]
    public int GroupId { get; set; }

    [Column("groupName")]
    [StringLength(50)]
    public string GroupName { get; set; } = null!;

    [Column("dataID", TypeName = "int(11)")]
    public int DataId { get; set; }
}
