using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("lscPrivateChannels")]
[Index("OwnerId", Name = "FK_CHANNELS_OWNER")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class LscPrivateChannel
{
    [Key]
    [Column("channelID", TypeName = "int(10) unsigned")]
    public uint ChannelId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("displayName")]
    [StringLength(85)]
    public string? DisplayName { get; set; }

    [Column("motd", TypeName = "text")]
    public string? Motd { get; set; }

    [Column("comparisonKey")]
    [StringLength(11)]
    public string? ComparisonKey { get; set; }

    [Column("memberless", TypeName = "tinyint(4)")]
    public sbyte Memberless { get; set; }

    [Column("password")]
    [StringLength(100)]
    public string? Password { get; set; }

    [Column("mailingList", TypeName = "tinyint(4)")]
    public sbyte MailingList { get; set; }

    [Column("cspa", TypeName = "tinyint(4)")]
    public sbyte Cspa { get; set; }

    [Column("temporary", TypeName = "tinyint(4)")]
    public sbyte Temporary { get; set; }

    [Column("estimatedMemberCount", TypeName = "int(10) unsigned")]
    public uint EstimatedMemberCount { get; set; }
}
