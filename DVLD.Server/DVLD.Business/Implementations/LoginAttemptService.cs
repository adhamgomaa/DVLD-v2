using DVLD.Business.Interfaces;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations;

public sealed class LoginAttemptService(ILoginAttemptData loginAttemptData) : ILoginAttemptService
{
    public Task RecordAsync(
        LoginAttempt newLogin,
        CancellationToken cancellationToken)
    {
        if (newLogin.AttemptedUserName.Length > 256)
        {
            throw new ArgumentException("Attempted username cannot exceed 256 characters.", nameof(newLogin.AttemptedUserName));
        }

        if (newLogin.ClientIpAddress?.Length > 45)
        {
            throw new ArgumentException("Client IP address cannot exceed 45 characters.", nameof(newLogin.ClientIpAddress));
        }

        return loginAttemptData.AddAsync(newLogin, cancellationToken);
    }

    public Task<IReadOnlyList<LoginAttempt>> GetRecentAsync(
        int take,
        CancellationToken cancellationToken)
    {
        return loginAttemptData.GetRecentAsync(take, cancellationToken);
    }
}
