using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("staServices")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class StaService
{
    [Key]
    [Column("serviceID", TypeName = "int(11)")]
    public int ServiceId { get; set; }

    [Column("serviceName")]
    [StringLength(100)]
    public string? ServiceName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }
}
