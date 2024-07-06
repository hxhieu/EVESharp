using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EVESharp.Database.Entity;

[PrimaryKey("CharacterId", "FriendId")]
[Table("chrFriends")]
[Index("FriendId", Name = "fk_friendID_idx")]
[MySqlCharSet("utf8mb3")]
[MySqlCollation("utf8mb3_unicode_ci")]
public partial class ChrFriend
{
    [Key]
    [Column("characterID", TypeName = "int(10) unsigned")]
    public uint CharacterId { get; set; }

    [Key]
    [Column("friendID", TypeName = "int(10) unsigned")]
    public uint FriendId { get; set; }

    [Column("status", TypeName = "int(11)")]
    public int? Status { get; set; }

    [ForeignKey("CharacterId")]
    [InverseProperty("ChrFriendCharacters")]
    public virtual ChrInformation Character { get; set; } = null!;

    [ForeignKey("FriendId")]
    [InverseProperty("ChrFriendFriends")]
    public virtual ChrInformation Friend { get; set; } = null!;
}
