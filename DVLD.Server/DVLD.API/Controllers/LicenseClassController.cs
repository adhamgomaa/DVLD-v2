using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.LicenseClass;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/LicenseClass")]
    [ApiController]
    public class LicenseClassController : ControllerBase
    {
        [HttpGet(Name = "GetAllLicenseClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LicenseClassDto>>> GetAllLicenseClass()
        {
            List<LicenseClass> license = await LicenseClassService.GetAllClassesAsync();
            var classDto = license.Select(LicenseClassMapper.ToClassDto).ToList();
            return Ok(classDto);
        }

        [HttpGet("{id}", Name = "GetLicenseClassById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LicenseClassDto>> GetLicenseClassById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            LicenseClass? license = await LicenseClassService.FindClassesAsync(id);

            if (license == null) return NotFound($"There's no license class with this Id: {id}");

            return Ok(LicenseClassMapper.ToClassDto(license));
        }

        [HttpGet("by-classname/{name}", Name = "GetLicenseClassByClassName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LicenseClassDto>> GetLicenseClassByClassName(string name)
        {
            LicenseClass? license = await LicenseClassService.FindClassesAsync(name);

            if (license == null) return NotFound($"There's no license class with this class name: {name}");

            return Ok(LicenseClassMapper.ToClassDto(license));
        }
    }
}
