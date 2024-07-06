using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrCareers")]
[Index("GraphicId", Name = "graphicID")]
[Index("RaceId", Name = "raceID")]
[Index("SchoolId", Name = "schoolID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrCareer
{
    [Column("raceID", TypeName = "tinyint(3) unsigned")]
    public byte? RaceId { get; set; }

    [Key]
    [Column("careerID", TypeName = "tinyint(3) unsigned")]
    public byte CareerId { get; set; }

    [Column("careerName")]
    [StringLength(100)]
    public string? CareerName { get; set; }

    [Column("description")]
    [StringLength(2000)]
    public string? Description { get; set; }

    [Column("shortDescription")]
    [StringLength(500)]
    public string? ShortDescription { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("schoolID", TypeName = "tinyint(3) unsigned")]
    public byte? SchoolId { get; set; }
}
