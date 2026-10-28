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
    public sealed class LicenseClassData(DatabaseSettings databaseSettings) : ILicenseClassData
    {
        private static LicenseClass MapLicenseClass(SqlDataReader reader)
        {
            return new LicenseClass
                (
                    reader.GetInt32(reader.GetOrdinal("LicenseClassID")),
                    reader.GetString(reader.GetOrdinal("ClassName")),
                    reader.GetString(reader.GetOrdinal("ClassDescription")),
                    reader.GetInt32(reader.GetOrdinal("MinimumAllowedAge")),
                    reader.GetInt32(reader.GetOrdinal("DefaultValidityLength")),
                    reader.GetDecimal(reader.GetOrdinal("ClassFees"))
                );
        }
        public async Task<LicenseClass?> FindClassesAsync(string className, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindLicenseClasses", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@className", SqlDbType.NVarChar).Value = className;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapLicenseClass(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }
        public async Task<LicenseClass?> FindClassesAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindLicenseClassesById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapLicenseClass(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<List<LicenseClass>> GetAllClassesAsync(CancellationToken cancellationToken)
        {
            List<LicenseClass> list = new List<LicenseClass>();
            await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
            await using SqlCommand command = new SqlCommand("SP_GetAllLicenses", connection);
            command.CommandType = CommandType.StoredProcedure;
            await connection.OpenAsync(cancellationToken);
            await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
            while (await reader.ReadAsync(cancellationToken))
                list.Add(MapLicenseClass(reader));

            return list;
        }
    }
}
