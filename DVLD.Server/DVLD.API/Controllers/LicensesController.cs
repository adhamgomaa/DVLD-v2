using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.Licenses;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/Licenses")]
    [ApiController]
    public class LicensesController : ControllerBase
    {
        [HttpGet("by-driver-id/{driverId}",Name = "GetAllLicensesHistory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LicenseHistoryDto>>> GetAllLicensesHistory(int driverId)
        {
            List<LicenseHistory> licenses = await LicenseService.GetLocalLicensesHistoryAsync(driverId);
            var licenseDto = licenses.Select(LicenseMapper.ToLicenseDto).ToList();
            return Ok(licenseDto);
        }
        [HttpGet("{id}", Name = "GetLicenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetLicenseDto>> GetLicenseById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            License? license = await LicenseService.FindLicenseAsync(id);

            if (license == null) return NotFound($"There's no license with this Id: {id}");

            return Ok(LicenseMapper.ToGetDto(license));
        }

        [HttpGet("license-id-by-local-id/{localId}", Name = "GetLicenseIdByLocalId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetLicenseIdByLocalId(int localId)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            int result = await LicenseService.GetLicenseIDAsync(localId);
            if (result == -1)
                return NotFound("There's no license with this localId");

            return Ok(result);
        }
        
        [HttpGet("license-id-by-national-number/{nationalNo}", Name = "GetLicenseIdByNationalNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetLicenseIdByNationalNumber(string nationalNo)
        {
            int result = await LicenseService.GetLicenseIDAsync(nationalNo);
            if (result == -1)
                return NotFound("There's no license with this nationalNo");

            return Ok(result);
        }

        [HttpGet("deactivate/{licenseId}", Name = "DeactivateLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DeactivateLicense(int licenseId)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            bool result = await LicenseService.DeactivateLicenseAsync(licenseId);

            return Ok(result);
        }
        
        [HttpGet("active-license/by-person-id/{personId}/by-class-id/{classId}", Name = "GetActiveLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> GetActiveLicense(int personId, int classId)
        {
            if (personId < 1 || classId < 1)
                return BadRequest("Invalid data");

            int result = await LicenseService.GetActiveLicenseWithLicenseClassAsync(personId, classId);
            if (result == -1)
                return NotFound("There's no license class with this personId");

            return Ok(result);
        }

        [HttpPost(Name = "AddNewLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetLicenseDto>> AddNewLicense(CreateLicenseDto createLicense)
        {
            License newLicense = LicenseMapper.ToLicense(createLicense);

            bool result = await LicenseService.AddNewLicenseAsync(newLicense);
            if (!result)
                return StatusCode(500, new { message = "Error Adding License" });

            return CreatedAtRoute("GetLicenseById", new { id = newLicense.LicenseID }, LicenseMapper.ToGetDto(newLicense));
        }

        [HttpPut("{licenseId}", Name = "UpdateLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateLicenseDto>> UpdateLicense(int licenseId, UpdateLicenseDto updateLicense)
        {
            if (licenseId < 1)
                return BadRequest("Invalid data");

            License? license = await LicenseService.FindLicenseAsync(licenseId);
            if (license == null) return NotFound($"There's no license with this Id: {licenseId}");

            license.AppID = updateLicense.AppID;
            license.ExpiredDate = updateLicense.ExpiredDate;
            license.Notes = updateLicense.Notes;
            license.DriverID = updateLicense.DriverID;
            license.IsActive = updateLicense.IsActive;
            license.IssueReason = updateLicense.IssueReason;
            license.Fees = updateLicense.Fees;
            license.UserID = updateLicense.UserID;
            license.ClassID = updateLicense.ClassID;

            bool result = await LicenseService.UpdateLicenseAsync(license);
            if (result) return Ok(updateLicense);
            else return StatusCode(500, new { message = "Error Updating License" });
        }
    }
}
