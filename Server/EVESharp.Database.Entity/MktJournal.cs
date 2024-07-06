using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mktJournal")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MktJournal
{
    [Key]
    [Column("transactionID", TypeName = "int(10) unsigned")]
    public uint TransactionId { get; set; }

    [Column("transactionDate", TypeName = "bigint(20)")]
    public long? TransactionDate { get; set; }

    [Column("entryTypeID", TypeName = "int(10) unsigned")]
    public uint EntryTypeId { get; set; }

    [Column("charID", TypeName = "int(10) unsigned")]
    public uint? CharId { get; set; }

    [Column("ownerID1", TypeName = "int(10) unsigned")]
    public uint? OwnerId1 { get; set; }

    [Column("ownerID2", TypeName = "int(10) unsigned")]
    public uint? OwnerId2 { get; set; }

    [Column("referenceID", TypeName = "int(10)")]
    public int? ReferenceId { get; set; }

    [Column("amount")]
    public double Amount { get; set; }

    [Column("balance")]
    public double Balance { get; set; }

    [Column("description")]
    [StringLength(43)]
    public string? Description { get; set; }

    [Column("accountKey", TypeName = "int(10) unsigned")]
    public uint AccountKey { get; set; }
}
