using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mktTransactions")]
[Index("StationId", Name = "stationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MktTransaction
{
    [Key]
    [Column("transactionID", TypeName = "int(10) unsigned")]
    public uint TransactionId { get; set; }

    [Column("transactionDateTime", TypeName = "bigint(20) unsigned")]
    public ulong TransactionDateTime { get; set; }

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("quantity", TypeName = "int(10) unsigned")]
    public uint Quantity { get; set; }

    [Column("price", TypeName = "double(22,0)")]
    public double Price { get; set; }

    [Column("transactionType", TypeName = "int(10) unsigned")]
    public uint TransactionType { get; set; }

    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Column("clientID", TypeName = "int(10) unsigned")]
    public uint? ClientId { get; set; }

    [Column("stationID", TypeName = "int(10) unsigned")]
    public uint StationId { get; set; }

    [Column("accountKey", TypeName = "int(10) unsigned")]
    public uint AccountKey { get; set; }

    [Column("entityID", TypeName = "int(11)")]
    public int EntityId { get; set; }
}
