using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CorporationId", "StationId")]
[Table("crpOffices")]
[Index("OfficeFolderId", Name = "officeFolderID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpOffice
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Key]
    [Column("stationID", TypeName = "int(10) unsigned")]
    public uint StationId { get; set; }

    [Column("officeID", TypeName = "int(10) unsigned")]
    public uint OfficeId { get; set; }

    [Column("officeFolderID", TypeName = "int(10) unsigned")]
    public uint OfficeFolderId { get; set; }

    [Column("startDate", TypeName = "bigint(20)")]
    public long StartDate { get; set; }

    [Column("rentPeriodInDays", TypeName = "int(11)")]
    public int RentPeriodInDays { get; set; }

    [Column("periodCost", TypeName = "double(22,0)")]
    public double PeriodCost { get; set; }

    [Column("balanceDueDate", TypeName = "bigint(20)")]
    public long? BalanceDueDate { get; set; }

    [Column("impounded")]
    public bool Impounded { get; set; }

    [Column("nextBillID", TypeName = "int(10) unsigned")]
    public uint NextBillId { get; set; }
}
