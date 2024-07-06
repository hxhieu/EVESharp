using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("ChannelId", "Accessor")]
[Table("lscChannelPermissions")]
[Index("ChannelId", Name = "FK_CHANNELMODS_CHANNELS")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class LscChannelPermission
{
    [Key]
    [Column("channelID", TypeName = "int(10)")]
    public int ChannelId { get; set; }

    [Key]
    [Column("accessor", TypeName = "int(10) unsigned")]
    public uint Accessor { get; set; }

    [Column("mode", TypeName = "int(10) unsigned")]
    public uint Mode { get; set; }

    [Column("untilWhen", TypeName = "bigint(20) unsigned")]
    public ulong? UntilWhen { get; set; }

    [Column("originalMode", TypeName = "int(10) unsigned")]
    public uint? OriginalMode { get; set; }

    [Column("admin")]
    [StringLength(85)]
    public string? Admin { get; set; }

    [Column("reason", TypeName = "text")]
    public string? Reason { get; set; }
}
