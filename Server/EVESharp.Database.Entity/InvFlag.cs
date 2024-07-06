using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invFlags")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvFlag
{
    [Key]
    [Column("flagID", TypeName = "tinyint(3) unsigned")]
    public byte FlagId { get; set; }

    [Column("flagName")]
    [StringLength(100)]
    public string? FlagName { get; set; }

    [Column("flagText")]
    [StringLength(100)]
    public string? FlagText { get; set; }

    [Column("flagType")]
    [StringLength(20)]
    public string? FlagType { get; set; }

    [Column("orderID", TypeName = "smallint(6)")]
    public short? OrderId { get; set; }
}
