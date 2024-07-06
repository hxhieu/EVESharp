using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveLiveUpdates")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveLiveUpdate
{
    [Key]
    [Column("updateID", TypeName = "int(11)")]
    public int UpdateId { get; set; }

    [Column("updateName")]
    [StringLength(100)]
    public string? UpdateName { get; set; }

    [Column("description")]
    [StringLength(100)]
    public string? Description { get; set; }

    [Column("machoVersionMin", TypeName = "int(11)")]
    public int? MachoVersionMin { get; set; }

    [Column("machoVersionMax", TypeName = "int(11)")]
    public int? MachoVersionMax { get; set; }

    [Column("buildNumberMin", TypeName = "int(11)")]
    public int? BuildNumberMin { get; set; }

    [Column("buildNumberMax", TypeName = "int(11)")]
    public int? BuildNumberMax { get; set; }

    [Column("methodName")]
    [StringLength(100)]
    public string? MethodName { get; set; }

    [Column("objectID")]
    [StringLength(100)]
    public string? ObjectId { get; set; }

    [Column("codeType")]
    [StringLength(100)]
    public string? CodeType { get; set; }

    [Column("code", TypeName = "blob")]
    public byte[]? Code { get; set; }
}
