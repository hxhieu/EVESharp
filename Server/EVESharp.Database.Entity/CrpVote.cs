using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpVotes")]
[Index("CorporationId", Name = "corporationID")]
[Index("VoteType", Name = "voteType")]
[Index("VoteType", "CorporationId", Name = "voteType_corporationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpVote
{
    [Key]
    [Column("voteCaseID", TypeName = "int(10) unsigned")]
    public uint VoteCaseId { get; set; }

    [Column("voteType", TypeName = "int(11)")]
    public int? VoteType { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int? CorporationId { get; set; }

    [Column("characterID", TypeName = "int(11)")]
    public int? CharacterId { get; set; }

    [Column("startDateTime", TypeName = "bigint(20)")]
    public long? StartDateTime { get; set; }

    [Column("endDateTime", TypeName = "bigint(20)")]
    public long? EndDateTime { get; set; }

    [Column("voteCaseText")]
    [StringLength(255)]
    public string VoteCaseText { get; set; } = null!;

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    [Column("status", TypeName = "int(11)")]
    public int Status { get; set; }

    [Column("actedUpon")]
    public bool ActedUpon { get; set; }

    [Column("inEffect")]
    public bool InEffect { get; set; }

    [Column("expires", TypeName = "bigint(20)")]
    public long Expires { get; set; }

    [Column("timeRescended", TypeName = "bigint(20)")]
    public long? TimeRescended { get; set; }

    [Column("timeActedUpon", TypeName = "bigint(20)")]
    public long? TimeActedUpon { get; set; }
}
