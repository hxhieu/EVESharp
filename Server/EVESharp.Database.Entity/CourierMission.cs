using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("courierMissions")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class CourierMission
{
    [Key]
    [Column("missionID", TypeName = "int(10) unsigned")]
    public uint MissionId { get; set; }

    [Column("kind", TypeName = "tinyint(3) unsigned")]
    public byte Kind { get; set; }

    [Column("state", TypeName = "tinyint(3) unsigned")]
    public byte State { get; set; }

    [Column("availabilityID", TypeName = "int(10) unsigned")]
    public uint? AvailabilityId { get; set; }

    [Column("inOrder", TypeName = "tinyint(3) unsigned")]
    public byte InOrder { get; set; }

    [Column("description", TypeName = "text")]
    public string Description { get; set; } = null!;

    [Column("issuerID", TypeName = "int(10) unsigned")]
    public uint? IssuerId { get; set; }

    [Column("assigneeID", TypeName = "int(10) unsigned")]
    public uint? AssigneeId { get; set; }

    [Column("acceptFee")]
    public double AcceptFee { get; set; }

    [Column("acceptorID", TypeName = "int(10) unsigned")]
    public uint? AcceptorId { get; set; }

    [Column("dateIssued", TypeName = "int(10) unsigned")]
    public uint DateIssued { get; set; }

    [Column("dateExpires", TypeName = "int(10) unsigned")]
    public uint DateExpires { get; set; }

    [Column("dateAccepted", TypeName = "int(10) unsigned")]
    public uint DateAccepted { get; set; }

    [Column("dateCompleted", TypeName = "int(10) unsigned")]
    public uint DateCompleted { get; set; }

    [Column("totalReward")]
    public double TotalReward { get; set; }

    [Column("tracking", TypeName = "tinyint(3) unsigned")]
    public byte Tracking { get; set; }

    [Column("pickupStationID", TypeName = "int(10) unsigned")]
    public uint? PickupStationId { get; set; }

    [Column("craterID", TypeName = "int(10) unsigned")]
    public uint? CraterId { get; set; }

    [Column("dropStationID", TypeName = "int(10) unsigned")]
    public uint? DropStationId { get; set; }

    [Column("volume")]
    public double Volume { get; set; }

    [Column("pickupSolarSystemID", TypeName = "int(10) unsigned")]
    public uint? PickupSolarSystemId { get; set; }

    [Column("pickupRegionID", TypeName = "int(10) unsigned")]
    public uint? PickupRegionId { get; set; }

    [Column("dropSolarSystemID", TypeName = "int(10) unsigned")]
    public uint? DropSolarSystemId { get; set; }

    [Column("dropRegionID", TypeName = "int(10) unsigned")]
    public uint? DropRegionId { get; set; }
}
