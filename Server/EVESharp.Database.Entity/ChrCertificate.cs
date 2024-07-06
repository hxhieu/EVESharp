using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CharacterId", "CertificateId")]
[Table("chrCertificates")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrCertificate
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Key]
    [Column("certificateID", TypeName = "int(10) unsigned")]
    public uint CertificateId { get; set; }

    [Column("grantDate", TypeName = "bigint(20)")]
    public long GrantDate { get; set; }

    [Column("visibilityFlags", TypeName = "tinyint(4)")]
    public sbyte VisibilityFlags { get; set; }
}
