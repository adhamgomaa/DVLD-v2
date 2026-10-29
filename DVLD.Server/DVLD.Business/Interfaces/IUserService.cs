using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface IUserService
{
    Task<bool> AddNewUserAsync(User newUser, CancellationToken cancellationToken);
    Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken);
    Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword, CancellationToken cancellationToken);
    Task<User?> FindUserAsync(int id, CancellationToken cancellationToken);
    Task<User?> FindUserAsync(string username, CancellationToken cancellationToken);
    Task<User?> FindUserAsync(string username, string password, CancellationToken cancellationToken);
    Task<List<UserInfo>> GetUsersAsync(CancellationToken cancellationToken);
    Task<bool> IsUserExistAsync(int id, CancellationToken cancellationToken);
    Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken);
    Task<bool> IsUserExistByPersonIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken);
}
