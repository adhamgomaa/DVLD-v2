using DVLD.Shared.Entities;

namespace DVLD.Business;

public sealed record RefreshTokenRefreshResult(
    User? User,
    string? NewRefreshToken)
{
    public bool Succeeded => User is not null && NewRefreshToken is not null;
}
