using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("FromId", "ToId")]
[Table("allRelationships")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class AllRelationship
{
    [Key]
    [Column("fromID", TypeName = "int(11)")]
    public int FromId { get; set; }

    [Key]
    [Column("toID", TypeName = "int(11)")]
    public int ToId { get; set; }

    [Column("relationship", TypeName = "int(11)")]
    public int Relationship { get; set; }
}
