using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("OwnerId", "CorporationId")]
[Table("crpShares")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpShare
{
    [Key]
    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Column("shares", TypeName = "int(10) unsigned")]
    public uint Shares { get; set; }
}
