using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrAttributes")]
[Index("GraphicId", Name = "graphicID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrAttribute
{
    [Key]
    [Column("attributeID", TypeName = "tinyint(3) unsigned")]
    public byte AttributeId { get; set; }

    [Column("attributeName")]
    [StringLength(100)]
    public string? AttributeName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("shortDescription")]
    [StringLength(500)]
    public string? ShortDescription { get; set; }

    [Column("notes")]
    [StringLength(500)]
    public string? Notes { get; set; }
}
