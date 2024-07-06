using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("eveConstants")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class EveConstant
{
    [Key]
    [Column("constantID")]
    [StringLength(128)]
    public string ConstantId { get; set; } = null!;

    [Column("constantValue", TypeName = "int(10) unsigned")]
    public uint ConstantValue { get; set; }
}
