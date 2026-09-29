using System.Data;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.Data.SqlClient;

namespace DVLD.DataAccess
{
    public class ApplicationData
    {
        public static async Task<int> AddNewAppAsync(Application newApplication)
        {
            int appId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CreateNewApp", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = newApplication.PersonId;
                command.Parameters.Add("@appType", SqlDbType.Int).Value = (int)newApplication.Type;
                command.Parameters.Add("@status", SqlDbType.TinyInt).Value = (byte)newApplication.AppStatus;
                command.Parameters.Add("@statusDate", SqlDbType.DateTime).Value = newApplication.StatusDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = newApplication.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newApplication.UserId;
                SqlParameter outputId = new SqlParameter("@appId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                appId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                appId = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return appId;
        }

        public static async Task<bool> UpdateAppAsync(Application UpdateApplication)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateApp", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = UpdateApplication.PersonId;
                command.Parameters.Add("@appDate", SqlDbType.DateTime).Value = UpdateApplication.AppDate;
                command.Parameters.Add("@appType", SqlDbType.Int).Value = (int)UpdateApplication.Type;
                command.Parameters.Add("@status", SqlDbType.TinyInt).Value = (byte)UpdateApplication.AppStatus;
                command.Parameters.Add("@statusDate", SqlDbType.DateTime).Value = UpdateApplication.StatusDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = UpdateApplication.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = UpdateApplication.UserId;
                command.Parameters.Add("@appId", SqlDbType.Int).Value = UpdateApplication.AppID;
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

        public static async Task<bool> DeleteAppAsync(int appId)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_DeleteApp", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@appId", SqlDbType.Int).Value = appId;
                await connection.OpenAsync();
                rowAffected = await cmd.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                rowAffected = 0;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }
        public static async Task<Application?> FindAppAsync(int id)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindAppById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@appId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return new Application
                    (
                        reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                        reader.GetInt32(reader.GetOrdinal("ApplicantPersonID")),
                        reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                        (AppTypeEnum)reader.GetInt32(reader.GetOrdinal("ApplicationTypesID")),
                        (AppStatusEnum)reader.GetByte(reader.GetOrdinal("ApplicationStatus")),
                        reader.GetDateTime(reader.GetOrdinal("LastStatusDate")),
                        reader.GetDecimal(reader.GetOrdinal("PaidFees")),
                        reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                    );
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
