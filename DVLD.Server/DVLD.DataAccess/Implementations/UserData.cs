using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess.Implementations
{
    public sealed class UserData(DatabaseSettings databaseSettings) : IUserData
    {
        private static User MapUser(SqlDataReader reader)
        {
            return new User
                    (
                        reader.GetInt32(reader.GetOrdinal("UserID")),
                        reader.GetInt32(reader.GetOrdinal("PersonID")),
                        reader.GetString(reader.GetOrdinal("Username")),
                        reader.GetString(reader.GetOrdinal("Password")),
                        reader.GetBoolean(reader.GetOrdinal("IsActive"))
                    );
        }
        public async Task<User?> GetUserAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindUserByUserId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapUser(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<User?> GetUserAsync(string username, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindUserByUsername", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapUser(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<User?> GetUserAsync(string username, string password, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindUserByUsernameAndPassword", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapUser(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<List<UserInfo>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            List<UserInfo> users = new List<UserInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllUsers", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    users.Add
                        (
                            new UserInfo
                            (
                                reader.GetInt32(reader.GetOrdinal("UserID")),
                                reader.GetInt32(reader.GetOrdinal("PersonID")),
                                reader.GetString(reader.GetOrdinal("Full Name")),
                                reader.GetString(reader.GetOrdinal("UserName")),
                                reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            )
                        );
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return users;
        }

        public async Task<int> AddNewUserAsync(User newUser, CancellationToken cancellationToken)
        {
            int userId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_AddNewUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = newUser.PersonId;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = newUser.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = newUser.Password;
                command.Parameters.Add("@isActive", SqlDbType.Bit).Value = newUser.IsActive;
                SqlParameter outputId = new SqlParameter("@userId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                userId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                userId = -1;
            }
            return userId;
        }

        public async Task<bool> UpdateUserAsync(User updateUser, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = updateUser.PersonId;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = updateUser.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = updateUser.Password;
                command.Parameters.Add("@isActive", SqlDbType.Bit).Value = updateUser.IsActive;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateUser.UserId;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                rowAffected = 0;
            }
            return rowAffected > 0;
        }

        public async Task<bool> DeleteUserAsync(int id, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                rowAffected = 0;
            }
            return rowAffected > 0;
        }
        public async Task<bool> IsUserExistAsync(int id, CancellationToken cancellationToken)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsUserExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
            }
            return isFound;
        }
        public async Task<bool> IsUserExistAsync(string username, CancellationToken cancellationToken)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsUserExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
            }
            return isFound;
        }
        public async Task<bool> IsUserExistByPersonIdAsync(int personId, CancellationToken cancellationToken)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsUserExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
            }
            return isFound;
        }
    }
}
