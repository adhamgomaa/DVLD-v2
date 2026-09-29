using DVLD.Shared.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class UserData
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
        public static async Task<User?> GetUserAsync(int id)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindUserByUserId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapUser(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<User?> GetUserAsync(string username)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindUserByUsername", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapUser(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<User?> GetUserAsync(string username, string password)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindUserByUsernameAndPassword", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapUser(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<List<UserInfo>> GetAllUsersAsync()
        {
            List<UserInfo> users = new List<UserInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllUsers", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
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
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return users;
        }

        public static async Task<int> AddNewUserAsync(User newUser)
        {
            int userId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
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
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                userId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                userId = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return userId;
        }

        public static async Task<bool> UpdateUserAsync(User updateUser)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = updateUser.PersonId;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = updateUser.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = updateUser.Password;
                command.Parameters.Add("@isActive", SqlDbType.Bit).Value = updateUser.IsActive;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateUser.UserId;
                await connection.OpenAsync();
                rowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                rowAffected = 0;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static async Task<bool> DeleteUserAsync(int id)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                rowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                rowAffected = 0;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }
        public static async Task<bool> IsUserExistAsync(int id)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsUserExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }
        public static async Task<bool> IsUserExistAsync(string username)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsUserExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }
        public static async Task<bool> IsUserExistByPersonIdAsync(int personId)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsUserExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }
    }
}
