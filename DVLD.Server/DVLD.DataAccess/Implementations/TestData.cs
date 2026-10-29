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
    public sealed class TestData(DatabaseSettings databaseSettings) : ITestData
    {
        private static Test MapTest(SqlDataReader reader)
        {
            return new Test
                (
                    reader.GetInt32(reader.GetOrdinal("TestID")),
                    reader.GetInt32(reader.GetOrdinal("TestAppointmentID")),
                    reader.GetBoolean(reader.GetOrdinal("TestResult")),
                    reader.GetString(reader.GetOrdinal("Notes")),
                    reader.GetInt32(reader.GetOrdinal("CreatedByUserID"))
                );
        }
        public async Task<int> AddNewTestAsync(Test newTest, CancellationToken cancellationToken)
        {
            int testId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_AddNewTest", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@appointmentId", SqlDbType.Int).Value = newTest.AppointmentID;
                command.Parameters.Add("@result", SqlDbType.Bit).Value = newTest.Result;
                command.Parameters.Add("@notes", SqlDbType.NVarChar).Value = newTest.Notes;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = newTest.UserId;
                SqlParameter outputId = new SqlParameter("@testId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                testId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                throw;
            }
            return testId;
        }

        public async Task<bool> UpdateTestAsync(Test updateTest, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdateTest", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@appointmentId", SqlDbType.Int).Value = updateTest.AppointmentID;
                command.Parameters.Add("@result", SqlDbType.Bit).Value = updateTest.Result;
                command.Parameters.Add("@notes", SqlDbType.NVarChar).Value = updateTest.Notes;
                command.Parameters.Add("@userId", SqlDbType.Int).Value = updateTest.UserId;
                command.Parameters.Add("@testId", SqlDbType.Int).Value = updateTest.TestId;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                throw;
            }
            return rowAffected > 0;
        }

        public async Task<Test?> FindTest(int appointmentId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindTestById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@testId", SqlDbType.Int).Value = appointmentId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapTest(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<Test?> GetLastTestAsync(int localId, TestTypeEnum typeId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand cmd = new SqlCommand("SP_GetLastTest", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@localId", SqlDbType.Int).Value = localId;
                cmd.Parameters.Add("@testTypeId", SqlDbType.Int).Value = (int)typeId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await cmd.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapTest(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }
    }
}
