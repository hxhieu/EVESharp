using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("agtAgents")]
[Index("AgentTypeId", Name = "agentTypeID")]
[Index("CorporationId", Name = "agtAgents_IX_corporation")]
[Index("StationId", Name = "agtAgents_IX_station")]
[Index("DivisionId", Name = "divisionID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AgtAgent
{
    [Key]
    [Column("agentID", TypeName = "int(11)")]
    public int AgentId { get; set; }

    [Column("divisionID", TypeName = "tinyint(3) unsigned")]
    public byte? DivisionId { get; set; }

    [Column("corporationID", TypeName = "int(11)")]
    public int? CorporationId { get; set; }

    [Column("stationID", TypeName = "int(11)")]
    public int? StationId { get; set; }

    [Column("level", TypeName = "tinyint(4)")]
    public sbyte? Level { get; set; }

    [Column("quality", TypeName = "smallint(6)")]
    public short? Quality { get; set; }

    [Column("agentTypeID", TypeName = "tinyint(3) unsigned")]
    public byte? AgentTypeId { get; set; }
}
