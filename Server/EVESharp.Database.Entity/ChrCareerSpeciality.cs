using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrCareerSpecialities")]
[Index("CareerId", Name = "careerID")]
[Index("GraphicId", Name = "graphicID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrCareerSpeciality
{
    [Key]
    [Column("specialityID", TypeName = "tinyint(3) unsigned")]
    public byte SpecialityId { get; set; }

    [Column("careerID", TypeName = "tinyint(3) unsigned")]
    public byte? CareerId { get; set; }

    [Column("specialityName")]
    [StringLength(100)]
    public string? SpecialityName { get; set; }

    [Column("description")]
    [StringLength(2000)]
    public string? Description { get; set; }

    [Column("shortDescription")]
    [StringLength(500)]
    public string? ShortDescription { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }
}
