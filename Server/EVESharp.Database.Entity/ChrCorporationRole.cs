using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrCorporationRoles")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrCorporationRole
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Column("corprole", TypeName = "bigint(20) unsigned")]
    public ulong Corprole { get; set; }

    [Column("rolesAtAll", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtAll { get; set; }

    [Column("rolesAtBase", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtBase { get; set; }

    [Column("rolesAtHQ", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtHq { get; set; }

    [Column("rolesAtOther", TypeName = "bigint(20) unsigned")]
    public ulong RolesAtOther { get; set; }
}
