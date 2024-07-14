using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVESharp.Database.Entity;

[Table ("account")]
[Index ("AccountName", Name = "accountName", IsUnique = true)]
[MySqlCharSet ("utf8mb3")]
[MySqlCollation ("utf8mb3_unicode_ci")]
public partial class Account
{
    [Key]
    [Column ("accountID", TypeName = "int(10) unsigned")]
    public uint AccountId { get; set; }

    [Column ("accountName")]
    [StringLength (48)]
    public string AccountName { get; set; } = null!;

    [Column ("password", TypeName = "blob")]
    public byte [] Password { get; set; } = null!;

    [Column ("role", TypeName = "bigint(20) unsigned")]
    public ulong Role { get; set; }

    [Column ("online")]
    public bool Online { get; set; }

    [Column ("banned")]
    public bool Banned { get; set; }

    [Column ("proxyNodeID", TypeName = "bigint(20)")]
    public long ProxyNodeId { get; set; }

    [Column ("password_v2")]
    [MaxLength (80)]
    public string? PasswordV2 { get; set; }
}
