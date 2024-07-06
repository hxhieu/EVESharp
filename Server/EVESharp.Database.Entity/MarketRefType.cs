using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("market_refTypes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MarketRefType
{
    [Key]
    [Column("refTypeID", TypeName = "int(10) unsigned")]
    public uint RefTypeId { get; set; }

    [Column("refTypeText")]
    [StringLength(100)]
    public string RefTypeText { get; set; } = null!;

    [Column("description", TypeName = "mediumtext")]
    public string Description { get; set; } = null!;
}
