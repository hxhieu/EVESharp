using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpRoleGroups")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpRoleGroup
{
    [Key]
    [Column("roleGroupID", TypeName = "int(11)")]
    public int RoleGroupId { get; set; }

    [Column("roleMask", TypeName = "bigint(20)")]
    public long? RoleMask { get; set; }

    [Column("roleGroupName")]
    [StringLength(255)]
    public string RoleGroupName { get; set; } = null!;

    [Column("appliesTo")]
    [StringLength(50)]
    public string AppliesTo { get; set; } = null!;

    [Column("appliesToGrantable")]
    [StringLength(50)]
    public string AppliesToGrantable { get; set; } = null!;

    [Column("isDivisional", TypeName = "tinyint(4)")]
    public sbyte IsDivisional { get; set; }
}
