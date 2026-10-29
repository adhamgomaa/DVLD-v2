namespace DVLD.Shared.Entities;

public sealed class LoginAttempt
{
    public long LoginAttemptId { get; init; }
    public int? UserId { get; init; }
    public string AttemptedUserName { get; init; } = string.Empty;
    public bool Succeeded { get; init; }
    public DateTime AttemptedAtUtc { get; init; }
    public string? ClientIpAddress { get; init; }
}
