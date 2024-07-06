using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("cacheOwners")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CacheOwner
{
    [Key]
    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("ownerName")]
    [StringLength(100)]
    public string OwnerName { get; set; } = null!;

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }
}
