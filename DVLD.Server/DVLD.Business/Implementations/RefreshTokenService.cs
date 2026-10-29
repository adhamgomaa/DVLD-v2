using System.Security.Cryptography;
using System.Text;
using DVLD.Business.Interfaces;
using DVLD.DataAccess.Interfaces;

namespace DVLD.Business.Implementations;

public sealed class RefreshTokenService(
    IRefreshTokenData refreshTokenData,
    IUserService userService) : IRefreshTokenService
{
    public async Task<string> CreateAsync(
        int userId,
        Guid tokenFamilyId,
        TimeSpan lifetime,
        CancellationToken cancellationToken)
    {
        ValidateLifetime(lifetime);
        var token = GenerateToken();
        var tokenHash = HashToken(token);
        var expiresAt = DateTime.UtcNow.Add(lifetime);

        var refreshTokenId = await refreshTokenData.AddAsync(
            userId,
            tokenHash,
            expiresAt,
            tokenFamilyId,
            cancellationToken);

        if (refreshTokenId <= 0)
        {
            throw new InvalidOperationException("The refresh token could not be persisted.");
        }

        return token;
    }

    public async Task<RefreshTokenRefreshResult> RotateAsync(
        string refreshToken,
        TimeSpan lifetime,
        CancellationToken cancellationToken)
    {
        ValidateLifetime(lifetime);

        var oldTokenHash = HashToken(refreshToken);
        var current = await refreshTokenData.GetByHashAsync(oldTokenHash, cancellationToken);
        if (current is null)
        {
            return new RefreshTokenRefreshResult(null, null);
        }

        if (current.RevokedAt is not null)
        {
            if (current.ReplacedByTokenId is not null)
            {
                await refreshTokenData.RevokeFamilyAsync(
                    current.UserId,
                    current.TokenFamilyId,
                    cancellationToken);
            }

            return new RefreshTokenRefreshResult(null, null);
        }

        if (current.ExpiresAt <= DateTime.UtcNow)
        {
            await refreshTokenData.RevokeAsync(oldTokenHash, cancellationToken);
            return new RefreshTokenRefreshResult(null, null);
        }

        var user = await userService.FindUserAsync(current.UserId, cancellationToken);
        if (user is null || !user.IsActive)
        {
            await refreshTokenData.RevokeFamilyAsync(
                current.UserId,
                current.TokenFamilyId,
                cancellationToken);
            return new RefreshTokenRefreshResult(null, null);
        }

        var newRefreshToken = GenerateToken();
        var newTokenHash = HashToken(newRefreshToken);
        var newExpiresAt = DateTime.UtcNow.Add(lifetime);

        var newRefreshTokenId = await refreshTokenData.RotateAsync(
            current.RefreshTokenId,
            oldTokenHash,
            newTokenHash,
            newExpiresAt,
            cancellationToken);

        if (newRefreshTokenId <= 0)
        {
            var afterFailedRotation = await refreshTokenData.GetByHashAsync(oldTokenHash, cancellationToken);
            if (afterFailedRotation?.RevokedAt is not null &&
                afterFailedRotation.ReplacedByTokenId is not null)
            {
                await refreshTokenData.RevokeFamilyAsync(
                    afterFailedRotation.UserId,
                    afterFailedRotation.TokenFamilyId,
                    cancellationToken);
            }

            return new RefreshTokenRefreshResult(null, null);
        }

        return new RefreshTokenRefreshResult(user, newRefreshToken);
    }

    public async Task LogoutAsync(string refreshToken, CancellationToken cancellationToken)
    {
        var tokenHash = HashToken(refreshToken);
        var current = await refreshTokenData.GetByHashAsync(tokenHash, cancellationToken);
        if (current is not null)
        {
            await refreshTokenData.RevokeFamilyAsync(
                current.UserId,
                current.TokenFamilyId,
                cancellationToken);
        }
    }

    private static string GenerateToken()
    {
        var tokenBytes = RandomNumberGenerator.GetBytes(64);
        return Convert.ToBase64String(tokenBytes);
    }

    private static string HashToken(string token)
    {
        return Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(token)));
    }

    private static void ValidateLifetime(TimeSpan lifetime)
    {
        if (lifetime <= TimeSpan.Zero)
        {
            throw new ArgumentOutOfRangeException(nameof(lifetime), "Refresh-token lifetime must be positive.");
        }
    }
}
