using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveRoles")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveRole
{
    [Column("roleID", TypeName = "int(10) unsigned")]
    public uint RoleId { get; set; }

    [Key]
    [Column("roleName")]
    [StringLength(100)]
    public string RoleName { get; set; } = null!;

    [Column("description", TypeName = "mediumtext")]
    public string Description { get; set; } = null!;
}
