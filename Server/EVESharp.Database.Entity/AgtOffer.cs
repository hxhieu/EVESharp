using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("agtOffers")]
[Index("OfferLevel", Name = "offerLevel")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtOffer
{
    [Key]
    [Column("offerID", TypeName = "int(10) unsigned")]
    public uint OfferId { get; set; }

    [Column("offerName")]
    [StringLength(255)]
    public string OfferName { get; set; } = null!;

    [Column("offerLevel", TypeName = "tinyint(3) unsigned")]
    public byte OfferLevel { get; set; }

    [Column("loyaltyPoints", TypeName = "int(10) unsigned")]
    public uint LoyaltyPoints { get; set; }

    [Column("requiredISK", TypeName = "int(10) unsigned")]
    public uint RequiredIsk { get; set; }

    [Column("rewardISK", TypeName = "int(10) unsigned")]
    public uint RewardIsk { get; set; }

    [Column("offerText", TypeName = "mediumtext")]
    public string OfferText { get; set; } = null!;

    [Column("offerAcceptedText", TypeName = "mediumtext")]
    public string OfferAcceptedText { get; set; } = null!;
}
