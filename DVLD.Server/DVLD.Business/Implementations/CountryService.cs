using DVLD.DataAccess.Interfaces;
using DVLD.Business.Interfaces;
using DVLD.Shared.Models;

namespace DVLD.Business.Implementations
{
    public sealed class CountryService(ICountryData countryData) : ICountryService
    {
        public Task<Country?> FindCountryAsync(int CountryId, CancellationToken cancellationToken) =>
            countryData.FindCountryAsync(CountryId, cancellationToken);

        public Task<Country?> FindCountryAsync(string countryName, CancellationToken cancellationToken) =>
            countryData.FindCountryAsync(countryName, cancellationToken);

        public Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken) =>
            countryData.GetCountriesAsync(cancellationToken);
    }
}
