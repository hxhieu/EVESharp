using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mktBills")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MktBill
{
    [Key]
    [Column("billID", TypeName = "int(10) unsigned")]
    public uint BillId { get; set; }

    [Column("billTypeID", TypeName = "int(10) unsigned")]
    public uint? BillTypeId { get; set; }

    [Column("debtorID", TypeName = "int(10) unsigned")]
    public uint? DebtorId { get; set; }

    [Column("creditorID", TypeName = "int(10) unsigned")]
    public uint? CreditorId { get; set; }

    [Column("amount", TypeName = "double(22,0)")]
    public double Amount { get; set; }

    [Column("dueDateTime", TypeName = "bigint(20)")]
    public long DueDateTime { get; set; }

    [Column("interest", TypeName = "double(22,0)")]
    public double Interest { get; set; }

    [Column("externalID", TypeName = "int(11)")]
    public int ExternalId { get; set; }

    [Column("paid", TypeName = "tinyint(4)")]
    public sbyte Paid { get; set; }

    [Column("externalID2", TypeName = "int(11)")]
    public int ExternalId2 { get; set; }
}
