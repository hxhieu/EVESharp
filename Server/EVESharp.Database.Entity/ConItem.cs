using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("conItems")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ConItem
{
    [Key]
    [Column("id", TypeName = "int(10)")]
    public int Id { get; set; }

    [Column("contractID", TypeName = "int(10)")]
    public int ContractId { get; set; }

    [Column("itemTypeID", TypeName = "int(10)")]
    public int ItemTypeId { get; set; }

    [Column("quantity", TypeName = "int(10)")]
    public int Quantity { get; set; }

    [Column("inCrate")]
    public bool InCrate { get; set; }

    [Column("itemID", TypeName = "int(11)")]
    public int? ItemId { get; set; }
}
