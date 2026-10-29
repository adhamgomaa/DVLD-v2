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
    public sealed class DriverData(DatabaseSettings databaseSettings) : IDriverData
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
        public async Task<int> AddNewDriverAsync(Driver newDriver, CancellationToken cancellationToken)
        {
            int DriverId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_CreateNewDriver", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = newDriver.PersonID;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newDriver.UserID;
                SqlParameter outputId = new SqlParameter("@driverId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                DriverId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                DriverId = -1;
            }
            return DriverId;
        }

        public async Task<List<DriverInfo>> ListDriversAsync(CancellationToken cancellationToken)
        {
            List<DriverInfo> Drivers = new List<DriverInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllDrivers", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync(cancellationToken))
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
                throw;
            }
            return Drivers;
        }

        public async Task<bool> IsPersonDriverAsync(int personId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDriverByPersonId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return false;
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public async Task<Driver?> FindDriverByPersonIdAsync(int personId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDriverByPersonId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = personId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapDriver(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<Driver?> FindDriverAsync(int driverId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindDriverById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@driverId", SqlDbType.Int).Value = driverId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapDriver(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }
    }
}
