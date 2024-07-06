using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("StationId", "SlotNumber")]
[Table("rentalInfo")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RentalInfo
{
    [Key]
    [Column("stationID", TypeName = "int(10) unsigned")]
    public uint StationId { get; set; }

    [Key]
    [Column("slotNumber", TypeName = "int(10) unsigned")]
    public uint SlotNumber { get; set; }

    [Column("renterID", TypeName = "int(10) unsigned")]
    public uint RenterId { get; set; }

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("rentPeriodInDays", TypeName = "int(10) unsigned")]
    public uint RentPeriodInDays { get; set; }

    [Column("periodCost")]
    public double PeriodCost { get; set; }

    [Column("billID", TypeName = "int(10) unsigned")]
    public uint BillId { get; set; }

    [Column("balanceDueDate", TypeName = "int(10) unsigned")]
    public uint BalanceDueDate { get; set; }

    [Column("discontinue", TypeName = "tinyint(3) unsigned")]
    public byte Discontinue { get; set; }

    [Column("publiclyAvailable", TypeName = "tinyint(3) unsigned")]
    public byte PubliclyAvailable { get; set; }
}
