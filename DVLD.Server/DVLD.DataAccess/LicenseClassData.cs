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
    public class LicenseClassData
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
        public static async Task<LicenseClass?> FindClassesAsync(string className)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindLicenseClasses", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@className", SqlDbType.NVarChar).Value = className;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapLicenseClass(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public static async Task<LicenseClass?> FindClassesAsync(int id)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindLicenseClassesById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapLicenseClass(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<List<LicenseClass>> GetAllClassesAsync()
        {
            List<LicenseClass> list = new List<LicenseClass>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllLicenses", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                    list.Add(MapLicenseClass(reader));
            }
            catch (Exception)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return list;
        }
    }
}
