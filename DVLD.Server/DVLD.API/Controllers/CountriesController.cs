using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.Countries;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/Countries")]
    [ApiController]
    public sealed class CountriesController(ICountryService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CountriesDto>>> GetAllCountries(CancellationToken cancellationToken)
        {
            List<Country> countries = await service.GetCountriesAsync(cancellationToken);
            var CountryDto = countries.Select(CountryMapper.ToCountriesDto).ToList();
            return Ok(CountryDto);
        }

        [HttpGet("{id}", Name = "GetCountryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountriesDto>> GetCountryById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Country? country = await service.FindCountryAsync(id, cancellationToken);

            if (country == null) return NotFound($"There's no country with this Id: {id}");

            return Ok(CountryMapper.ToCountriesDto(country));
        }

        [HttpGet("by-name/{name}", Name = "GetCountryByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountriesDto>> GetCountryByName(string name, CancellationToken cancellationToken)
        {
            Country? country = await service.FindCountryAsync(name, cancellationToken);

            if (country == null) return NotFound($"There's no country with this name: {name}");

            return Ok(CountryMapper.ToCountriesDto(country));
        }
    }
}
