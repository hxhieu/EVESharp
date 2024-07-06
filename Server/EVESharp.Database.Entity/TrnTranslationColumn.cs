using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("trnTranslationColumns")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class TrnTranslationColumn
{
    [Column("tcGroupID", TypeName = "smallint(6)")]
    public short? TcGroupId { get; set; }

    [Key]
    [Column("tcID", TypeName = "smallint(6)")]
    public short TcId { get; set; }

    [Column("tableName")]
    [StringLength(256)]
    public string TableName { get; set; } = null!;

    [Column("columnName")]
    [StringLength(128)]
    public string ColumnName { get; set; } = null!;

    [Column("masterID")]
    [StringLength(128)]
    public string? MasterId { get; set; }
}
