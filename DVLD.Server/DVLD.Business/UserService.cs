using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class UserService
    {
        public static async Task<bool> AddNewUserAsync(User newUser)
        {
            newUser.Password = CryptographyService.Hashing(newUser.Password);
            newUser.UserId = await UserData.AddNewUserAsync(newUser);
            return newUser.UserId != -1;
        }

        public static async Task<bool> UpdateUserAsync(User updateUser)
        {
            updateUser.Password = CryptographyService.Hashing(updateUser.Password);
            return await UserData.UpdateUserAsync(updateUser);
        }

        public static async Task<User?> FindUserAsync(int id)
        {
            User? user = await UserData.GetUserAsync(id);
            if (user != null)
                return user;
            return null;
        }

        public static async Task<User?> FindUserAsync(string username)
        {
            User? user = await UserData.GetUserAsync(username);
            if (user != null)
                return user;
            return null;
        }

        public static async Task<User?> FindUserAsync(string username, string password)
        {
            password = CryptographyService.Hashing(password);
            User? user = await UserData.GetUserAsync(username, password);
            if (user != null)
                return user;
            return null;
        }

        public static async Task<List<UserInfo>> GetUsersAsync()
        {
            return await UserData.GetAllUsersAsync();
        }

        public static async Task<bool> IsUserExistAsync(int id)
        {
            return await UserData.IsUserExistAsync(id);
        }

        public static async Task<bool> IsUserExistAsync(string username)
        {
            return await UserData.IsUserExistAsync(username);
        }

        public static async Task<bool> IsUserExistByPersonIdAsync(int id)
        {
            return await UserData.IsUserExistByPersonIdAsync(id);
        }

        public static async Task<bool> DeleteUserAsync(int id)
        {
            return await UserData.DeleteUserAsync(id);
        }
    }
}
