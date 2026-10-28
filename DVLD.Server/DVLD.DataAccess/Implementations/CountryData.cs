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
    public sealed class CountryData(DatabaseSettings databaseSettings) : ICountryData
    {
        private static Country MapCountry(SqlDataReader reader)
        {
            return new Country
                    (
                        reader.GetInt32(reader.GetOrdinal("CountryID")),
                        reader.GetString(reader.GetOrdinal("CountryName"))

                    );
        }
        public async Task<Country?> FindCountryAsync(int countryId, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindCountryById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@countryId", SqlDbType.Int).Value = countryId;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapCountry(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }
        public async Task<Country?> FindCountryAsync(string countryName, CancellationToken cancellationToken)
        {
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_FindCountryByName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = countryName;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                if (!await reader.ReadAsync(cancellationToken))
                    return null;
                return MapCountry(reader);
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
        {
            List<Country> list = new List<Country>();
            try
            {
                await using SqlConnection connection = new SqlConnection(databaseSettings.ConnectionString);
                await using SqlCommand command = new SqlCommand("SP_GetAllCountries", connection);
                command.CommandType = CommandType.StoredProcedure;
                await connection.OpenAsync(cancellationToken);
                await using SqlDataReader reader = await command.ExecuteReaderAsync(cancellationToken);
                while (await reader.ReadAsync())
                {
                    list.Add(MapCountry(reader));
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return list;
        }
    }
}
