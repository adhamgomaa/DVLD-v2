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
    public sealed class InternationalLicenseData(DatabaseSettings databaseSettings) : IInternationalLicenseData
    {
        private static InternationalLicense MapLicense(SqlDataReader reader)
        {
            return new InternationalLicense
                (
                    reader.GetInt32(reader.GetOrdinal("InternationalLicenseID")),
                    reader.GetInt32(reader.GetOrdinal("DriverID")),
                    reader.GetDateTime(reader.GetOrdinal("IssueDate")),
                    reader.GetDateTime(reader.GetOrdinal("ExpirationDate")),
                    reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    reader.GetInt32(reader.GetOrdinal("IssuedUsingLocalLicenseID")),
                    reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                );
        }
        public async Task<int> AddNewInternationalLicenseAsync(InternationalLicense newLicense, CancellationToken cancellationToken)
        {
            int licenseId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CreateInternationalLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = newLicense.PersonId;
                command.Parameters.Add("@appType", SqlDbType.Int).Value = (int)newLicense.Type;
                command.Parameters.Add("@status", SqlDbType.TinyInt).Value = (byte)newLicense.AppStatus;
                command.Parameters.Add("@statusDate", SqlDbType.DateTime).Value = newLicense.StatusDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = newLicense.Fees;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = newLicense.DriverID;
                command.Parameters.Add("@expireDate", SqlDbType.DateTime).Value = newLicense.ExpirationDate;
                command.Parameters.Add("@isActive", SqlDbType.Bit).Value = newLicense.IsActive;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newLicense.UserID;
                command.Parameters.Add("@localLicenseId", SqlDbType.Int).Value = newLicense.LocalLicenseID;
                SqlParameter outputId = new SqlParameter("@internationalLicenseId", SqlDbType.Int)
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

        public async Task<InternationalLicense?> FindLicenseAsync(int internationalId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindInternationalLicenseById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@licenseId", SqlDbType.Int).Value = internationalId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapLicense(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<InternationalLicense?> FindLicenseByLocalIdAsync(int LocalLicensID, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindInternationalLicenseByLocalId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@localId", SqlDbType.Int).Value = LocalLicensID;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapLicense(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<List<InternationalLicense>> GetAllLicensesAsync(CancellationToken cancellationToken)
        {
            List<InternationalLicense> list = new List<InternationalLicense>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllInternationalLicenses", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                    list.Add
                        (
                            new InternationalLicense
                            (
                                reader.GetInt32(reader.GetOrdinal("Int.License ID")),
                                reader.GetInt32(reader.GetOrdinal("Driver ID")),
                                reader.GetDateTime(reader.GetOrdinal("Issue Date")),
                                reader.GetDateTime(reader.GetOrdinal("Expiration Date")),
                                reader.GetBoolean(reader.GetOrdinal("Is Active")),
                                reader.GetInt32(reader.GetOrdinal("L.License ID")),
                                reader.GetInt32(reader.GetOrdinal("Application ID")),
                                reader.GetInt32(reader.GetOrdinal("User ID"))
                            )
                        );
            }
            catch (SqlException)
            {
                throw;
            }
            return list;
        }

        public async Task<List<InternationalLicense>> GetInternaionalLicenseHistoryAsync(int driverId, CancellationToken cancellationToken)
        {
            List<InternationalLicense> list = new List<InternationalLicense>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllInternationalLicensesHistory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = driverId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
                    list.Add
                        (
                            new InternationalLicense
                            (
                                reader.GetInt32(reader.GetOrdinal("Int.License ID")),
                                reader.GetDateTime(reader.GetOrdinal("Issue Date")),
                                reader.GetDateTime(reader.GetOrdinal("Expiration Date")),
                                reader.GetBoolean(reader.GetOrdinal("Is Active")),
                                reader.GetInt32(reader.GetOrdinal("L.License ID")),
                                reader.GetInt32(reader.GetOrdinal("Application ID")),
                                reader.GetInt32(reader.GetOrdinal("User ID"))
                            )
                        );
            }
            catch (SqlException)
            {
                throw;
            }
            return list;
        }

        public async Task<int> GetActiveInternationalLicenseIdAsync(int driverId, CancellationToken cancellationToken)
        {
            int internationalLicenseId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetActiveInternationalLicenseByDriverId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = driverId;
                await connection.OpenAsync(cancellationToken);
                object? result = await command.ExecuteScalarAsync(cancellationToken);
                if (result != null && int.TryParse(result.ToString(), out int id))
                    internationalLicenseId = id;
            }
            catch (SqlException)
            {
                throw;
            }
            return internationalLicenseId;
        }
    }
}
