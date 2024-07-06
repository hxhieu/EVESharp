using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Keyless]
[Table("mktHistoryOld")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MktHistoryOld
{
    [Column("regionID", TypeName = "int(10) unsigned")]
    public uint RegionId { get; set; }

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("historyDate", TypeName = "bigint(20) unsigned")]
    public ulong HistoryDate { get; set; }

    [Column("lowPrice")]
    public double LowPrice { get; set; }

    [Column("highPrice")]
    public double HighPrice { get; set; }

    [Column("avgPrice")]
    public double AvgPrice { get; set; }

    [Column("volume", TypeName = "int(10) unsigned")]
    public uint Volume { get; set; }

    [Column("orders", TypeName = "int(10) unsigned")]
    public uint Orders { get; set; }
}
