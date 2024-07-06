using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpApplications")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpApplication
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Column("allianceID", TypeName = "int(10) unsigned")]
    public uint AllianceId { get; set; }

    [Column("applicationText", TypeName = "text")]
    public string ApplicationText { get; set; } = null!;

    [Column("applicationDateTime", TypeName = "bigint(20) unsigned")]
    public ulong ApplicationDateTime { get; set; }

    [Column("applicationUpdateTime", TypeName = "bigint(20) unsigned")]
    public ulong ApplicationUpdateTime { get; set; }

    [Column("state", TypeName = "int(10) unsigned")]
    public uint State { get; set; }
}
