using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrShipInsurances")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrShipInsurance
{
    [Key]
    [Column("insuranceID", TypeName = "int(10) unsigned")]
    public uint InsuranceId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("shipID", TypeName = "int(10) unsigned")]
    public uint ShipId { get; set; }

    [Column("fraction", TypeName = "int(10)")]
    public int Fraction { get; set; }

    [Column("startDate", TypeName = "bigint(20)")]
    public long StartDate { get; set; }

    [Column("endDate", TypeName = "bigint(20)")]
    public long EndDate { get; set; }
}
