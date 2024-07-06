using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveMessages")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveMessage
{
    [Key]
    [Column("messageID")]
    [StringLength(128)]
    public string MessageId { get; set; } = null!;

    [Column("messageType")]
    [StringLength(100)]
    public string MessageType { get; set; } = null!;

    [Column("messageText", TypeName = "mediumtext")]
    public string MessageText { get; set; } = null!;

    [Column("urlAudio", TypeName = "mediumtext")]
    public string UrlAudio { get; set; } = null!;

    [Column("urlIcon", TypeName = "mediumtext")]
    public string UrlIcon { get; set; } = null!;
}
