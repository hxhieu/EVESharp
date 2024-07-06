using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crtRelationships")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrtRelationship
{
    [Key]
    [Column("relationshipID", TypeName = "int(10) unsigned")]
    public uint RelationshipId { get; set; }

    [Column("parentID", TypeName = "int(10) unsigned")]
    public uint ParentId { get; set; }

    [Column("parentTypeID", TypeName = "int(10) unsigned")]
    public uint ParentTypeId { get; set; }

    [Column("parentLevel", TypeName = "int(10) unsigned")]
    public uint ParentLevel { get; set; }

    [Column("childID", TypeName = "int(10) unsigned")]
    public uint ChildId { get; set; }

    [Column("childTypeID", TypeName = "int(10) unsigned")]
    public uint ChildTypeId { get; set; }
}
