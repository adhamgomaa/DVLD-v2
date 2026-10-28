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
    public sealed class ApplicationTypeData(DatabaseSettings databaseSettings) : IApplicationTypeData
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
        public async Task<ApplicationType?> FindTypesAsync(AppTypeEnum id, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindAppTypeById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapApplication(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<ApplicationType?> FindTypesAsync(string title, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindAppTypeByTitle", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = title;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = command.ExecuteReader();
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapApplication(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<List<ApplicationType>> GetAllTypesAsync(CancellationToken cancellationToken)
        {
            List<ApplicationType> result = new List<ApplicationType>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllAppTypes", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                    result.Add(new ApplicationType
                    (
                        (AppTypeEnum)reader.GetInt32(reader.GetOrdinal("ID")),
                        reader.GetString(reader.GetOrdinal("Title")),
                        reader.GetDecimal(reader.GetOrdinal("Fees"))
                    ));
            }
            catch (SqlException)
            {
                throw;
            }
            return result;
        }
        public async Task<bool> UpdateTypesAsync(ApplicationType updateTypes, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateAppType", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@title", SqlDbType.NVarChar).Value = updateTypes.Title;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = updateTypes.Fees;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)updateTypes.TypeID;
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
