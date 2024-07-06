using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invItemsLocked")]
[Index("StationId", Name = "stationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvItemsLocked
{
    [Key]
    [Column("itemID", TypeName = "int(10) unsigned")]
    public uint ItemId { get; set; }

    [Column("stationID", TypeName = "int(10) unsigned")]
    public uint StationId { get; set; }

    [Column("corporationID", TypeName = "int(10) unsigned")]
    public uint CorporationId { get; set; }

    [Column("voteCaseID", TypeName = "int(11)")]
    public int VoteCaseId { get; set; }
}
