using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrBookmarks")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrBookmark
{
    [Key]
    [Column("bookmarkID", TypeName = "int(10) unsigned")]
    public uint BookmarkId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("itemID", TypeName = "int(10) unsigned")]
    public uint ItemId { get; set; }

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("memo")]
    [StringLength(85)]
    public string Memo { get; set; } = null!;

    [Column("comment", TypeName = "text")]
    public string Comment { get; set; } = null!;

    [Column("created", TypeName = "bigint(20) unsigned")]
    public ulong Created { get; set; }

    [Column("x")]
    public double X { get; set; }

    [Column("y")]
    public double Y { get; set; }

    [Column("z")]
    public double Z { get; set; }

    [Column("locationID", TypeName = "int(10) unsigned")]
    public uint LocationId { get; set; }
}
