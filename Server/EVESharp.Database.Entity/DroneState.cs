using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("droneState")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class DroneState
{
    [Key]
    [Column("droneID", TypeName = "int(10) unsigned")]
    public uint DroneId { get; set; }

    [Column("solarSystemID", TypeName = "int(10) unsigned")]
    public uint SolarSystemId { get; set; }

    [Column("ownerID", TypeName = "int(10) unsigned")]
    public uint OwnerId { get; set; }

    [Column("controllerID", TypeName = "int(10) unsigned")]
    public uint ControllerId { get; set; }

    [Column("activityState", TypeName = "int(10) unsigned")]
    public uint ActivityState { get; set; }

    [Column("typeID", TypeName = "int(10) unsigned")]
    public uint TypeId { get; set; }

    [Column("controllerOwnerID", TypeName = "int(10) unsigned")]
    public uint ControllerOwnerId { get; set; }
}
