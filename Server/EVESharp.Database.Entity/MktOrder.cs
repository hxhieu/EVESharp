using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mktOrders")]
[Index("StationId", Name = "stationID")]
[Index("TypeId", Name = "typeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MktOrder
{
    [Key]
    [Column("orderID", TypeName = "int(10) unsigned")]
    public uint OrderId { get; set; }

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("charID", TypeName = "int(10) unsigned")]
    public uint CharId { get; set; }

    [Column("corpID", TypeName = "int(10) unsigned")]
    public uint CorpId { get; set; }

    [Column("stationID", TypeName = "int(10) unsigned")]
    public uint StationId { get; set; }

    [Column("range", TypeName = "smallint(6)")]
    public short Range { get; set; }

    [Column("bid", TypeName = "tinyint(3) unsigned")]
    public byte Bid { get; set; }

    [Column("price")]
    public double Price { get; set; }

    [Column("volEntered", TypeName = "int(10) unsigned")]
    public uint VolEntered { get; set; }

    [Column("volRemaining", TypeName = "int(10) unsigned")]
    public uint VolRemaining { get; set; }

    [Column("issued", TypeName = "bigint(20) unsigned")]
    public ulong Issued { get; set; }

    [Column("minVolume", TypeName = "int(10) unsigned")]
    public uint MinVolume { get; set; }

    [Column("accountID", TypeName = "int(10) unsigned")]
    public uint AccountId { get; set; }

    [Column("duration", TypeName = "int(10) unsigned")]
    public uint Duration { get; set; }

    [Column("isCorp", TypeName = "tinyint(3) unsigned")]
    public byte IsCorp { get; set; }

    [Column("escrow", TypeName = "tinyint(3) unsigned")]
    public byte Escrow { get; set; }
}
