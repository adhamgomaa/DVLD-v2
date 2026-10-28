using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface IUserData
{
    Task<User?> GetUserAsync(int id, CancellationToken cancellationToken);
    Task<User?> GetUserAsync(string username, CancellationToken cancellationToken);
    Task<User?> GetUserAsync(string username, string password, CancellationToken cancellationToken);
    Task<List<UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<int> AddNewUserAsync(User newUser, CancellationToken cancellationToken);
    Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsUserExistAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken);
    Task<bool> IsUserExistByPersonIdAsync(int personId, CancellationToken cancellationToken);
}
