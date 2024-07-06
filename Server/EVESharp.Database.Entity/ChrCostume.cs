using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrCostumes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrCostume
{
    [Key]
    [Column("costumeID", TypeName = "int(10) unsigned")]
    public uint CostumeId { get; set; }

    [Column("costumeName")]
    [StringLength(100)]
    public string CostumeName { get; set; } = null!;
}
