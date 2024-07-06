using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invItems")]
[Index("LocationId", Name = "locationID")]
[Index("OwnerId", Name = "ownerID")]
[Index("TypeId", Name = "typeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvItem
{
    [Key]
    [Column("itemID", TypeName = "int(10) unsigned")]
    public uint ItemId { get; set; }

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("locationID", TypeName = "int(10) unsigned")]
    public uint LocationId { get; set; }

    [Column("flag", TypeName = "int(10) unsigned")]
    public uint Flag { get; set; }

    [Column("contraband", TypeName = "int(10) unsigned")]
    public uint Contraband { get; set; }

    [Column("singleton", TypeName = "int(10) unsigned")]
    public uint Singleton { get; set; }

    [Column("quantity", TypeName = "int(10) unsigned")]
    public uint Quantity { get; set; }

    [Column("customInfo", TypeName = "text")]
    public string? CustomInfo { get; set; }

    [Column("nodeID", TypeName = "bigint(20)")]
    public long? NodeId { get; set; }
}
