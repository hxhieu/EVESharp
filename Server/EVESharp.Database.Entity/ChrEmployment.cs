using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CharacterId", "CorporationId", "StartDate")]
[Table("chrEmployment")]
[Index("CorporationId", Name = "corporationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrEmployment
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Key]
    [Column("startDate", TypeName = "bigint(20) unsigned")]
    public ulong StartDate { get; set; }

    [Column("deleted", TypeName = "tinyint(4)")]
    public sbyte Deleted { get; set; }
}
