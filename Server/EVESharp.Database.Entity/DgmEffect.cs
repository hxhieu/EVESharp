using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("dgmEffects")]
[Index("DischargeAttributeId", Name = "dischargeAttributeID")]
[Index("DurationAttributeId", Name = "durationAttributeID")]
[Index("FalloffAttributeId", Name = "falloffAttributeID")]
[Index("FittingUsageChanceAttributeId", Name = "fittingUsageChanceAttributeID")]
[Index("GraphicId", Name = "graphicID")]
[Index("NpcActivationChanceAttributeId", Name = "npcActivationChanceAttributeID")]
[Index("NpcUsageChanceAttributeId", Name = "npcUsageChanceAttributeID")]
[Index("RangeAttributeId", Name = "rangeAttributeID")]
[Index("TrackingSpeedAttributeId", Name = "trackingSpeedAttributeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class DgmEffect
{
    [Key]
    [Column("effectID", TypeName = "smallint(6)")]
    public short EffectId { get; set; }

    [Column("effectName")]
    [StringLength(400)]
    public string? EffectName { get; set; }

    [Column("effectCategory", TypeName = "smallint(6)")]
    public short? EffectCategory { get; set; }

    [Column("preExpression", TypeName = "int(11)")]
    public int? PreExpression { get; set; }

    [Column("postExpression", TypeName = "int(11)")]
    public int? PostExpression { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("guid")]
    [StringLength(60)]
    public string? Guid { get; set; }

    [Column("graphicID", TypeName = "smallint(6)")]
    public short? GraphicId { get; set; }

    [Column("isOffensive")]
    public bool? IsOffensive { get; set; }

    [Column("isAssistance")]
    public bool? IsAssistance { get; set; }

    [Column("durationAttributeID", TypeName = "smallint(6)")]
    public short? DurationAttributeId { get; set; }

    [Column("trackingSpeedAttributeID", TypeName = "smallint(6)")]
    public short? TrackingSpeedAttributeId { get; set; }

    [Column("dischargeAttributeID", TypeName = "smallint(6)")]
    public short? DischargeAttributeId { get; set; }

    [Column("rangeAttributeID", TypeName = "smallint(6)")]
    public short? RangeAttributeId { get; set; }

    [Column("falloffAttributeID", TypeName = "smallint(6)")]
    public short? FalloffAttributeId { get; set; }

    [Column("disallowAutoRepeat")]
    public bool? DisallowAutoRepeat { get; set; }

    [Column("published")]
    public bool? Published { get; set; }

    [Column("displayName")]
    [StringLength(100)]
    public string? DisplayName { get; set; }

    [Column("isWarpSafe")]
    public bool? IsWarpSafe { get; set; }

    [Column("rangeChance")]
    public bool? RangeChance { get; set; }

    [Column("electronicChance")]
    public bool? ElectronicChance { get; set; }

    [Column("propulsionChance")]
    public bool? PropulsionChance { get; set; }

    [Column("distribution", TypeName = "tinyint(4)")]
    public sbyte? Distribution { get; set; }

    [Column("sfxName")]
    [StringLength(20)]
    public string? SfxName { get; set; }

    [Column("npcUsageChanceAttributeID", TypeName = "smallint(6)")]
    public short? NpcUsageChanceAttributeId { get; set; }

    [Column("npcActivationChanceAttributeID", TypeName = "smallint(6)")]
    public short? NpcActivationChanceAttributeId { get; set; }

    [Column("fittingUsageChanceAttributeID", TypeName = "smallint(6)")]
    public short? FittingUsageChanceAttributeId { get; set; }
}
