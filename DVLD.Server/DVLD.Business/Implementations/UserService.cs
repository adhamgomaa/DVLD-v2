using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations
{
    public sealed class UserService(IUserData userData, ICryptographyService cryptographyService) : IUserService
    {
        public async Task<bool> AddNewUserAsync(User newUser, CancellationToken cancellationToken)
        {
            newUser.Password = cryptographyService.Hashing(newUser.Password);
            await userData.AddNewUserAsync(newUser, cancellationToken);
            return newUser.UserId != -1;
        }

        public async Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken)
        {
            updateUser.Password = cryptographyService.Hashing(updateUser.Password);
            return await userData.UpdateUserAsync(updateUser, cancellationToken);
        }

        public async Task<bool> ChangePasswordAsync(
            int userId,
            string currentPassword,
            string newPassword,
            CancellationToken cancellationToken)
        {
            User? user = await userData.GetUserAsync(userId, cancellationToken);
            if (user is null || !BCrypt.Net.BCrypt.Verify(currentPassword, user.Password))
                return false;

            user.Password = cryptographyService.Hashing(newPassword);
            return await userData.UpdateUserAsync(user, cancellationToken);
        }

        public Task<User?> FindUserAsync(int id, CancellationToken cancellationToken) =>
            userData.GetUserAsync(id, cancellationToken);

        public Task<User?> FindUserAsync(string username, CancellationToken cancellationToken) =>
            userData.GetUserAsync(username, cancellationToken);

        public Task<List<UserInfo>> GetUsersAsync(CancellationToken cancellationToken) =>
            userData.GetAllUsersAsync(cancellationToken);

        public Task<bool> IsUserExistAsync(int id, CancellationToken cancellationToken) =>
            userData.IsUserExistAsync(id, cancellationToken);

        public Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken) =>
            userData.IsUserExistAsync(username, cancellationToken);

        public Task<bool> IsUserExistByPersonIdAsync(int id, CancellationToken cancellationToken) =>
            userData.IsUserExistByPersonIdAsync(id, cancellationToken);

        public Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken) =>
            userData.DeleteUserAsync(id, cancellationToken);
    }
}
