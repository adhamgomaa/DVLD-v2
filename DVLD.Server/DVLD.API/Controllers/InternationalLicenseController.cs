using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.InternationalLicense;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DVLD.API.Controllers
{
    [Route("api/InternationalLicense")]
    [ApiController]
    public sealed class InternationalLicenseController(IInternationalLicenseService service) : ControllerBase
    {
        [HttpGet("by-driver-id/{driverId}", Name = "GetAllInternationalLicensesHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InternationalHistoryDto>>> GetAllInternationalLicensesHistory(int driverId, CancellationToken cancellationToken)
        {
            List<InternationalLicense> licenses = await service.GetInternationalLicensesHistoryAsync(driverId, cancellationToken);
            var licenseDto = licenses.Select(InternationalMapper.ToLicenseHistoryDto).ToList();
            return Ok(licenseDto);
        }

        [HttpGet(Name = "GetAllInternationalLicenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InternationalLicenseDto>>> GetAllInternationalLicenses(CancellationToken cancellationToken)
        {
            List<InternationalLicense> licenses = await service.GetAllLicensesAsync(cancellationToken);
            var licenseDto = licenses.Select(InternationalMapper.ToLicenseDto).ToList();
            return Ok(licenseDto);
        }

        [HttpGet("{internationalId}", Name = "GetInternationalLicenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InternationalLicenseDto>> GetInternationalLicenseById(int internationalId, CancellationToken cancellationToken)
        {
            if (internationalId < 1)
                return BadRequest("Invalid data");

            InternationalLicense? license = await service.FindLicenseAsync(internationalId, cancellationToken);

            if (license == null) return NotFound($"There's no license with this ID: {internationalId}");

            return Ok(InternationalMapper.ToLicenseDto(license));
        }

        [HttpGet("by-local-id/{localLicenseId}", Name = "GetInternationalLicenseIdByLocalId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InternationalLicenseDto>> GetInternationalLicenseIdByLocalId(int localLicenseId, CancellationToken cancellationToken)
        {
            if (localLicenseId < 1)
                return BadRequest("Invalid data");

            InternationalLicense? license = await service.FindLicenseByLocalIdAsync(localLicenseId, cancellationToken);

            if (license == null) return NotFound($"There's no license with this local license ID: {localLicenseId}");

            return Ok(InternationalMapper.ToLicenseDto(license));
        }

        [HttpGet("active-license-id-by-driver-id/{driverId}", Name = "GetActiveLicenseIdByDriverId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetActiveLicenseIdByDriverId(int driverId, CancellationToken cancellationToken)
        {
            int result = await service.GetActiveInternationalLicenseIdAsync(driverId, cancellationToken);
            if (result == -1)
                return NotFound("There's no international license with this driverId");

            return Ok(result);
        }

        [HttpPost(Name = "AddNewInternationalLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InternationalLicenseDto>> AddNewLicense(CreateInternationalLicenseDto createLicense, CancellationToken cancellationToken)
        {
            InternationalLicense newLicense = InternationalMapper.ToLicense(createLicense);

            bool result = await service.AddNewLicenseAsync(newLicense, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding License" });

            return CreatedAtRoute("GetInternationalLicenseById", new { id = newLicense.InternationalID }, InternationalMapper.ToLicenseDto(newLicense));
        }
    }
}
