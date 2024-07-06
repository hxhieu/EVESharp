using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("staOperations")]
[Index("ActivityId", Name = "activityID")]
[Index("AmarrStationTypeId", Name = "amarrStationTypeID")]
[Index("CaldariStationTypeId", Name = "caldariStationTypeID")]
[Index("GallenteStationTypeId", Name = "gallenteStationTypeID")]
[Index("JoveStationTypeId", Name = "joveStationTypeID")]
[Index("MinmatarStationTypeId", Name = "minmatarStationTypeID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class StaOperation
{
    [Column("activityID", TypeName = "tinyint(3) unsigned")]
    public byte? ActivityId { get; set; }

    [Key]
    [Column("operationID", TypeName = "tinyint(3) unsigned")]
    public byte OperationId { get; set; }

    [Column("operationName")]
    [StringLength(100)]
    public string? OperationName { get; set; }

    [Column("description")]
    [StringLength(1000)]
    public string? Description { get; set; }

    [Column("fringe", TypeName = "tinyint(4)")]
    public sbyte? Fringe { get; set; }

    [Column("corridor", TypeName = "tinyint(4)")]
    public sbyte? Corridor { get; set; }

    [Column("hub", TypeName = "tinyint(4)")]
    public sbyte? Hub { get; set; }

    [Column("border", TypeName = "tinyint(4)")]
    public sbyte? Border { get; set; }

    [Column("ratio", TypeName = "tinyint(4)")]
    public sbyte? Ratio { get; set; }

    [Column("caldariStationTypeID", TypeName = "smallint(6)")]
    public short? CaldariStationTypeId { get; set; }

    [Column("minmatarStationTypeID", TypeName = "smallint(6)")]
    public short? MinmatarStationTypeId { get; set; }

    [Column("amarrStationTypeID", TypeName = "smallint(6)")]
    public short? AmarrStationTypeId { get; set; }

    [Column("gallenteStationTypeID", TypeName = "smallint(6)")]
    public short? GallenteStationTypeId { get; set; }

    [Column("joveStationTypeID", TypeName = "smallint(6)")]
    public short? JoveStationTypeId { get; set; }
}
