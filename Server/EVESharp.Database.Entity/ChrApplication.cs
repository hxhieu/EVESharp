using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CorporationId", "CharacterId")]
[Table("chrApplications")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrApplication
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Column("applicationText", TypeName = "text")]
    public string ApplicationText { get; set; } = null!;

    [Column("applicationDateTime", TypeName = "bigint(20) unsigned")]
    public ulong ApplicationDateTime { get; set; }
}
