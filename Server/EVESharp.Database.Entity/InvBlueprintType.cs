using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invBlueprintTypes")]
[Index("ParentBlueprintTypeId", Name = "parentBlueprintTypeID")]
[Index("ProductTypeId", Name = "productTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvBlueprintType
{
    [Key]
    [Column("blueprintTypeID", TypeName = "smallint(6)")]
    public short BlueprintTypeId { get; set; }

    [Column("parentBlueprintTypeID", TypeName = "smallint(6)")]
    public short? ParentBlueprintTypeId { get; set; }

    [Column("productTypeID", TypeName = "smallint(6)")]
    public short? ProductTypeId { get; set; }

    [Column("productionTime", TypeName = "int(11)")]
    public int? ProductionTime { get; set; }

    [Column("techLevel", TypeName = "smallint(6)")]
    public short? TechLevel { get; set; }

    [Column("researchProductivityTime", TypeName = "int(11)")]
    public int? ResearchProductivityTime { get; set; }

    [Column("researchMaterialTime", TypeName = "int(11)")]
    public int? ResearchMaterialTime { get; set; }

    [Column("researchCopyTime", TypeName = "int(11)")]
    public int? ResearchCopyTime { get; set; }

    [Column("researchTechTime", TypeName = "int(11)")]
    public int? ResearchTechTime { get; set; }

    [Column("productivityModifier", TypeName = "int(11)")]
    public int? ProductivityModifier { get; set; }

    [Column("materialModifier", TypeName = "smallint(6)")]
    public short? MaterialModifier { get; set; }

    [Column("wasteFactor", TypeName = "smallint(6)")]
    public short? WasteFactor { get; set; }

    [Column("chanceOfReverseEngineering")]
    public double? ChanceOfReverseEngineering { get; set; }

    [Column("maxProductionLimit", TypeName = "int(11)")]
    public int? MaxProductionLimit { get; set; }
}
