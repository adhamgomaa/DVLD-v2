using DVLD.Shared.Entities;

namespace DVLD.DataAccess.Interfaces;

public interface ILoginAttemptData
{
    Task AddAsync(
        int? userId,
        string attemptedUserName,
        bool succeeded,
        string? clientIpAddress,
        DateTime attemptedAtUtc,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken);
}
