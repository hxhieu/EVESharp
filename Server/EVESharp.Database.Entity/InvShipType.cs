using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("invShipTypes")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class InvShipType
{
    [Key]
    [Column("shipTypeID", TypeName = "int(10) unsigned")]
    public uint ShipTypeId { get; set; }

    [Column("weaponTypeID", TypeName = "int(10) unsigned")]
    public uint? WeaponTypeId { get; set; }

    [Column("miningTypeID", TypeName = "int(10) unsigned")]
    public uint? MiningTypeId { get; set; }

    [Column("skillTypeID", TypeName = "int(10) unsigned")]
    public uint? SkillTypeId { get; set; }
}
