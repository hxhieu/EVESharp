using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("OfferId", "TypeId")]
[Table("agtOfferReward")]
[Index("TypeId", Name = "typeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtOfferReward
{
    [Key]
    [Column("offerID", TypeName = "int(10) unsigned")]
    public uint OfferId { get; set; }

    [Key]
    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("quantity", TypeName = "int(10) unsigned")]
    public uint Quantity { get; set; }
}
