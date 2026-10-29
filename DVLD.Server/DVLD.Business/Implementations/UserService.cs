using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class UserService(IUserData userData, ICryptographyService cryptographyService) : IUserService
    {
        public async Task<bool> AddNewUserAsync(User newUser, CancellationToken cancellationToken)
        {
            newUser.Password = cryptographyService.Hashing(newUser.Password);
            newUser.UserId = await userData.AddNewUserAsync(newUser, cancellationToken);
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

        public async Task<User?> FindUserAsync(int id, CancellationToken cancellationToken)
        {
            User? user = await userData.GetUserAsync(id, cancellationToken);
            if (user != null)
                return user;
            return null;
        }

        public async Task<User?> FindUserAsync(string username, CancellationToken cancellationToken)
        {
            User? user = await userData.GetUserAsync(username, cancellationToken);
            if (user != null)
                return user;
            return null;
        }

        public async Task<User?> FindUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            password = cryptographyService.Hashing(password);
            User? user = await userData.GetUserAsync(username, password, cancellationToken);
            if (user != null)
                return user;
            return null;
        }

        public async Task<List<UserInfo>> GetUsersAsync(CancellationToken cancellationToken)
        {
            return await userData.GetAllUsersAsync(cancellationToken);
        }

        public async Task<bool> IsUserExistAsync(int id, CancellationToken cancellationToken)
        {
            return await userData.IsUserExistAsync(id, cancellationToken);
        }

        public async Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken)
        {
            return await userData.IsUserExistAsync(username, cancellationToken);
        }

        public async Task<bool> IsUserExistByPersonIdAsync(int id, CancellationToken cancellationToken)
        {
            return await userData.IsUserExistByPersonIdAsync(id, cancellationToken);
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            return await userData.DeleteUserAsync(id, cancellationToken);
        }
    }
}
