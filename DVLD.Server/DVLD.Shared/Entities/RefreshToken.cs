namespace DVLD.Shared.Entities;

public sealed class RefreshToken
{
    public long RefreshTokenId { get; init; }
    public int UserId { get; init; }
    public string TokenHash { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime ExpiresAt { get; init; }
    public DateTime? RevokedAt { get; init; }
    public long? ReplacedByTokenId { get; init; }
    public Guid TokenFamilyId { get; init; }
}
