using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("ramCompletedStatuses")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class RamCompletedStatus
{
    [Key]
    [Column("completedStatusID", TypeName = "int(10) unsigned")]
    public uint CompletedStatusId { get; set; }

    [Column("completedStatusName")]
    [StringLength(100)]
    public string CompletedStatusName { get; set; } = null!;

    [Column("completedStatusText")]
    [StringLength(100)]
    public string CompletedStatusText { get; set; } = null!;
}
