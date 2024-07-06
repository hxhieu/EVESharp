using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrCombatLogs")]
[Index("FinalCharacterId", Name = "finalCharacterID")]
[Index("FinalCorporationId", Name = "finalCorporationID")]
[Index("SolarSystemId", Name = "solarSystemID")]
[Index("VictimCharacterId", Name = "victimCharacterID")]
[Index("VictimCorporationId", Name = "victimCorporationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrCombatLog
{
    [Key]
    [Column("killID", TypeName = "int(10) unsigned")]
    public uint KillId { get; set; }

    [Column("solarSystemID", TypeName = "int(10) unsigned")]
    public uint SolarSystemId { get; set; }

    [Column("moonID", TypeName = "int(10) unsigned")]
    public uint MoonId { get; set; }

    [Column("victimCharacterID", TypeName = "int(10) unsigned")]
    public uint VictimCharacterId { get; set; }

    [Column("victimCorporationID", TypeName = "int(10) unsigned")]
    public uint VictimCorporationId { get; set; }

    [Column("victimAllianceID", TypeName = "int(10) unsigned")]
    public uint? VictimAllianceId { get; set; }

    [Column("victimFactionID", TypeName = "int(10) unsigned")]
    public uint? VictimFactionId { get; set; }

    [Column("victimShipTypeID", TypeName = "int(10) unsigned")]
    public uint VictimShipTypeId { get; set; }

    [Column("victimDamageTaken", TypeName = "double unsigned")]
    public double VictimDamageTaken { get; set; }

    [Column("finalCharacterID", TypeName = "int(10) unsigned")]
    public uint FinalCharacterId { get; set; }

    [Column("finalCorporationID", TypeName = "int(10) unsigned")]
    public uint FinalCorporationId { get; set; }

    [Column("finalAllianceID", TypeName = "int(10) unsigned")]
    public uint? FinalAllianceId { get; set; }

    [Column("finalFactionID", TypeName = "int(10) unsigned")]
    public uint? FinalFactionId { get; set; }

    [Column("finalDamageDone", TypeName = "double unsigned")]
    public double FinalDamageDone { get; set; }

    [Column("finalSecurityStatus", TypeName = "double unsigned")]
    public double FinalSecurityStatus { get; set; }

    [Column("finalShipTypeID", TypeName = "int(10) unsigned")]
    public uint FinalShipTypeId { get; set; }

    [Column("finalWeaponTypeID", TypeName = "int(10) unsigned")]
    public uint FinalWeaponTypeId { get; set; }

    [Column("killTime", TypeName = "bigint(20)")]
    public long KillTime { get; set; }

    [Column("killBlob", TypeName = "double unsigned")]
    public double KillBlob { get; set; }
}
