using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Keyless]
[Table("crpNPCCorporationTrades")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpNpccorporationTrade
{
    [Column("corporationID", TypeName = "int(11)")]
    public int? CorporationId { get; set; }

    [Column("typeID", TypeName = "int(11)")]
    public int? TypeId { get; set; }

    [Column("supplyDemand")]
    public double? SupplyDemand { get; set; }
}
