using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("conBids")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ConBid
{
    [Key]
    [Column("bidID", TypeName = "int(10) unsigned")]
    public uint BidId { get; set; }

    [Column("contractID", TypeName = "int(10) unsigned")]
    public uint ContractId { get; set; }

    [Column("bidderID", TypeName = "int(10) unsigned")]
    public uint BidderId { get; set; }

    [Column("amount", TypeName = "double unsigned")]
    public double Amount { get; set; }

    [Column("forCorp", TypeName = "tinyint(3) unsigned")]
    public byte ForCorp { get; set; }

    [Column("walletKey", TypeName = "int(11)")]
    public int WalletKey { get; set; }
}
