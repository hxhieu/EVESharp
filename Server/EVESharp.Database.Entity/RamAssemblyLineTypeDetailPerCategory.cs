using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("AssemblyLineTypeId", "CategoryId")]
[Table("ramAssemblyLineTypeDetailPerCategory")]
[Index("CategoryId", Name = "categoryID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamAssemblyLineTypeDetailPerCategory
{
    [Key]
    [Column("assemblyLineTypeID", TypeName = "tinyint(3) unsigned")]
    public byte AssemblyLineTypeId { get; set; }

    [Key]
    [Column("categoryID", TypeName = "tinyint(3) unsigned")]
    public byte CategoryId { get; set; }

    [Column("timeMultiplier")]
    public double? TimeMultiplier { get; set; }

    [Column("materialMultiplier")]
    public double? MaterialMultiplier { get; set; }
}
