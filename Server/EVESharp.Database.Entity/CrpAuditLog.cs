using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpAuditLog")]
[Index("CorporationId", Name = "corporationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpAuditLog
{
    [Key]
    [Column("id", TypeName = "bigint(20)")]
    public long Id { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int CorporationId { get; set; }

    [Column("eventDateTime", TypeName = "bigint(20)")]
    public long EventDateTime { get; set; }

    [Column("eventTypeID", TypeName = "int(4)")]
    public int EventTypeId { get; set; }

    [Column("charID", TypeName = "int(11)")]
    public int CharId { get; set; }
}
