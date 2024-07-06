using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("ramInstallationTypeDefaultContents")]
[Index("AssemblyLineTypeId", Name = "assemblyLineTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamInstallationTypeDefaultContent
{
    [Key]
    [Column("installationTypeID", TypeName = "int(11)")]
    public int InstallationTypeId { get; set; }

    [Column("assemblyLineTypeID", TypeName = "int(11)")]
    public int AssemblyLineTypeId { get; set; }

    [Column("UIGroupingID", TypeName = "int(11)")]
    public int UigroupingId { get; set; }

    [Column("quantity", TypeName = "int(11)")]
    public int Quantity { get; set; }

    [Column("costInstall")]
    public float CostInstall { get; set; }

    [Column("costPerHour")]
    public float CostPerHour { get; set; }

    [Column("restrictionMask", TypeName = "int(11)")]
    public int RestrictionMask { get; set; }

    [Column("discountPerGoodStandingPoint")]
    public float DiscountPerGoodStandingPoint { get; set; }

    [Column("surchargePerBadStandingPoint")]
    public float SurchargePerBadStandingPoint { get; set; }

    [Column("minimumStanding")]
    public float MinimumStanding { get; set; }

    [Column("minimumCharSecurity")]
    public float MinimumCharSecurity { get; set; }

    [Column("minimumCorpSecurity")]
    public float MinimumCorpSecurity { get; set; }

    [Column("maximumCharSecurity")]
    public float MaximumCharSecurity { get; set; }

    [Column("maximumCorpSecurity")]
    public float MaximumCorpSecurity { get; set; }
}
