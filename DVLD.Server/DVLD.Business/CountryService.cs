using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business
{
    public class CountryService
    {
        public static async Task<Country?> FindCountryAsync(int CountryId)
        {
            Country? country = await CountryData.FindCountryAsync(CountryId);
            if (country != null)
                return country;
            return null;
        }

        public static async Task<Country?> FindCountryAsync(string countryName)
        {
            Country? country = await CountryData.FindCountryAsync(countryName);
            if (country != null)
                return country;
            return null;
        }

        public static async Task<List<Country>> GetCountriesAsync()
        {
            return await CountryData.GetCountriesAsync();
        }
    }
}
