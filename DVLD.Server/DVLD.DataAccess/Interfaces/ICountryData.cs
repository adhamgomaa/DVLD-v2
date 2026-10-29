using DVLD.Shared.Entities;
using DVLD.Shared.Enums;

namespace DVLD.DataAccess.Interfaces;

public interface ICountryData
{
    Task<Country?> FindCountryAsync(int countryId, CancellationToken cancellationToken);
    Task<Country?> FindCountryAsync(string countryName, CancellationToken cancellationToken);
    Task<List<Country>> GetCountriesAsync(CancellationToken cancellationToken);
}
