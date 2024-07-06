using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("billTypes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class BillType
{
    [Key]
    [Column("billTypeID", TypeName = "int(10) unsigned")]
    public uint BillTypeId { get; set; }

    [Column("billTypeName")]
    [StringLength(100)]
    public string BillTypeName { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string Description { get; set; } = null!;
}
