using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess.Implementations
{
    public sealed class TestTypeData(DatabaseSettings databaseSettings) : ITestTypeData
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
        public async Task<TestType?> FindTypesAsync(TestTypeEnum id, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindTestType", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapTestType(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }
        public async Task<List<TestType>> GetAllTypesAsync(CancellationToken cancellationToken)
        {
            List<TestType> types = new List<TestType>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while(await reader.ReadAsync(cancellationToken))
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
                throw;
            }
            return types;
        }
        public async Task<bool> UpdateTypesAsync(TestType updateTypes, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateTestType", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = updateTypes.Title;
                command.Parameters.Add("@description", SqlDbType.NVarChar).Value = updateTypes.Description;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = updateTypes.Fees;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = updateTypes.TestTypeId;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                rowAffected = 0;
            }
            return rowAffected > 0;
        }
    }
}
