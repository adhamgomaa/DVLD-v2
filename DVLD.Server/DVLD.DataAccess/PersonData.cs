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
    public class PersonData
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
        public static async Task<Person?> GetPersonByIDAsync(int id)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindPersonByPersonId", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapPerson(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        
        public static async Task<Person?> GetPersonByNationalNoAsync(string nationalNo)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindPersonByNationalNo", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@nationalNo", SqlDbType.NVarChar).Value = nationalNo;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (!await reader.ReadAsync())
                    return null;
                return MapPerson(reader);
            }
            catch (SqlException)
            {
                return null;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
        }
        public static async Task<int> AddNewPersonAsync(Person newPerson)
        {
            int personId = -1;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
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
                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
                personId = outputId.Value == DBNull.Value ? -1 : (int)outputId.Value;
            }
            catch (SqlException)
            {
                personId = -1;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return personId;
        }
        public static async Task<bool> UpdatePersonAsync(Person updatePerson)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
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
                await connection.OpenAsync();
                rowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                rowAffected = 0;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }
        public static async Task<bool> DeletePersonAsync(int id)
        {
            int rowAffected = 0;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_DeletePerson", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                rowAffected = await command.ExecuteNonQueryAsync();
            }
            catch (SqlException)
            {
                rowAffected = 0;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return rowAffected > 0;
        }
        public static async Task<List<PeopleInfo>> GetPeopleAsync()
        {
            List<PeopleInfo> list = new List<PeopleInfo>();
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetPeople", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                while(await reader.ReadAsync())
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
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return list;
        }
        public static async Task<bool> IsPersonExistAsync(int id)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsPersonExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@personId", SqlDbType.Int).Value = id;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }
        public static async Task<bool> IsPersonExistAsync(string nationalNo)
        {
            bool isFound = false;
            try
            {
                await using SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_IsPersonExists", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@NationalNo", SqlDbType.NVarChar).Value = nationalNo;
                await connection.OpenAsync();
                await using SqlDataReader reader = await command.ExecuteReaderAsync();
                if (await reader.ReadAsync())
                    isFound = true;
            }
            catch (SqlException)
            {
                isFound = false;
                //clsLogger.LoggingAllExepctions(ex.Message, System.Diagnostics.EventLogEntryType.Error);
            }
            return isFound;
        }
    }
}
