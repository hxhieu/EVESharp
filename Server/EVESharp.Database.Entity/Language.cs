using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("languages")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class Language
{
    [Key]
    [Column("languageID")]
    [StringLength(2)]
    public string LanguageId { get; set; } = null!;

    [Column("languageName")]
    [StringLength(100)]
    public string LanguageName { get; set; } = null!;

    [Column("translatedLanguageName")]
    [StringLength(22)]
    public string TranslatedLanguageName { get; set; } = null!;
}
