using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("dgmExpressions")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class DgmExpression
{
    [Key]
    [Column("expressionID", TypeName = "int(11)")]
    public int ExpressionId { get; set; }

    [Column("operandID", TypeName = "int(11)")]
    public int? OperandId { get; set; }

    [Column("arg1", TypeName = "int(11)")]
    public int? Arg1 { get; set; }

    [Column("arg2", TypeName = "int(11)")]
    public int? Arg2 { get; set; }

    [Column("expressionValue")]
    [StringLength(100)]
    public string? ExpressionValue { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("expressionName")]
    [StringLength(500)]
    public string? ExpressionName { get; set; }

    [Column("expressionTypeID", TypeName = "int(11)")]
    public int? ExpressionTypeId { get; set; }

    [Column("expressionGroupID", TypeName = "smallint(6)")]
    public short? ExpressionGroupId { get; set; }

    [Column("expressionAttributeID", TypeName = "smallint(6)")]
    public short? ExpressionAttributeId { get; set; }
}
