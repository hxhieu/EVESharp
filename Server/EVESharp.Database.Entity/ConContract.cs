using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("conContracts")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ConContract
{
    [Key]
    [Column("contractID", TypeName = "int(10) unsigned")]
    public uint ContractId { get; set; }

    [Column("issuerID", TypeName = "int(10) unsigned")]
    public uint IssuerId { get; set; }

    [Column("issuerCorpID", TypeName = "int(10) unsigned")]
    public uint IssuerCorpId { get; set; }

    [Column("type", TypeName = "int(10)")]
    public int Type { get; set; }

    [Column("availability", TypeName = "int(10)")]
    public int Availability { get; set; }

    [Column("assigneeID", TypeName = "int(10)")]
    public int AssigneeId { get; set; }

    [Column("expiretime", TypeName = "int(10)")]
    public int Expiretime { get; set; }

    [Column("numDays", TypeName = "int(10)")]
    public int NumDays { get; set; }

    [Column("startStationID", TypeName = "int(10) unsigned")]
    public uint StartStationId { get; set; }

    [Column("endStationID", TypeName = "int(10) unsigned")]
    public uint? EndStationId { get; set; }

    [Column("price", TypeName = "double(22,0)")]
    public double Price { get; set; }

    [Column("reward", TypeName = "double(22,0)")]
    public double Reward { get; set; }

    [Column("collateral", TypeName = "double(22,0)")]
    public double Collateral { get; set; }

    [Column("title")]
    [StringLength(85)]
    public string? Title { get; set; }

    [Column("description", TypeName = "mediumtext")]
    public string? Description { get; set; }

    [Column("forCorp")]
    public bool ForCorp { get; set; }

    [Column("status", TypeName = "int(10)")]
    public int Status { get; set; }

    [Column("isAccepted")]
    public bool IsAccepted { get; set; }

    [Column("acceptorID", TypeName = "int(10)")]
    public int? AcceptorId { get; set; }

    [Column("dateIssued", TypeName = "bigint(20)")]
    public long DateIssued { get; set; }

    [Column("dateExpired", TypeName = "bigint(20)")]
    public long DateExpired { get; set; }

    [Column("dateAccepted", TypeName = "bigint(20)")]
    public long DateAccepted { get; set; }

    [Column("dateCompleted", TypeName = "bigint(20)")]
    public long DateCompleted { get; set; }

    [Column("volume", TypeName = "double(22,0)")]
    public double? Volume { get; set; }

    [Column("crateID", TypeName = "int(10) unsigned")]
    public uint? CrateId { get; set; }

    [Column("issuerWalletKey", TypeName = "int(10) unsigned")]
    public uint IssuerWalletKey { get; set; }

    [Column("issuerAllianceID", TypeName = "int(10) unsigned")]
    public uint? IssuerAllianceId { get; set; }

    [Column("acceptorWalletKey", TypeName = "int(10) unsigned")]
    public uint? AcceptorWalletKey { get; set; }
}
