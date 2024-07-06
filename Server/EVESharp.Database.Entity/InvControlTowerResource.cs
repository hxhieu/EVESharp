using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("ControlTowerTypeId", "ResourceTypeId")]
[Table("invControlTowerResources")]
[Index("FactionId", Name = "factionID")]
[Index("Purpose", Name = "purpose")]
[Index("ResourceTypeId", Name = "resourceTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvControlTowerResource
{
    [Key]
    [Column("controlTowerTypeID", TypeName = "smallint(6)")]
    public short ControlTowerTypeId { get; set; }

    [Key]
    [Column("resourceTypeID", TypeName = "smallint(6)")]
    public short ResourceTypeId { get; set; }

    [Column("purpose", TypeName = "tinyint(4)")]
    public sbyte? Purpose { get; set; }

    [Column("quantity", TypeName = "int(11)")]
    public int? Quantity { get; set; }

    [Column("minSecurityLevel")]
    public double? MinSecurityLevel { get; set; }

    [Column("factionID", TypeName = "int(11)")]
    public int? FactionId { get; set; }
}
