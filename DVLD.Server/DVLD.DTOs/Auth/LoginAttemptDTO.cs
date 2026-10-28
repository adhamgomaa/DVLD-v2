namespace DVLD.DTOs.Auth;

/// <summary>Describes a successful or failed login attempt.</summary>
public sealed record LoginAttemptDTO(
    long LoginAttemptId,
    int? UserId,
    string AttemptedUserName,
    bool Succeeded,
    DateTime AttemptedAtUtc,
    string? ClientIpAddress);
