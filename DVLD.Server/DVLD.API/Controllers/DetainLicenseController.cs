using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.DetainLicense;
using DVLD.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/DetainLicense")]
    [ApiController]
    public sealed class DetainLicenseController(IDetainLicenseService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllDetainLicenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DetainLicenseDto>>> GetAllDetainLicenses(CancellationToken cancellationToken)
        {
            List<DetainedLicenseInfo> licenses = await service.GetDetainedLicensesAsync(cancellationToken);
            var licenseDto = licenses.Select(DetainLicenseMapper.ToLicenseDto).ToList();
            return Ok(licenseDto);
        }
        [HttpGet("{licenseId}", Name = "GetDetainLicenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDetainDto>> GetDetainLicenseById(int licenseId, CancellationToken cancellationToken)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            DetainedLicense? license = await service.FindDetainLicenseAsync(licenseId, cancellationToken);

            if (license == null) return NotFound($"There's no detain license with this license ID: {licenseId}");

            return Ok(DetainLicenseMapper.ToGetDto(license));
        }

        [HttpGet("is-license-detained/{licenseId}", Name = "IsLicenseDetained")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsLicenseDetained(int licenseId, CancellationToken cancellationToken)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            bool result = await service.IsDetainedLicenseAsync(licenseId, cancellationToken);

            return Ok(result);
        }

        [HttpPost(Name = "AddNewDetainLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetDetainDto>> AddNewDetainLicense(CreateDetainLicenseDto createLicense, CancellationToken cancellationToken)
        {
            DetainedLicense newDetain = DetainLicenseMapper.ToLicense(createLicense);

            bool result = await service.AddNewDetainLicenseAsync(newDetain, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Detain License" });

            return CreatedAtRoute("GetDetainLicenseById", new { licenseId = newDetain.LicenseId }, DetainLicenseMapper.ToGetDto(newDetain));
        }

        [HttpPut("{detainId}", Name = "UpdateDetainLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateDetainLicenseDto>> UpdateDetainLicense(int detainId, UpdateDetainLicenseDto updateLicense, CancellationToken cancellationToken)
        {
            if (detainId < 1)
                return BadRequest("Invalid data");

            DetainedLicense? license = await service.FindDetainLicenseByDetainIdAsync(detainId, cancellationToken);
            if (license == null) return NotFound($"There's no detain ID with: {detainId}");

            license.LicenseId = updateLicense.LicenseID;
            license.DetainDate = updateLicense.DetainDate;
            license.DetainFees = updateLicense.Fees;
            license.CreatedByUserId = updateLicense.UserID;

            bool result = await service.UpdateDetainLicenseAsync(license, cancellationToken);
            if (result) return Ok(updateLicense);
            else return StatusCode(500, new { message = "Error Updating Detain License" });
        }
        
        [HttpPut("release-detained-license/{licenseId}", Name = "ReleaseDetainedLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ReleaseLicenseDto>> ReleaseDetainedLicense(int licenseId, ReleaseLicenseDto releaseLicense, CancellationToken cancellationToken)
        {
            bool isDetained = await service.IsDetainedLicenseAsync(licenseId, cancellationToken);
            if (licenseId < 1 || !isDetained)
                return BadRequest("Invalid data");

            DetainedLicense? license = await service.FindDetainLicenseAsync(licenseId, cancellationToken);
            if (license == null) return NotFound($"There's no detain license with this license ID: {licenseId}");

            license.ReleaseApplication = new Application
            {
                ApplicantPersonId = releaseLicense.PersonId,
                ApplicationTypeId = releaseLicense.Type,
                ApplicationStatus = releaseLicense.AppStatus,
                LastStatusDate = releaseLicense.StatusDate,
                PaidFees = releaseLicense.Fees,
                CreatedByUserId = releaseLicense.UserId
            };
            license.ReleasedByUserId = releaseLicense.UserId;
            license.IsReleased = true;
            license.ReleaseDate = DateTime.Now;

            bool result = await service.ReleaseDetainedLicenseAsync(license, cancellationToken);
            if (result) return Ok(releaseLicense);
            else return StatusCode(500, new { message = "Error Updating Release License" });
        }
    }
}
