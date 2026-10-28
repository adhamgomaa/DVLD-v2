using DVLD.DataAccess.Interfaces;
using System.Data;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.Data.SqlClient;

namespace DVLD.DataAccess.Implementations
{
    public sealed class ApplicationData(DatabaseSettings databaseSettings) : IApplicationData
    {
        public async Task<int> AddNewAppAsync(Application newApplication, CancellationToken cancellationToken)
        {
            int appId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
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
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                appId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                appId = -1;
            }
            return appId;
        }

        public async Task<bool> UpdateAppAsync(Application UpdateApplication, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
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
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                rowAffected = 0;
            }
            return rowAffected > 0;
        }

        public async Task<bool> DeleteAppAsync(int appId, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_DeleteApp", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@appId", SqlDbType.Int).Value = appId;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await cmd.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                rowAffected = 0;
            }
            return rowAffected > 0;
        }
        public async Task<Application?> FindAppAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindAppById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@appId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
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
            }
        }
    }
}
