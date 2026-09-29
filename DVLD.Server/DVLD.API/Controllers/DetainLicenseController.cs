using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.DetainLicense;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DVLD.API.Controllers
{
    [Route("api/DetainLicense")]
    [ApiController]
    public class DetainLicenseController : ControllerBase
    {
        [HttpGet(Name = "GetAllDetainLicenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DetainLicenseDto>>> GetAllDetainLicenses()
        {
            List<DetainLicenseInfo> licenses = await DetainLicenseService.GetDetainedLicensesAsync();
            var licenseDto = licenses.Select(DetainLicenseMapper.ToLicenseDto).ToList();
            return Ok(licenseDto);
        }
        [HttpGet("{licenseId}", Name = "GetDetainLicenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDetainDto>> GetDetainLicenseById(int licenseId)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            DetainLicense? license = await DetainLicenseService.FindDetainLicenseAsync(licenseId);

            if (license == null) return NotFound($"There's no detain license with this license ID: {licenseId}");

            return Ok(DetainLicenseMapper.ToGetDto(license));
        }

        [HttpGet("is-license-detained/{licenseId}", Name = "IsLicenseDetained")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsLicenseDetained(int licenseId)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            bool result = await DetainLicenseService.IsDetainedLicenseAsync(licenseId);

            return Ok(result);
        }

        [HttpPost(Name = "AddNewDetainLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetDetainDto>> AddNewDetainLicense(CreateDetainLicenseDto createLicense)
        {
            DetainLicense newDetain = DetainLicenseMapper.ToLicense(createLicense);

            bool result = await DetainLicenseService.AddNewDetainLicenseAsync(newDetain);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Detain License" });

            return CreatedAtRoute("GetDetainLicenseById", new { licenseId = newDetain.LicenseID }, DetainLicenseMapper.ToGetDto(newDetain));
        }

        [HttpPut("{licenseId}", Name = "UpdateDetainLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateDetainLicenseDto>> UpdateDetainLicense(int licenseId, UpdateDetainLicenseDto updateLicense)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            DetainLicense? license = await DetainLicenseService.FindDetainLicenseAsync(licenseId);
            if (license == null) return NotFound($"There's no detain license with this license ID: {licenseId}");

            license.LicenseID = updateLicense.LicenseID;
            license.DetainDate = updateLicense.DetainDate;
            license.Fees = updateLicense.Fees;
            license.UserID = updateLicense.UserID;

            bool result = await DetainLicenseService.UpdateDetainLicenseAsync(license);
            if (result) return Ok(updateLicense);
            else return StatusCode(500, new { message = "Error Updating Detain License" });
        }
        
        [HttpPut("release-detained-license/{licenseId}", Name = "ReleaseDetainedLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReleaseLicenseDto>> ReleaseDetainedLicense(int licenseId, ReleaseLicenseDto releaseLicense)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            DetainLicense? license = await DetainLicenseService.FindDetainLicenseAsync(licenseId);
            if (license == null) return NotFound($"There's no detain license with this license ID: {licenseId}");

            license.PersonId = releaseLicense.PersonId;
            license.Type = releaseLicense.Type;
            license.AppStatus = releaseLicense.AppStatus;
            license.StatusDate = releaseLicense.StatusDate;
            license.Fees = releaseLicense.Fees;
            license.ReleaseByUserId = releaseLicense.ReleaseByUserId;

            bool result = await DetainLicenseService.ReleaseDetainedLicenseAsync(license);
            if (result) return Ok(releaseLicense);
            else return StatusCode(500, new { message = "Error Updating Release License" });
        }
    }
}
