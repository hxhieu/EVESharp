using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpRoles")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpRole
{
    [Key]
    [Column("roleID", TypeName = "bigint(20) unsigned")]
    public ulong RoleId { get; set; }

    [Column("roleName")]
    [StringLength(50)]
    public string? RoleName { get; set; }

    [Column("description")]
    [StringLength(255)]
    public string? Description { get; set; }

    [Column("shortDescription")]
    [StringLength(255)]
    public string? ShortDescription { get; set; }

    [Column("roleIID", TypeName = "int(10) unsigned")]
    public uint RoleIid { get; set; }
}
