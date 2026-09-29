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
    public class LocalDrivingLicenseData
    {
        private static LocalLicense MapLocalLicense(SqlDataReader reader)
        {
            return new LocalLicense
                (
                    reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseApplicationID")),
                    reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                    reader.GetInt32(reader.GetOrdinal("LicenseClassID"))
                );
        }
        public static async Task<int> AddNewLocalAsync(LocalLicense newLocalLicense)
        {
            int localId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CreateNewLocalDrivingLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = newLocalLicense.PersonId;
                command.Parameters.Add("@appType", SqlDbType.Int).Value = (int)newLocalLicense.Type;
                command.Parameters.Add("@status", SqlDbType.TinyInt).Value = (byte)newLocalLicense.AppStatus;
                command.Parameters.Add("@statusDate", SqlDbType.DateTime).Value = newLocalLicense.StatusDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = newLocalLicense.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newLocalLicense.UserId;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = newLocalLicense.ClassId;
                SqlParameter outputId = new SqlParameter("@localId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                localId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return localId;
        }

        public static async Task<bool> UpdateLocalAsync(LocalLicense updateLocalLicense)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateLocalDrivingLicense", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = updateLocalLicense.PersonId;
                command.Parameters.Add("@appDate", SqlDbType.DateTime).Value = updateLocalLicense.AppDate;
                command.Parameters.Add("@appType", SqlDbType.Int).Value = (int)updateLocalLicense.Type;
                command.Parameters.Add("@status", SqlDbType.TinyInt).Value = (byte)updateLocalLicense.AppStatus;
                command.Parameters.Add("@statusDate", SqlDbType.DateTime).Value = updateLocalLicense.StatusDate;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = updateLocalLicense.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateLocalLicense.UserId;
                command.Parameters.Add("@appId", SqlDbType.Int).Value = updateLocalLicense.AppId;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = updateLocalLicense.ClassId;
                command.Parameters.Add("@localId", SqlDbType.Int).Value = updateLocalLicense.LocalId;
                await connection.OpenAsync();
                rowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static async Task<bool> DeleteLocalAsync(int localId, int appId)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_DeleteLocalDrivingLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@appId", SqlDbType.Int).Value = appId;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localId;
                await connection.OpenAsync();
                rowAffected = await cmd.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static async Task<bool> CheckPersonHasSameClassAsync(int personId, int classId)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CheckPersonHasSameClass", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
                command.Parameters.Add("@classId", SqlDbType.Int).Value = classId;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return false;
                return true;
            }
            catch (SqlException)
            {
                return false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<List<LocalDrivingApplications>> GetAllLocalLicensesAsync()
        {
            List<LocalDrivingApplications> list = new List<LocalDrivingApplications>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_GetAllLocalLicenses", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    list.Add(new LocalDrivingApplications
                        (
                            reader.GetInt32(reader.GetOrdinal("L.D.L.AppID")),
                            reader.GetString(reader.GetOrdinal("Driving Class")),
                            reader.GetString(reader.GetOrdinal("National No.")),
                            reader.GetString(reader.GetOrdinal("Full Name")),
                            reader.GetDateTime(reader.GetOrdinal("ApplicationDate")),
                            reader.GetInt32(reader.GetOrdinal("Passed Tests")),
                            reader.GetString(reader.GetOrdinal("Status"))
                        
                        ));
                }
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return list;
        }

        public static async Task<bool> CancelLicenseAsync(int localLicenseAppID)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_CancelLicense", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localLicenseAppID;
                await connection.OpenAsync();
                rowAffected = await cmd.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static async Task<LocalLicense?> FindLocalLicenseAsync(int localLicenseID)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_FindLocalDrivingLicenseById", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localLicenseID;
                await connection.OpenAsync();
                await using SqlDataReader reader = cmd.ExecuteReader();
                if (!await reader.ReadAsync())
                    return null;
                return MapLocalLicense(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<bool> DoseAttendTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_DoesAttendTestType", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localLicenseAppID;
                cmd.Parameters.Add("@testTypeId", SqlDbType.Int).Value = (int)testTypeID;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null)
                    isFound = true;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }

        public static async Task<byte> TotalTrialsPerTestAsync(int localLicenseAppID, TestTypeEnum testTypeID)
        {
            byte Totaltrials = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_TotalTrialsPerTest", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localLicenseAppID;
                cmd.Parameters.Add("@testTypeId", SqlDbType.Int).Value = (int)testTypeID;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                    Totaltrials = Trials;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return Totaltrials;
        }

        public static async Task<bool> IsThereAnActiveScheduleTestAsync(int localLicenseAppID, TestTypeEnum testTypeID)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_IsThereAnActiveScheduleTest", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localLicenseAppID;
                cmd.Parameters.Add("@testTypeId", SqlDbType.Int).Value = (int)testTypeID;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null && byte.TryParse(result.ToString(), out byte test))
                    isFound = test > 0;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }

        public static async Task<bool> DosePassTestTypeAsync(int localLicenseAppID, TestTypeEnum testTypeID)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_DoesAttendTestType", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localLicenseAppID;
                cmd.Parameters.Add("@testTypeId", SqlDbType.Int).Value = (int)testTypeID;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null && bool.TryParse(result.ToString(), out bool testResult))
                    isFound = testResult;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }

        public static async Task<byte> GetPassedTestCountAsync(int localLicenseID)
        {
            byte PassedCount = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_GetPassedTestCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localLicenseID;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null && byte.TryParse(result.ToString(), out byte count))
                    PassedCount = count;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return PassedCount;
        }
    }
}
