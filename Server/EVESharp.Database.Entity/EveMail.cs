using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveMail")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveMail
{
    [Column("channelID", TypeName = "int(10) unsigned")]
    public uint ChannelId { get; set; }

    [Key]
    [Column("messageID", TypeName = "int(10) unsigned")]
    public uint MessageId { get; set; }

    [Column("senderID", TypeName = "int(10) unsigned")]
    public uint SenderId { get; set; }

    [Column("subject")]
    [StringLength(255)]
    public string Subject { get; set; } = null!;

    [Column("body")]
    public string Body { get; set; } = null!;

    [Column("mimeTypeID", TypeName = "int(10) unsigned")]
    public uint MimeTypeId { get; set; }

    [Column("created", TypeName = "bigint(20) unsigned")]
    public ulong Created { get; set; }

    [Column("read", TypeName = "tinyint(3) unsigned")]
    public byte Read { get; set; }
}
