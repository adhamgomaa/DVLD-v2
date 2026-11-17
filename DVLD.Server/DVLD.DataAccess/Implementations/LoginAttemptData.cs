using System.Data;
using DVLD.Shared.Models;
using DVLD.DataAccess.Interfaces;
using DVLD.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace DVLD.DataAccess.Implementations;

public sealed class LoginAttemptData(AppDbContext context) : ILoginAttemptData
{
    public async Task AddAsync(
        LoginAttempt newLogin,
        CancellationToken cancellationToken)
    {
        context.LoginAttempts.Add(newLogin);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken)
    {
        if (take is < 1 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(take), "The result count must be between 1 and 100.");
        }

        var logins = await context.LoginAttempts
                        .AsNoTracking()
                        .OrderByDescending(l => l.AttemptedAtUtc)
                        .ThenByDescending(l => l.LoginAttemptId)
                        .Take(take)
                        .ToListAsync(cancellationToken);
        return logins;
    }
}
