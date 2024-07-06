using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveMailMimeType")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveMailMimeType
{
    [Key]
    [Column("mimeTypeID", TypeName = "int(10) unsigned")]
    public uint MimeTypeId { get; set; }

    [Column("mimeType", TypeName = "text")]
    public string MimeType { get; set; } = null!;

    [Column("binary", TypeName = "tinyint(3) unsigned")]
    public byte Binary { get; set; }
}
