using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrSchools")]
[Index("CareerId", Name = "careerID")]
[Index("CorporationId", Name = "corporationID")]
[Index("GraphicId", Name = "graphicID")]
[Index("NewAgentId", Name = "newAgentID")]
[Index("RaceId", Name = "raceID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrSchool
{
    [Column("raceID", TypeName = "tinyint(3) unsigned")]
    public byte? RaceId { get; set; }

    [Key]
    [Column("schoolID", TypeName = "tinyint(3) unsigned")]
    public byte SchoolId { get; set; }

    [Column("schoolName")]
    [StringLength(100)]
    public string? SchoolName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int? CorporationId { get; set; }

    [Column("newAgentID", TypeName = "int(11)")]
    public int? NewAgentId { get; set; }

    [Column("careerID", TypeName = "tinyint(3) unsigned")]
    public byte? CareerId { get; set; }
}
