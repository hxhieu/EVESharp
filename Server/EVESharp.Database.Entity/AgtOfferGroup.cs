using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CorporationId", "DivisionId", "Level")]
[Table("agtOfferGroups")]
[Index("DivisionId", Name = "divisionID")]
[Index("OfferId", Name = "offerID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtOfferGroup
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Key]
    [Column("divisionID", TypeName = "int(10) unsigned")]
    public uint DivisionId { get; set; }

    [Key]
    [Column("level", TypeName = "int(10) unsigned")]
    public uint Level { get; set; }

    [Column("offerID", TypeName = "int(10) unsigned")]
    public uint? OfferId { get; set; }
}
