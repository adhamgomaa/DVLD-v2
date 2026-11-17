using DVLD.Shared.Models;

namespace DVLD.Business.Interfaces;

public interface ILoginAttemptService
{
    Task RecordAsync(
        LoginAttempt newLogin,
        CancellationToken cancellationToken);

    Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken);
}
