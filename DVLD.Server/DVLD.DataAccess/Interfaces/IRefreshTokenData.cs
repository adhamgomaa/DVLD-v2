using DVLD.Shared.Models;

namespace DVLD.DataAccess.Interfaces;

public interface IRefreshTokenData
{
    Task<long> AddAsync(
        RefreshToken newToken,
        CancellationToken cancellationToken);

    Task<RefreshToken?> GetByHashAsync(string tokenHash, CancellationToken cancellationToken);

    Task RevokeAsync(string tokenHash, CancellationToken cancellationToken);

    Task RevokeFamilyAsync(int userId, Guid tokenFamilyId, CancellationToken cancellationToken);

    Task<long> RotateAsync(
        long oldRefreshTokenId,
        string oldTokenHash,
        string newTokenHash,
        DateTime newExpiresAt,
        CancellationToken cancellationToken);
}
