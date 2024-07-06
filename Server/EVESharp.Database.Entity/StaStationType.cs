using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("staStationTypes")]
[Index("DockingBayGraphicId", Name = "dockingBayGraphicID")]
[Index("HangarGraphicId", Name = "hangarGraphicID")]
[Index("OperationId", Name = "operationID")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class StaStationType
{
    [Key]
    [Column("stationTypeID", TypeName = "smallint(6)")]
    public short StationTypeId { get; set; }

    [Column("dockingBayGraphicID", TypeName = "smallint(6)")]
    public short? DockingBayGraphicId { get; set; }

    [Column("hangarGraphicID", TypeName = "smallint(6)")]
    public short? HangarGraphicId { get; set; }

    [Column("dockEntryX")]
    public double? DockEntryX { get; set; }

    [Column("dockEntryY")]
    public double? DockEntryY { get; set; }

    [Column("dockEntryZ")]
    public double? DockEntryZ { get; set; }

    [Column("dockOrientationX")]
    public double? DockOrientationX { get; set; }

    [Column("dockOrientationY")]
    public double? DockOrientationY { get; set; }

    [Column("dockOrientationZ")]
    public double? DockOrientationZ { get; set; }

    [Column("operationID", TypeName = "tinyint(3) unsigned")]
    public byte? OperationId { get; set; }

    [Column("officeSlots", TypeName = "tinyint(4)")]
    public sbyte? OfficeSlots { get; set; }

    [Column("reprocessingEfficiency")]
    public double? ReprocessingEfficiency { get; set; }

    [Column("conquerable")]
    public bool? Conquerable { get; set; }
}
