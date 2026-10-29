using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.DataAccess;
using DVLD.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Business.Implementations
{
    public sealed class CountryService(ICountryData countryData) : ICountryService
    {
        public async Task<Country?> FindCountryAsync(int CountryId, CancellationToken cancellationToken)
        {
            Country? country = await countryData.FindCountryAsync(CountryId, cancellationToken);
            if (country != null)
                return country;
            return null;
        }

        public async Task<Country?> FindCountryAsync(string countryName, CancellationToken cancellationToken)
        {
            Country? country = await countryData.FindCountryAsync(countryName, cancellationToken);
            if (country != null)
                return country;
            return null;
        }

        public async Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken)
        {
            return await countryData.GetCountriesAsync(cancellationToken);
        }
    }
}
