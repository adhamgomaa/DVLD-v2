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
    public class DriverData
    {
        private static Driver MapDriver(SqlDataReader reader)
        {
            return new Driver
                (
                    reader.GetInt32(reader.GetOrdinal("DriverID")),
                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID")),
                    reader.GetDateTime(reader.GetOrdinal("CreatedDate"))
                );
        }
        public static async Task<int> AddNewDriverAsync(Driver newDriver)
        {
            int DriverId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CreateNewDriver", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = newDriver.PersonID;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newDriver.UserID;
                SqlParameter outputId = new SqlParameter("@driverId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                DriverId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                DriverId = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return DriverId;
        }

        public static async Task<List<DriverInfo>> ListDriversAsync()
        {
            List<DriverInfo> Drivers = new List<DriverInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllDrivers", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                    Drivers.Add(new DriverInfo
                        (
                            reader.GetInt32(reader.GetOrdinal("Driver ID")),
                            reader.GetInt32(reader.GetOrdinal("Person ID")),
                            reader.GetString(reader.GetOrdinal("National No.")),
                            reader.GetString(reader.GetOrdinal("Full Name")),
                            reader.GetDateTime(reader.GetOrdinal("Date")),
                            reader.GetInt32(reader.GetOrdinal("Active Licenses"))
                        ));
            }
            catch (SqlException)
            {
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return Drivers;
        }

        public static async Task<bool> IsPersonDriverAsync(int personId)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDriverByPersonId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
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

        public static async Task<Driver?> FindDriverByPersonIdAsync(int personId)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDriverByPersonId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapDriver(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public static async Task<Driver?> FindDriverAsync(int driverId)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDriverById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = driverId;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapDriver(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
