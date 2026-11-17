using System.Data;
using DVLD.Shared.Models;
using DVLD.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using DVLD.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations;

public sealed class RefreshTokenData(AppDbContext context) : IRefreshTokenData
    {
    public async Task<long> AddAsync(
        RefreshToken newToken,
        CancellationToken cancellationToken)
    {
        context.RefreshTokens.Add(newToken);
        await context.SaveChangesAsync(cancellationToken);
        return newToken.RefreshTokenId;
    }

    public async Task<RefreshToken?> GetByHashAsync(
        string tokenHash,
        CancellationToken cancellationToken)
    {
        var token = await context.RefreshTokens
                    .AsNoTracking()
                    .SingleOrDefaultAsync(rt => rt.TokenHash == tokenHash, cancellationToken);
        return token;
    }

    public async Task RevokeAsync(string tokenHash, CancellationToken cancellationToken)
    {
        var token = await context.RefreshTokens
                    .Where(rt => rt.RevokedAt == null && rt.TokenHash == tokenHash)
                    .SingleOrDefaultAsync(cancellationToken);
        if (token is null)
            return;
        token.RevokedAt = DateTime.UtcNow;
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task RevokeFamilyAsync(
        int userId,
        Guid tokenFamilyId,
        CancellationToken cancellationToken)
    {
        var token = await context.RefreshTokens
                    .Where(rt => rt.RevokedAt == null && rt.UserId == userId && rt.TokenFamilyId == tokenFamilyId)
                    .ExecuteUpdateAsync(setter =>
                                            setter.SetProperty(s => s.RevokedAt, DateTime.UtcNow), cancellationToken);
    }

    public async Task<long> RotateAsync(
        long oldRefreshTokenId,
        string oldTokenHash,
        string newTokenHash,
        DateTime newExpiresAt,
        CancellationToken cancellationToken)
    {
        await using var transaction = await context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            DateTime dateNow = DateTime.UtcNow;
            var oldToken = await context.RefreshTokens
                        .Where(rt => rt.RefreshTokenId == oldRefreshTokenId && rt.TokenHash == oldTokenHash
                                && rt.RevokedAt == null && rt.ExpiresAt > dateNow)
                        .Select(rt => new RefreshToken
                        {
                            UserId = rt.UserId,
                            TokenFamilyId = rt.TokenFamilyId,
                            TokenHash = newTokenHash,
                            ExpiresAt = newExpiresAt
                        }).FirstOrDefaultAsync(cancellationToken);

            long newRefreshTokenId = await AddAsync(oldToken!, cancellationToken);

            var token = await context.RefreshTokens
                            .Where(rt => rt.RevokedAt == null && rt.RefreshTokenId == oldRefreshTokenId
                                    && rt.ExpiresAt > dateNow)
                            .FirstOrDefaultAsync(cancellationToken);
            token!.RevokedAt = dateNow;
            token.ReplacedByTokenId = newRefreshTokenId;
            await context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return newRefreshTokenId;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            return -1;
        }
    }
}
