using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Keyless]
[Table("chrOwnerNote")]
[Index("NoteId", Name = "noteID", IsUnique = true)]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrOwnerNote
{
    [Column("noteID", TypeName = "int(10) unsigned")]
    public uint NoteId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("label", TypeName = "text")]
    public string? Label { get; set; }

    [Column("note", TypeName = "text")]
    public string? Note { get; set; }
}
