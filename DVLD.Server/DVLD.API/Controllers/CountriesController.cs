using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.Countries;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/Countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        [HttpGet(Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CountriesDto>>> GetAllCountries()
        {
            List<Country> countries = await CountryService.GetCountriesAsync();
            var CountryDto = countries.Select(CountryMapper.ToCountriesDto).ToList();
            return Ok(CountryDto);
        }

        [HttpGet("{id}", Name = "GetCountryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountriesDto>> GetCountryById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Country? country = await CountryService.FindCountryAsync(id);

            if (country == null) return NotFound($"There's no country with this Id: {id}");

            return Ok(CountryMapper.ToCountriesDto(country));
        }

        [HttpGet("by-name/{name}", Name = "GetCountryByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountriesDto>> GetCountryByName(string name)
        {
            Country? country = await CountryService.FindCountryAsync(name);

            if (country == null) return NotFound($"There's no country with this name: {name}");

            return Ok(CountryMapper.ToCountriesDto(country));
        }
    }
}
