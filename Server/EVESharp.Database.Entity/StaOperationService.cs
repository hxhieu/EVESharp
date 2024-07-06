using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("OperationId", "ServiceId")]
[Table("staOperationServices")]
[Index("ServiceId", Name = "serviceID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class StaOperationService
{
    [Key]
    [Column("operationID", TypeName = "tinyint(3) unsigned")]
    public byte OperationId { get; set; }

    [Key]
    [Column("serviceID", TypeName = "int(11)")]
    public int ServiceId { get; set; }
}
