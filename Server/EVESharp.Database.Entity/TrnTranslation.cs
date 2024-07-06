using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("TcId", "KeyId", "LanguageId")]
[Table("trnTranslations")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TrnTranslation
{
    [Key]
    [Column("tcID", TypeName = "smallint(6)")]
    public short TcId { get; set; }

    [Key]
    [Column("keyID", TypeName = "int(11)")]
    public int KeyId { get; set; }

    [Key]
    [Column("languageID")]
    [StringLength(2)]
    public string LanguageId { get; set; } = null!;

    [Column("text")]
    [StringLength(16000)]
    public string Text { get; set; } = null!;
}
