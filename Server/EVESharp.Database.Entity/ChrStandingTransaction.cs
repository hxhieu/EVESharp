using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("EventId", "FromId", "ToId")]
[Table("chrStandingTransactions")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrStandingTransaction
{
    [Key]
    [Column("eventID", TypeName = "int(10) unsigned")]
    public uint EventId { get; set; }

    [Key]
    [Column("fromID", TypeName = "int(10) unsigned")]
    public uint FromId { get; set; }

    [Key]
    [Column("toID", TypeName = "int(10) unsigned")]
    public uint ToId { get; set; }

    [Column("eventDateTime", TypeName = "bigint(20) unsigned")]
    public ulong EventDateTime { get; set; }

    [Column("direction", TypeName = "int(10) unsigned")]
    public uint Direction { get; set; }

    [Column("eventTypeID", TypeName = "int(10) unsigned")]
    public uint EventTypeId { get; set; }

    [Column("msg", TypeName = "text")]
    public string Msg { get; set; } = null!;

    [Column("modification")]
    public double Modification { get; set; }

    [Column("int_1", TypeName = "int(10) unsigned")]
    public uint Int1 { get; set; }

    [Column("int_2", TypeName = "int(10) unsigned")]
    public uint Int2 { get; set; }

    [Column("int_3", TypeName = "int(10) unsigned")]
    public uint Int3 { get; set; }
}
