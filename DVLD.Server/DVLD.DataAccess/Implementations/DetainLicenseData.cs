using DVLD.DataAccess.Interfaces;
using DVLD.Shared.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.DataAccess.Implementations
{
    public sealed class DetainLicenseData(DatabaseSettings databaseSettings) : IDetainLicenseData
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
        public async Task<int> AddNewDetainAsync(DetainLicense newDetain, CancellationToken cancellationToken)
        {
            int DetainId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
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
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                DetainId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                DetainId = -1;
            }
            return DetainId;
        }

        public async Task<bool> UpdateDetainLicenseAsync(DetainLicense updateDetain, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateDetainLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = updateDetain.LicenseID;
                command.Parameters.Add("@detainFees", SqlDbType.Decimal).Value = updateDetain.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateDetain.UserID;
                command.Parameters.Add("@detainDate", SqlDbType.DateTime).Value = updateDetain.DetainDate;
                command.Parameters.Add("@detainId", SqlDbType.Int).Value = updateDetain.DetainID;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public async Task<DetainLicense?> FindLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDetainedLicenseByLicenseId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = licenseId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapDetain(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<List<DetainLicenseInfo>> GetDetainedLicensesAsync(CancellationToken cancellationToken)
        {
            List<DetainLicenseInfo> list = new List<DetainLicenseInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllDetainedLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
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
                throw;
            }
            return list;
        }

        public async Task<int> ReleaseDetainedLicenseAsync(DetainLicense releaseLicense, CancellationToken cancellationToken)
        {
            int releaseAppId = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
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
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                releaseAppId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                throw;
            }
            return releaseAppId;
        }

        public async Task<bool> IsDetainedLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsDetainedLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = licenseId;
                await connection.OpenAsync(cancellationToken);
                object? result = await command.ExecuteScalarAsync(cancellationToken);
                if (result != null)
                    return true;
                return false;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}
