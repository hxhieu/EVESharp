using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrRaces")]
[Index("GraphicId", Name = "graphicID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrRace
{
    [Key]
    [Column("raceID", TypeName = "tinyint(3) unsigned")]
    public byte RaceId { get; set; }

    [Column("raceName")]
    [StringLength(100)]
    public string? RaceName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("shortDescription")]
    [StringLength(500)]
    public string? ShortDescription { get; set; }
}
