using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpRecruitmentAdTypes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpRecruitmentAdType
{
    [Key]
    [Column("typeMask", TypeName = "int(11)")]
    public int TypeMask { get; set; }

    [Column("groupID", TypeName = "int(11)")]
    public int GroupId { get; set; }

    [Column("typeName")]
    [StringLength(50)]
    public string? TypeName { get; set; }

    [Column("description")]
    [StringLength(50)]
    public string? Description { get; set; }

    [Column("dataID", TypeName = "int(11)")]
    public int DataId { get; set; }
}
