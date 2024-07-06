using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Keyless]
[Table("chrNotes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrNote
{
    [Column("itemID", TypeName = "int(10) unsigned")]
    public uint ItemId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint? OwnerId { get; set; }

    [Column("note", TypeName = "text")]
    public string? Note { get; set; }
}
