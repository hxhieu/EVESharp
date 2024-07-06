using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpAuditRole")]
[Index("ChangeTime", Name = "changeTime")]
[Index("CharId", Name = "characterID")]
[Index("CorporationId", Name = "corporationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpAuditRole
{
    [Key]
    [Column("id", TypeName = "bigint(20)")]
    public long Id { get; set; }

    [Column("charID", TypeName = "int(11)")]
    public int CharId { get; set; }

    [Column("issuerID", TypeName = "int(11)")]
    public int IssuerId { get; set; }

    [Column("changeTime", TypeName = "bigint(20)")]
    public long ChangeTime { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int CorporationId { get; set; }

    [Column("grantable")]
    public bool Grantable { get; set; }

    [Column("oldRoles", TypeName = "bigint(20)")]
    public long OldRoles { get; set; }

    [Column("newRoles", TypeName = "bigint(20)")]
    public long NewRoles { get; set; }
}
