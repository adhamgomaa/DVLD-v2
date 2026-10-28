using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.LicenseClass;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/LicenseClass")]
    [ApiController]
    public sealed class LicenseClassController(ILicenseClassService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllLicenseClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LicenseClassDto>>> GetAllLicenseClass(CancellationToken cancellationToken)
        {
            List<LicenseClass> license = await service.GetAllClassesAsync(cancellationToken);
            var classDto = license.Select(LicenseClassMapper.ToClassDto).ToList();
            return Ok(classDto);
        }

        [HttpGet("{id}", Name = "GetLicenseClassById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LicenseClassDto>> GetLicenseClassById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            LicenseClass? license = await service.FindClassesAsync(id, cancellationToken);

            if (license == null) return NotFound($"There's no license class with this Id: {id}");

            return Ok(LicenseClassMapper.ToClassDto(license));
        }

        [HttpGet("by-classname/{name}", Name = "GetLicenseClassByClassName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LicenseClassDto>> GetLicenseClassByClassName(string name, CancellationToken cancellationToken)
        {
            LicenseClass? license = await service.FindClassesAsync(name, cancellationToken);

            if (license == null) return NotFound($"There's no license class with this class name: {name}");

            return Ok(LicenseClassMapper.ToClassDto(license));
        }
    }
}
