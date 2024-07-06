using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("ShipTypeId", "CertificateId")]
[Table("crtRecommendations")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CrtRecommendation
{
    [Key]
    [Column("shipTypeID", TypeName = "int(10) unsigned")]
    public uint ShipTypeId { get; set; }

    [Key]
    [Column("certificateID", TypeName = "int(10) unsigned")]
    public uint CertificateId { get; set; }

    [Column("recommendationLevel", TypeName = "int(10) unsigned")]
    public uint RecommendationLevel { get; set; }

    [Column("recommendationID", TypeName = "int(10) unsigned")]
    public uint RecommendationId { get; set; }
}
