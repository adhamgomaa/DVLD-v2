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
    public class TestTypeData
    {
        private static TestType MapTestType(SqlDataReader reader)
        {
            return new TestType
                (
                    (TestTypeEnum)reader.GetInt32(reader.GetOrdinal("TestTypeID")),
                    reader.GetString(reader.GetOrdinal("TestTypeTitle")),
                    reader.GetString(reader.GetOrdinal("TestTypeDescription")),
                    reader.GetDecimal(reader.GetOrdinal("TestTypeFees"))
                );
        }
        public static async Task<TestType?> FindTypesAsync(TestTypeEnum id)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindTestType", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapTestType(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public static async Task<List<TestType>> GetAllTypesAsync()
        {
            List<TestType> types = new List<TestType>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while(await reader.ReadAsync())
                    types.Add(new TestType
                            (
                                (TestTypeEnum)reader.GetInt32(reader.GetOrdinal("ID")),
                                reader.GetString(reader.GetOrdinal("Title")),
                                reader.GetString(reader.GetOrdinal("Description")),
                                reader.GetDecimal(reader.GetOrdinal("Fees"))
                            ));
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return types;
        }
        public static async Task<bool> UpdateTypesAsync(TestType updateTypes)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateTestType", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = updateTypes.Title;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = updateTypes.Description;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = updateTypes.Fees;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = updateTypes.TestTypeId;
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
