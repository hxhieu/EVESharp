using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrAncestries")]
[Index("BloodlineId", Name = "bloodlineID")]
[Index("GraphicId", Name = "graphicID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrAncestry
{
    [Key]
    [Column("ancestryID", TypeName = "tinyint(3) unsigned")]
    public byte AncestryId { get; set; }

    [Column("ancestryName")]
    [StringLength(100)]
    public string? AncestryName { get; set; }

    [Column("bloodlineID", TypeName = "tinyint(3) unsigned")]
    public byte? BloodlineId { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("perception", TypeName = "tinyint(4)")]
    public sbyte? Perception { get; set; }

    [Column("willpower", TypeName = "tinyint(4)")]
    public sbyte? Willpower { get; set; }

    [Column("charisma", TypeName = "tinyint(4)")]
    public sbyte? Charisma { get; set; }

    [Column("memory", TypeName = "tinyint(4)")]
    public sbyte? Memory { get; set; }

    [Column("intelligence", TypeName = "tinyint(4)")]
    public sbyte? Intelligence { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("shortDescription")]
    [StringLength(500)]
    public string? ShortDescription { get; set; }
}
