using DVLD.DTOs.Countries;
using DVLD.Shared.Entities;

namespace DVLD.API.Mappers
{
    public static class CountryMapper
    {
        public static CountriesDto ToCountriesDto(Country country)
        {
            return new CountriesDto
            {
                CountryId = country.CountryId,
                CountryName = country.CountryName
            };
        }
    }
}
