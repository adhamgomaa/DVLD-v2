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
    public class TestAppointmentData
    {
        private static TestAppointment MapAppointment(SqlDataReader reader)
        {
            return new TestAppointment
                (
                    reader.GetInt32(reader.GetOrdinal("TestAppointmentID")),
                    (TestTypeEnum)reader.GetInt32(reader.GetOrdinal("TestTypeID")),
                    reader.GetInt32(reader.GetOrdinal("LocalDrivingLicenseID")),
                    reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                    reader.GetDecimal(reader.GetOrdinal("PaidFees")),
                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                    reader.GetBoolean(reader.GetOrdinal("IsLocked")),
                    reader.IsDBNull(reader.GetOrdinal("RetakeTestApplicationID"))
                        ? -1
                        : reader.GetInt32(reader.GetOrdinal("RetakeTestApplicationID"))

                );
        }
        public static async Task<List<TestAppointment>> GetAllAppointmentAsync(int localId, TestTypeEnum typeId)
        {
            List<TestAppointment> list = new List<TestAppointment>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllTestAppointment", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@localId", SqlDbType.Int).Value = localId;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)typeId;
                connection.Open();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                    list.Add(new TestAppointment
                    (
                        reader.GetInt32(reader.GetOrdinal("Appointment ID")),
                        reader.GetDateTime(reader.GetOrdinal("Appointment Date")),
                        reader.GetDecimal(reader.GetOrdinal("Paid Fees")),
                        reader.GetBoolean(reader.GetOrdinal("Is Locked"))
                    ));
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return list;
        }

        public static async Task<int> AddNewAppointmentAsync(TestAppointment newAppointment)
        {
            int AppId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CreateTestAppointment", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)newAppointment.TestTypeId;
                command.Parameters.Add("@localId", SqlDbType.Int).Value = newAppointment.LocalId;
                command.Parameters.Add("@date", SqlDbType.DateTime).Value = newAppointment.Date;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = newAppointment.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newAppointment.UserId;
                if (newAppointment.RetakeApplicationId == -1)
                    command.Parameters.AddWithValue("@retakeId", DBNull.Value);
                else
                    command.Parameters.Add("@retakeId", SqlDbType.Int).Value = newAppointment.RetakeApplicationId;
                SqlParameter outputId = new SqlParameter("@testAppId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                AppId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return AppId;
        }

        public static async Task<bool> UpdateAppointmentAsync(TestAppointment updateAppointment)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateTestAppointment", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)updateAppointment.TestTypeId;
                command.Parameters.Add("@localId", SqlDbType.Int).Value = updateAppointment.LocalId;
                command.Parameters.Add("@date", SqlDbType.DateTime).Value = updateAppointment.Date;
                command.Parameters.Add("@fees", SqlDbType.Decimal).Value = updateAppointment.Fees;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateAppointment.UserId;
                command.Parameters.Add("@locked", SqlDbType.Bit).Value = updateAppointment.IsLocked;
                command.Parameters.Add("@testAppId", SqlDbType.Int).Value = updateAppointment.AppointmentId;
                await connection.OpenAsync();
                rowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }

        public static async Task<TestAppointment?> FindAppointmentAsync(int appId)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindTestAppointment", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@testAppId", SqlDbType.Int).Value = appId;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapAppointment(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<TestAppointment?> GetLastTestAppointmentAsync(int localId, TestTypeEnum testType)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetLastAppointment", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@localId", SqlDbType.Int).Value = localId;
                command.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)testType;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapAppointment(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<int> GetTrialsAsync(int localId, TestTypeEnum typeId)
        {
            int trials = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_GetTrials", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localId;
                cmd.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)typeId;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null && int.TryParse(result.ToString(), out int count))
                    trials = count;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return trials;
        }

        public static async Task<bool> AppointmentIsLockAsync(int localId, TestTypeEnum typeId)
        {
            bool isLock = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_IsAppointmentLock", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localId;
                cmd.Parameters.Add("@typeId", SqlDbType.Int).Value = (int)typeId;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null && bool.TryParse(result.ToString(), out bool Lock))
                    isLock = Lock;
            }
            catch (SqlException)
            {
                isLock = false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isLock;
        }

        public static async Task<int> GetTestIDAsync(int testAppointmentID)
        {
            int testID = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_GetTestId", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@testAppId", SqlDbType.Int).Value = testAppointmentID;
                await connection.OpenAsync();
                object? result = await cmd.ExecuteScalarAsync();
                if (result != null && int.TryParse(result.ToString(), out int id))
                    testID = id;
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return testID;
        }
    }
}
