using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Keyless]
[Table("chrSkillQueue")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrSkillQueue
{
    [Column("orderIndex", TypeName = "int(10) unsigned")]
    public uint OrderIndex { get; set; }

    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Column("skillItemID", TypeName = "int(10) unsigned")]
    public uint SkillItemId { get; set; }

    [Column("level", TypeName = "int(10) unsigned")]
    public uint Level { get; set; }
}
