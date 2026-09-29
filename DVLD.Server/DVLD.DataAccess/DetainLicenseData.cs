using DVLD.Shared.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess
{
    public class DetainLicenseData
    {
        private static DetainLicense MapDetain(SqlDataReader reader)
        {
            return new DetainLicense
                (
                    reader.GetInt32(reader.GetOrdinal("DetainID")),
                    reader.GetInt32(reader.GetOrdinal("LicenseID")),
                    reader.GetDateTime(reader.GetOrdinal("DetainDate")),
                    reader.GetDecimal(reader.GetOrdinal("DetainFees")),
                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                    reader.GetBoolean(reader.GetOrdinal("IsReleased")),

                    reader.IsDBNull(reader.GetOrdinal("ReleaseDate"))
                    ? DateTime.Now
                    : reader.GetDateTime(reader.GetOrdinal("ReleaseDate")),

                    reader.IsDBNull(reader.GetOrdinal("ReleasedByUserID"))
                    ? -1
                    : reader.GetInt32(reader.GetOrdinal("ReleasedByUserID")),

                    reader.IsDBNull(reader.GetOrdinal("ReleaseApplicationID"))
                    ? -1
                    : reader.GetInt32(reader.GetOrdinal("ReleaseApplicationID"))
                );
        }
        public static async Task<int> AddNewDetainAsync(DetainLicense newDetain)
        {
            int DetainId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_AddNewDetain", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = newDetain.LicenseID;
                command.Parameters.Add("@detainFees", SqlDbType.Decimal).Value = newDetain.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newDetain.UserID;
                SqlParameter outputId = new SqlParameter("@detainId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                DetainId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                DetainId = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return DetainId;
        }

        public static async Task<bool> UpdateDetainLicenseAsync(DetainLicense updateDetain)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateDetainLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = updateDetain.LicenseID;
                command.Parameters.Add("@detainFees", SqlDbType.Decimal).Value = updateDetain.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateDetain.UserID;
                command.Parameters.Add("@detainDate", SqlDbType.DateTime).Value = updateDetain.DetainDate;
                command.Parameters.Add("@detainId", SqlDbType.Int).Value = updateDetain.DetainID;
                await connection.OpenAsync();
                rowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static async Task<DetainLicense?> FindLicenseAsync(int licenseId)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDetainedLicenseByLicenseId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = licenseId;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapDetain(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<List<DetainLicenseInfo>> GetDetainedLicensesAsync()
        {
            List<DetainLicenseInfo> list = new List<DetainLicenseInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllDetainedLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    list.Add(new DetainLicenseInfo
                        (
                            reader.GetInt32(reader.GetOrdinal("D.ID")),
                            reader.GetInt32(reader.GetOrdinal("L.ID")),
                            reader.GetDateTime(reader.GetOrdinal("D.Date")),
                            reader.GetBoolean(reader.GetOrdinal("Is Released")),
                            reader.GetDecimal(reader.GetOrdinal("Fine Fees")),
                            reader.IsDBNull(reader.GetOrdinal("Release Date"))
                                ? DateTime.Now
                                : reader.GetDateTime(reader.GetOrdinal("Release Date")),
                            reader.GetString(reader.GetOrdinal("National No.")),
                            reader.GetString(reader.GetOrdinal("Full Name")),
                            reader.IsDBNull(reader.GetOrdinal("Release App.ID"))
                                ? -1
                                : reader.GetInt32(reader.GetOrdinal("Release App.ID"))
                        ));
                }
                    
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return list;
        }

        public static async Task<int> ReleaseDetainedLicenseAsync(DetainLicense releaseLicense)
        {
            int releaseAppId = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_ReleaseDetainedLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = releaseLicense.PersonId;
                command.Parameters.Add("@appType", SqlDbType.Int).Value = (int)releaseLicense.Type;
                command.Parameters.Add("@status", SqlDbType.TinyInt).Value = (byte)releaseLicense.AppStatus;
                command.Parameters.Add("@statusDate", SqlDbType.DateTime).Value = releaseLicense.StatusDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = releaseLicense.Fees;
                command.Parameters.Add("@releaseUserId", SqlDbType.Int).Value = releaseLicense.ReleaseByUserId;
                command.Parameters.Add("@detainId", SqlDbType.Int).Value = releaseLicense.DetainID;
                SqlParameter outputId = new SqlParameter("@releaseAppId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                releaseAppId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return releaseAppId;
        }

        public static async Task<bool> IsDetainedLicenseAsync(int licenseId)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsDetainedLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = licenseId;
                await connection.OpenAsync();
                object? result = await command.ExecuteScalarAsync();
                if (result != null)
                    return true;
                return false;
            }
            catch (SqlException)
            {
                return false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
