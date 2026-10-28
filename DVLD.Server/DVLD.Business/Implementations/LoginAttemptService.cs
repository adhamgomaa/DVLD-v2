using DVLD.Business.Interfaces;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Entities;

namespace DVLD.Business.Implementations;

public sealed class LoginAttemptService(ILoginAttemptData loginAttemptData) : ILoginAttemptService
{
    public Task RecordAsync(
        int? userId,
        string attemptedUserName,
        bool succeeded,
        string? clientIpAddress,
        CancellationToken cancellationToken)
    {
        if (attemptedUserName.Length > 256)
        {
            throw new ArgumentException("Attempted username cannot exceed 256 characters.", nameof(attemptedUserName));
        }

        if (clientIpAddress?.Length > 45)
        {
            throw new ArgumentException("Client IP address cannot exceed 45 characters.", nameof(clientIpAddress));
        }

        return loginAttemptData.AddAsync(
            userId,
            attemptedUserName,
            succeeded,
            clientIpAddress,
            DateTime.UtcNow,
            cancellationToken);
    }

    public Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken)
    {
        return loginAttemptData.GetRecentAsync(take, cancellationToken);
    }
}
