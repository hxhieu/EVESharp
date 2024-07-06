using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("Type", "ObjectId")]
[Table("cluAddresses")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CluAddress
{
    [Key]
    [Column("type")]
    [StringLength(30)]
    public string Type { get; set; } = null!;

    [Key]
    [Column("objectID", TypeName = "int(11)")]
    public int ObjectId { get; set; }

    [Column("nodeID", TypeName = "bigint(20)")]
    public long NodeId { get; set; }
}
