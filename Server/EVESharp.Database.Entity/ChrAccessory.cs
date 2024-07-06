using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrAccessories")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrAccessory
{
    [Key]
    [Column("accessoryID", TypeName = "int(10) unsigned")]
    public uint AccessoryId { get; set; }

    [Column("accessoryName")]
    [StringLength(100)]
    public string AccessoryName { get; set; } = null!;
}
