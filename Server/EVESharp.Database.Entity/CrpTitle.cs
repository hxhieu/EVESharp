using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CorporationId", "TitleId")]
[Table("crpTitles")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpTitle
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Key]
    [Column("titleID", TypeName = "int(10) unsigned")]
    public uint TitleId { get; set; }

    [Column("titleName")]
    [StringLength(50)]
    public string? TitleName { get; set; }

    [Column("roles", TypeName = "bigint(20) unsigned")]
    public ulong Roles { get; set; }

    [Column("grantableRoles", TypeName = "bigint(20) unsigned")]
    public ulong GrantableRoles { get; set; }

    [Column("rolesAtHQ", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtHq { get; set; }

    [Column("grantableRolesAtHQ", TypeName = "bigint(20) unsigned")]
    public ulong GrantableRolesAtHq { get; set; }

    [Column("rolesAtBase", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtBase { get; set; }

    [Column("grantableRolesAtBase", TypeName = "bigint(20) unsigned")]
    public ulong GrantableRolesAtBase { get; set; }

    [Column("rolesAtOther", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtOther { get; set; }

    [Column("grantableRolesAtOther", TypeName = "bigint(20) unsigned")]
    public ulong GrantableRolesAtOther { get; set; }
}
