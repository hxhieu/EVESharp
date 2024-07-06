using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveGraphics")]
[Index("ExplosionId", Name = "explosionID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveGraphic
{
    [Key]
    [Column("graphicID", TypeName = "smallint(6)")]
    public short GraphicId { get; set; }

    [Column("url3D")]
    [StringLength(100)]
    public string? Url3D { get; set; }

    [Column("urlWeb")]
    [StringLength(100)]
    public string? UrlWeb { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("published")]
    public bool? Published { get; set; }

    [Column("obsolete")]
    public bool? Obsolete { get; set; }

    [Column("icon")]
    [StringLength(100)]
    public string? Icon { get; set; }

    [Column("urlSound")]
    [StringLength(100)]
    public string? UrlSound { get; set; }

    [Column("explosionID", TypeName = "smallint(6)")]
    public short? ExplosionId { get; set; }
}
