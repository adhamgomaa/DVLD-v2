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
    public sealed class PersonData(DatabaseSettings databaseSettings) : IPersonData
    {
        private static Person MapPerson(SqlDataReader reader)
        {
            return new Person
                    (
                        reader.GetInt32(reader.GetOrdinal("PersonID")),
                        reader.GetString(reader.GetOrdinal("NationalNo")),
                        reader.GetString(reader.GetOrdinal("FirstName")),
                        reader.GetString(reader.GetOrdinal("SecondName")),
                        reader.IsDBNull(reader.GetOrdinal("ThirdName"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("ThirdName")),
                        reader.GetString(reader.GetOrdinal("LastName")),
                        reader.GetDateTime(reader.GetOrdinal("BirthOfDate")),
                        reader.GetByte(reader.GetOrdinal("Gendor")),
                        reader.GetString(reader.GetOrdinal("Address")),
                        reader.GetString(reader.GetOrdinal("Phone")),
                        reader.IsDBNull(reader.GetOrdinal("Email"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("Email")),
                        reader.GetInt32(reader.GetOrdinal("NationalityCountryByID")),
                        reader.IsDBNull(reader.GetOrdinal("ImagePath"))
                            ? string.Empty
                            : reader.GetString(reader.GetOrdinal("ImagePath"))
                    );
        }
        public async Task<Person?> GetPersonByIDAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindPersonByPersonId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapPerson(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }
        
        public async Task<Person?> GetPersonByNationalNoAsync(string nationalNo, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindPersonByNationalNo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nationalNo", SqlDbType.NVarChar).Value = nationalNo;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapPerson(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }
        public async Task<int> AddNewPersonAsync(Person newPerson, CancellationToken cancellationToken)
        {
            int personId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_AddNewPerson", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nationalNo", SqlDbType.NVarChar).Value = newPerson.NationalNo;
                command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = newPerson.FName;
                command.Parameters.Add("@sec", SqlDbType.NVarChar).Value = newPerson.SecName;
                if (newPerson.ThName != null && newPerson.ThName.Trim() != "")
                    command.Parameters.Add("@thname", SqlDbType.NVarChar).Value = newPerson.ThName;
                else
                    command.Parameters.AddWithValue("@thname", DBNull.Value);
                command.Parameters.Add("@lName", SqlDbType.NVarChar).Value = newPerson.LName;
                command.Parameters.Add("@date", SqlDbType.DateTime).Value = newPerson.Date;
                command.Parameters.Add("@gendor", SqlDbType.TinyInt).Value = newPerson.Gendor;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = newPerson.Address;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = newPerson.Phone;
                if (newPerson.Email != null && newPerson.Email.Trim() != "")
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = newPerson.Email;
                else
                    command.Parameters.AddWithValue("@email", DBNull.Value);

                command.Parameters.Add("@nationalid", SqlDbType.Int).Value = newPerson.NationaltyId;
                if (newPerson.ImagePath != null && newPerson.ImagePath.Trim() != "")
                    command.Parameters.Add("@path", SqlDbType.NVarChar).Value = newPerson.ImagePath;
                else
                    command.Parameters.AddWithValue("@path", DBNull.Value);

                SqlParameter outputId = new SqlParameter("@personId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(outputId);
                await connection.OpenAsync(cancellationToken);
                await command.ExecuteNonQueryAsync(cancellationToken);
                personId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                personId = -1;
            }
            return personId;
        }
        public async Task<bool> UpdatePersonAsync(Person updatePerson, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_UpdatePerson", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nationalNo", SqlDbType.NVarChar).Value = updatePerson.NationalNo;
                command.Parameters.Add("@fname", SqlDbType.NVarChar).Value = updatePerson.FName;
                command.Parameters.Add("@sec", SqlDbType.NVarChar).Value = updatePerson.SecName;
                if (updatePerson.ThName != null && updatePerson.ThName.Trim() != "")
                    command.Parameters.Add("@thname", SqlDbType.NVarChar).Value = updatePerson.ThName;
                else
                    command.Parameters.AddWithValue("@thname", DBNull.Value);
                command.Parameters.Add("@lName", SqlDbType.NVarChar).Value = updatePerson.LName;
                command.Parameters.Add("@date", SqlDbType.DateTime).Value = updatePerson.Date;
                command.Parameters.Add("@gendor", SqlDbType.TinyInt).Value = updatePerson.Gendor;
                command.Parameters.Add("@address", SqlDbType.NVarChar).Value = updatePerson.Address;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = updatePerson.Phone;
                if (updatePerson.Email != null && updatePerson.Email.Trim() != "")
                    command.Parameters.Add("@email", SqlDbType.NVarChar).Value = updatePerson.Email;
                else
                    command.Parameters.AddWithValue("@email", DBNull.Value);
                command.Parameters.Add("@nationalid", SqlDbType.Int).Value = updatePerson.NationaltyId;
                if (updatePerson.ImagePath != null && updatePerson.ImagePath.Trim() != "")
                    command.Parameters.Add("@path", SqlDbType.NVarChar).Value = updatePerson.ImagePath;
                else
                    command.Parameters.AddWithValue("@path", DBNull.Value);
                command.Parameters.Add("@personId", SqlDbType.Int).Value = updatePerson.PersonId;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                rowAffected = 0;
            }
            return rowAffected > 0;
        }
        public async Task<bool> DeletePersonAsync(int id, CancellationToken cancellationToken)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_DeletePerson", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                rowAffected = await command.ExecuteNonQueryAsync(cancellationToken);
            }
            catch (SqlException)
            {
                rowAffected = 0;
            }
            return rowAffected > 0;
        }
        public async Task<List<PeopleInfo>> GetPeopleAsync(CancellationToken cancellationToken)
        {
            List<PeopleInfo> list = new List<PeopleInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetPeople", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while(await reader.ReadAsync(cancellationToken))
                {
                    list.Add(new PeopleInfo
                        (
                            reader.GetInt32(reader.GetOrdinal("Person ID")),
                            reader.GetString(reader.GetOrdinal("National No.")),
                            reader.GetString(reader.GetOrdinal("FullName")),
                            reader.GetString(reader.GetOrdinal("Gendor")),
                            reader.GetDateTime(reader.GetOrdinal("Date Of Birth")),
                            reader.GetString(reader.GetOrdinal("Nationality")),
                            reader.GetString(reader.GetOrdinal("Phone")),
                            reader.IsDBNull(reader.GetOrdinal("Email"))
                                ? string.Empty
                                : reader.GetString(reader.GetOrdinal("Email"))
                        ));
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return list;
        }
        public async Task<bool> IsPersonExistAsync(int id, CancellationToken cancellationToken)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsPersonExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = id;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
            }
            return isFound;
        }
        public async Task<bool> IsPersonExistAsync(string nationalNo, CancellationToken cancellationToken)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsPersonExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@NationalNo", SqlDbType.NVarChar).Value = nationalNo;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (await reader.ReadAsync(cancellationToken))
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
            }
            return isFound;
        }
    }
}
