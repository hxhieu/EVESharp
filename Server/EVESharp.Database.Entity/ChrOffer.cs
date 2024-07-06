using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CharacterId", "OfferId")]
[Table("chrOffers")]
[Index("OfferId", Name = "offerID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrOffer
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Key]
    [Column("offerID", TypeName = "int(10) unsigned")]
    public uint OfferId { get; set; }

    [Column("expirationTime", TypeName = "bigint(20) unsigned")]
    public ulong ExpirationTime { get; set; }
}
