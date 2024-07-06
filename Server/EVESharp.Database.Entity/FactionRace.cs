using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FactionId", "RaceId")]
[Table("factionRaces")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class FactionRace
{
    [Key]
    [Column("factionID", TypeName = "int(10) unsigned")]
    public uint FactionId { get; set; }

    [Key]
    [Column("raceID", TypeName = "int(10) unsigned")]
    public uint RaceId { get; set; }
}
