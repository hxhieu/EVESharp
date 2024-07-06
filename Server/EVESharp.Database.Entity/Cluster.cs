using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[Table("cluster")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class Cluster
{
    [Key]
    [Column("id", TypeName = "bigint(20)")]
    public long Id { get; set; }

    [Column("ip")]
    [StringLength(15)]
    public string Ip { get; set; } = null!;

    [Column("address")]
    public Guid Address { get; set; }

    [Column("port", TypeName = "int(11)")]
    public int Port { get; set; }

    [Column("role")]
    [StringLength(6)]
    public string Role { get; set; } = null!;

    [Column("load")]
    public double Load { get; set; }

    [Column("lastHeartBeat", TypeName = "bigint(20)")]
    public long LastHeartBeat { get; set; }
}
