using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crpActivities")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrpActivity
{
    [Key]
    [Column("activityID", TypeName = "tinyint(3) unsigned")]
    public byte ActivityId { get; set; }

    [Column("activityName")]
    [StringLength(100)]
    public string? ActivityName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }
}
