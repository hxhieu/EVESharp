using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpNPCTickerNames")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpNpctickerName
{
    [Key]
    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Column("tickerName")]
    [StringLength(64)]
    public string TickerName { get; set; } = null!;

    [Column("shape1", TypeName = "int(10) unsigned")]
    public uint? Shape1 { get; set; }

    [Column("shape2", TypeName = "int(10) unsigned")]
    public uint? Shape2 { get; set; }

    [Column("shape3", TypeName = "int(10) unsigned")]
    public uint? Shape3 { get; set; }

    [Column("color1", TypeName = "text")]
    public string? Color1 { get; set; }

    [Column("color2", TypeName = "text")]
    public string? Color2 { get; set; }

    [Column("color3", TypeName = "text")]
    public string? Color3 { get; set; }
}
