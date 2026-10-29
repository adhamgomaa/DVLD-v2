using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.Business.Interfaces;

public interface ICountryService
{
    Task<Country?> FindCountryAsync(int CountryId, CancellationToken cancellationToken);
    Task<Country?> FindCountryAsync(string countryName, CancellationToken cancellationToken);
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
}
