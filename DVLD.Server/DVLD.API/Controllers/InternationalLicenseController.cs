using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.InternationalLicense;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DVLD.API.Controllers
{
    [Route("api/InternationalLicense")]
    [ApiController]
    public class InternationalLicenseController : ControllerBase
    {
        [HttpGet("by-driver-id/{driverId}", Name = "GetAllInternationalLicensesHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InternationalHistoryDto>>> GetAllInternationalLicensesHistory(int driverId)
        {
            List<InternationalLicense> licenses = await InternationalLicenseService.GetInternationalLicensesHistoryAsync(driverId);
            var licenseDto = licenses.Select(InternationalMapper.ToLicenseHistoryDto).ToList();
            return Ok(licenseDto);
        }

        [HttpGet(Name = "GetAllInternationalLicenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<InternationalLicenseDto>>> GetAllInternationalLicenses()
        {
            List<InternationalLicense> licenses = await InternationalLicenseService.GetAllLicensesAsync();
            var licenseDto = licenses.Select(InternationalMapper.ToLicenseDto).ToList();
            return Ok(licenseDto);
        }

        [HttpGet("{internationalId}", Name = "GetInternationalLicenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InternationalLicenseDto>> GetInternationalLicenseById(int internationalId)
        {
            if (internationalId < 1)
                return BadRequest("Invalid data");

            InternationalLicense? license = await InternationalLicenseService.FindLicenseAsync(internationalId);

            if (license == null) return NotFound($"There's no license with this ID: {internationalId}");

            return Ok(InternationalMapper.ToLicenseDto(license));
        }

        [HttpGet("by-local-id/{localLicenseId}", Name = "GetInternationalLicenseIdByLocalId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<InternationalLicenseDto>> GetInternationalLicenseIdByLocalId(int localLicenseId)
        {
            if (localLicenseId < 1)
                return BadRequest("Invalid data");

            InternationalLicense? license = await InternationalLicenseService.FindLicenseByLocalIdAsync(localLicenseId);

            if (license == null) return NotFound($"There's no license with this local license ID: {localLicenseId}");

            return Ok(InternationalMapper.ToLicenseDto(license));
        }

        [HttpGet("active-license-id-by-driver-id/{driverId}", Name = "GetActiveLicenseIdByDriverId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetActiveLicenseIdByDriverId(int driverId)
        {
            int result = await InternationalLicenseService.GetActiveInternationalLicenseIdAsync(driverId);
            if (result == -1)
                return NotFound("There's no international license with this driverId");

            return Ok(result);
        }

        [HttpPost(Name = "AddNewInternationalLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InternationalLicenseDto>> AddNewLicense(CreateInternationalLicenseDto createLicense)
        {
            InternationalLicense newLicense = InternationalMapper.ToLicense(createLicense);

            bool result = await InternationalLicenseService.AddNewLicenseAsync(newLicense);
            if (!result)
                return StatusCode(500, new { message = "Error Adding License" });

            return CreatedAtRoute("GetInternationalLicenseById", new { id = newLicense.InternationalID }, InternationalMapper.ToLicenseDto(newLicense));
        }
    }
}
