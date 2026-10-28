namespace DVLD.Business.Interfaces;

public interface IRefreshTokenService
{
    Task<string> CreateAsync(
        int userId,
        Guid tokenFamilyId,
        TimeSpan lifetime,
        CancellationToken cancellationToken);

    Task<RefreshTokenRefreshResult> RotateAsync(
        string refreshToken,
        TimeSpan lifetime,
        CancellationToken cancellationToken);

    Task LogoutAsync(string refreshToken, CancellationToken cancellationToken);
}
