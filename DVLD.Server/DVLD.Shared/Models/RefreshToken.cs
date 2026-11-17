using System;
using System.Collections.Generic;

namespace DVLD.Shared.Models;

public partial class RefreshToken
{
    public long RefreshTokenId { get; set; }

    public int UserId { get; set; }

    public string TokenHash { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime ExpiresAt { get; set; }

    public DateTime? RevokedAt { get; set; }

    public long? ReplacedByTokenId { get; set; }

    public Guid TokenFamilyId { get; set; }

    public ICollection<RefreshToken> InverseReplacedByToken { get; set; } = new List<RefreshToken>();

    public RefreshToken? ReplacedByToken { get; set; }

    public User User { get; set; } = null!;
}
