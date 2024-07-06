using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("chrDepartments")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrDepartment
{
    [Column("schoolID", TypeName = "int(10) unsigned")]
    public uint SchoolId { get; set; }

    [Key]
    [Column("departmentID", TypeName = "int(10) unsigned")]
    public uint DepartmentId { get; set; }

    [Column("departmentName")]
    [StringLength(100)]
    public string DepartmentName { get; set; } = null!;

    [Column("description", TypeName = "mediumtext")]
    public string Description { get; set; } = null!;

    [Column("skillTypeID1", TypeName = "int(10) unsigned")]
    public uint SkillTypeId1 { get; set; }

    [Column("skillTypeID2", TypeName = "int(10) unsigned")]
    public uint SkillTypeId2 { get; set; }

    [Column("skillTypeID3", TypeName = "int(10) unsigned")]
    public uint SkillTypeId3 { get; set; }

    [Column("graphicID", TypeName = "int(10) unsigned")]
    public uint GraphicId { get; set; }
}
