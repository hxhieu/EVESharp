using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Keyless]
[Table("intro")]
[Index("TextLabel", Name = "textLabel")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class Intro
{
    [Column("langID")]
    [StringLength(2)]
    public string LangId { get; set; } = null!;

    [Column("textgroup", TypeName = "int(10) unsigned")]
    public uint Textgroup { get; set; }

    [Column("textLabel")]
    [StringLength(10)]
    public string TextLabel { get; set; } = null!;

    [Column("text", TypeName = "text")]
    public string Text { get; set; } = null!;
}
