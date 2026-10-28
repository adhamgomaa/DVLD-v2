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
    public sealed class LicenseData(DatabaseSettings databaseSettings) : ILicenseData
    {
        public async Task<int> AddNewLicenseAsync(License newLicense, CancellationToken cancellationToken)
        {
            int licenseId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CreateLocalLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = newLicense.DriverID;
                command.Parameters.Add("@appId", SqlDbType.Int).Value = newLicense.AppID;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = newLicense.ClassID;
                command.Parameters.Add("@expireDate", SqlDbType.DateTime).Value = newLicense.ExpiredDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = newLicense.Fees;
                command.Parameters.Add("@notes", SqlDbType.NVarChar).Value = newLicense.Notes;
                command.Parameters.Add("@isActive", SqlDbType.Bit).Value = newLicense.IsActive;
                command.Parameters.Add("@issueReason", SqlDbType.TinyInt).Value = newLicense.IssueReason;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newLicense.UserID;
                SqlParameter outputId = new SqlParameter("@licenseId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                licenseId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                throw;
            }
            return licenseId;
        }

        public async Task<bool> UpdateLicenseAsync(License updateLicense, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateLocalLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = updateLicense.DriverID;
                command.Parameters.Add("@appId", SqlDbType.Int).Value = updateLicense.AppID;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = updateLicense.ClassID;
                command.Parameters.Add("@expireDate", SqlDbType.DateTime).Value = updateLicense.ExpiredDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = updateLicense.Fees;
                command.Parameters.Add("@notes", SqlDbType.NVarChar).Value = updateLicense.Notes;
                command.Parameters.Add("@isActive", SqlDbType.Bit).Value = updateLicense.IsActive;
                command.Parameters.Add("@issueReason", SqlDbType.TinyInt).Value = updateLicense.IssueReason;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateLicense.UserID;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = updateLicense.LicenseID;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public async Task<License?> FindLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindLicenseById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = licenseId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                    if (!await reader.ReadAsync(cancellationToken))
                        return null;

                    return new License
                        (
                            reader.GetInt32(reader.GetOrdinal("LicenseID")),
                            reader.GetInt32(reader.GetOrdinal("DriverID")),
                            reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                            reader.GetInt32(reader.GetOrdinal("LicenseClassID")),
                            reader.GetDateTime(reader.GetOrdinal("IssuDate")),
                            reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                            reader.GetDecimal(reader.GetOrdinal("PaidFees")),
                            reader.IsDBNull(reader.GetOrdinal("Notes"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("Notes")),
                            reader.GetBoolean(reader.GetOrdinal("IsActive")),
                            (IssueReasonEnum)reader.GetByte(reader.GetOrdinal("IssueReason")),
                            reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                        );
                        
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<int> GetLicenseIDAsync(int localId, CancellationToken cancellationToken)
        {
            int licenseID = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetLicenseIdByLocalId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@localId", SqlDbType.Int).Value = localId;
                await connection.OpenAsync(cancellationToken);
                object? result = await command.ExecuteScalarAsync(cancellationToken);
                if (result != null && int.TryParse(result.ToString(), out int id))
                    licenseID = id;
            }
            catch (SqlException)
            {
                throw;
            }
            return licenseID;
        }

        public async Task<int> GetLicenseIDAsync(string nationalNo, CancellationToken cancellationToken)
        {
            int licenseID = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetLicenseIdByNationalNo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nationalNo", SqlDbType.NVarChar).Value = nationalNo;
                await connection.OpenAsync(cancellationToken);
                object? result = await command.ExecuteScalarAsync(cancellationToken);
                if (result != null && int.TryParse(result.ToString(), out int id))
                    licenseID = id;
            }
            catch (SqlException)
            {
                throw;
            }
            return licenseID;
        }

        public async Task<List<LicenseHistory>> GetLocalLicenseHistoryAsync(int driverId, CancellationToken cancellationToken)
        {
            List<LicenseHistory> list = new List<LicenseHistory>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetLocalLicenseHistory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = driverId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                {
                    list.Add(new LicenseHistory
                        (
                            reader.GetInt32(reader.GetOrdinal("Lic.ID")),
                            reader.GetInt32(reader.GetOrdinal("App.ID")),
                            reader.GetString(reader.GetOrdinal("Class Name")),
                            reader.GetDateTime(reader.GetOrdinal("Issue Date")),
                            reader.GetDateTime(reader.GetOrdinal("Expiration Date")),
                            reader.GetBoolean(reader.GetOrdinal("Is Active"))
                        ));
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return list;
        }

        public async Task<bool> DeactivateLicenseAsync(int licenseId, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_DeactivateLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = licenseId;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public async Task<int> GetActiveLicenseWithLicenseClassAsync(int personId, int licenseClassId, CancellationToken cancellationToken)
        {
            int LicenseId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetActiveLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = licenseClassId;
                await connection.OpenAsync(cancellationToken);
                object? result = await command.ExecuteScalarAsync(cancellationToken);
                if (result != null && int.TryParse(result.ToString(), out int id))
                    LicenseId = id;
            }
            catch (SqlException)
            {
                throw;
            }
            return LicenseId;
        }
    }
}
