using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("Key", "OwnerId")]
[Table("mktWallets")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class MktWallet
{
    [Key]
    [Column("key", TypeName = "int(11)")]
    public int Key { get; set; }

    [Key]
    [Column("ownerID", TypeName = "int(11)")]
    public int OwnerId { get; set; }

    [Column("balance")]
    public double Balance { get; set; }
}
