using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CorporationId", "DivisionId")]
[Table("crpNPCCorporationDivisions")]
[Index("DivisionId", Name = "divisionID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpNpccorporationDivision
{
    [Key]
    [Column("corporationID", TypeName = "int(11)")]
    public int CorporationId { get; set; }

    [Key]
    [Column("divisionID", TypeName = "tinyint(3) unsigned")]
    public byte DivisionId { get; set; }

    [Column("size", TypeName = "tinyint(4)")]
    public sbyte? Size { get; set; }
}
