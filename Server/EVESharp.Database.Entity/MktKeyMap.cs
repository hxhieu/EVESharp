using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("mktKeyMap")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MktKeyMap
{
    [Key]
    [Column("accountKey", TypeName = "int(10) unsigned")]
    public uint AccountKey { get; set; }

    [Column("accountType")]
    [StringLength(100)]
    public string AccountType { get; set; } = null!;

    [Column("accountName")]
    [StringLength(100)]
    public string AccountName { get; set; } = null!;

    [Column("description")]
    [StringLength(100)]
    public string Description { get; set; } = null!;
}
