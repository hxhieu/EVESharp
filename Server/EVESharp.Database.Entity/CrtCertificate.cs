using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("crtCertificates")]
[Index("CorpId", Name = "corpID")]
[Index("CategoryId", Name = "crtCertificates_IX_category")]
[Index("ClassId", Name = "crtCertificates_IX_class")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrtCertificate
{
    [Key]
    [Column("certificateID", TypeName = "int(11)")]
    public int CertificateId { get; set; }

    [Column("categoryID", TypeName = "tinyint(3) unsigned")]
    public byte? CategoryId { get; set; }

    [Column("classID", TypeName = "int(11)")]
    public int? ClassId { get; set; }

    [Column("grade", TypeName = "tinyint(4)")]
    public sbyte? Grade { get; set; }

    [Column("corpID", TypeName = "int(11)")]
    public int? CorpId { get; set; }

    [Column("iconID", TypeName = "int(11)")]
    public int? IconId { get; set; }

    [Column("description")]
    [StringLength(500)]
    public string? Description { get; set; }
}
