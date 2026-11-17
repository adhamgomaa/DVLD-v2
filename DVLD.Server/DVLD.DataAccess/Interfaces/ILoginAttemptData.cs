using DVLD.Shared.Models;

namespace DVLD.DataAccess.Interfaces;

public interface ILoginAttemptData
{
    Task AddAsync(
        LoginAttempt newLogin,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken);
}
