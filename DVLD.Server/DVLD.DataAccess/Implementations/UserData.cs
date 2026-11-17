using DVLD.DataAccess.Data;
using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess.Implementations
{
    public sealed class UserData(AppDbContext context) : IUserData
    {
        public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([id], cancellationToken);
            return user;
        }

        public async Task<User?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            var user = await context.Users.AsNoTracking()
                        .SingleOrDefaultAsync(u => u.Username == username, cancellationToken);
            return user;
        }

        public async Task<List<UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var users = await context.Users.AsNoTracking()
                        .Select(u => new UserInfo
                        {
                            UserId = u.UserId,
                            PersonId = u.PersonId,
                            FullName = u.Person.FirstName + " " + u.Person.SecondName + " " + u.Person.ThirdName + " " + u.Person.LastName,
                            UserName = u.Username,
                            IsActive = u.IsActive
                        }).ToListAsync(cancellationToken);
            return users;
        }

        public async Task<int> AddNewUserAsync(User newUser, CancellationToken cancellationToken)
        {
            context.Users.Add(newUser);
            await context.SaveChangesAsync(cancellationToken);
            return newUser.UserId;
        }

        public async Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([updateUser.UserId], cancellationToken);
            if(user is null)
                return false;
            user.IsActive = updateUser.IsActive;
            user.Password = updateUser.Password;
            user.PersonId = updateUser.PersonId;
            user.Username = updateUser.Username;

            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            var user = await context.Users.FindAsync([id], cancellationToken);
            if(user is null)
                return false;
            context.Users.Remove(user);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }
        public async Task<bool> IsUserExistAsync(int id, CancellationToken cancellationToken)
        {
            bool isExist = await context.Users.AsNoTracking().AnyAsync(u => u.UserId == id, cancellationToken);
            return isExist;
        }
        public async Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken)
        {
            bool isExist = await context.Users.AsNoTracking().AnyAsync(u => u.Username == username, cancellationToken);
            return isExist;
        }
        public async Task<bool> IsUserExistByPersonIdAsync(int personId, CancellationToken cancellationToken)
        {
            bool isExist = await context.Users.AsNoTracking().AnyAsync(u => u.PersonId == personId, cancellationToken);
            return isExist;
        }
    }
}
