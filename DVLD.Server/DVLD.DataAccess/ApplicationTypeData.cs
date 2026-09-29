using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class ApplicationTypeData
    {
        private static ApplicationType MapApplication(SqlDataReader reader)
        {
            return new ApplicationType
                    (
                        (AppTypeEnum)reader.GetInt32(reader.GetOrdinal("ApplicationTypesID")),
                        reader.GetString(reader.GetOrdinal("ApplicationTypesTitle")),
                        reader.GetDecimal(reader.GetOrdinal("ApplicationFees"))
                    );
        }
        public static async Task<ApplicationType?> FindTypesAsync(AppTypeEnum id)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindAppTypeById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapApplication(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<ApplicationType?> FindTypesAsync(string title)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindAppTypeByTitle", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                await connection.OpenAsync();
                await using SqlDataReader reader = command.ExecuteReader();
                if (!await reader.ReadAsync())
                    return null;
                return MapApplication(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<List<ApplicationType>> GetAllTypesAsync()
        {
            List<ApplicationType> result = new List<ApplicationType>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllAppTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                    result.Add(new ApplicationType
                    (
                        (AppTypeEnum)reader.GetInt32(reader.GetOrdinal("ID")),
                        reader.GetString(reader.GetOrdinal("Title")),
                        reader.GetDecimal(reader.GetOrdinal("Fees"))
                    ));
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return result;
        }
        public static async Task<bool> UpdateTypesAsync(ApplicationType updateTypes)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateAppType", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = updateTypes.Title;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = updateTypes.Fees;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)updateTypes.TypeID;
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
    }
}
