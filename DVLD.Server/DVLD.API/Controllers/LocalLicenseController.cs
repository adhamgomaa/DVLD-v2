using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.LocalLicense;
using DVLD.Shared.Models;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/LocalLicense")]
    [ApiController]
    public sealed class LocalLicenseController(ILocalDrivingLicenseService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllLocalLicenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LocalLicenseDto>>> GetAllLocalLicenses(CancellationToken cancellationToken)
        {
            List<LocalDrivingLicenseApplication> licenses = await service.GetAllLocalLicensesAsync(cancellationToken);
            var licenseDto = licenses.Select(LocalLicenseMapper.ToLocalDto).ToList();
            return Ok(licenseDto);
        }
        [HttpGet("{id}", Name = "GetLocalLicenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetLocalLicenseDto>> GetLocalLicenseById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            LocalDrivingLicense? license = await service.FindLocalLicenseAsync(id, cancellationToken);

            if (license == null) return NotFound($"There's no license with this Id: {id}");

            return Ok(LocalLicenseMapper.ToGetDto(license));
        }

        [HttpGet("cancel/{localId}", Name = "CancelLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> CancelLicense(int localId, CancellationToken cancellationToken)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await service.CancelLicenseAsync(localId, cancellationToken);

            return Ok(result);
        }
        
        [HttpGet("check-same-class/by-person-id/{personId}/by-class-id/{classId}", Name = "CheckPersonHasSameClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> CheckPersonHasSameClass(int personId, int classId, CancellationToken cancellationToken)
        {
            if (personId < 1 || classId < 1)
                return BadRequest("Invalid data");

            bool result = await service.CheckPersonHasSameClassAsync(personId, classId, cancellationToken);

            return Ok(result);
        }

        [HttpGet("passed-test-count/{localId}", Name = "GetPassedTestCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<byte>> GetPassedTestCount(int localId, CancellationToken cancellationToken)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            byte result = await service.GetPassedTestCountAsync(localId, cancellationToken);

            return Ok(result);
        }
        
        [HttpGet("total-trails-per-test/{localId}/{testTypeId}", Name = "GetTotalTrailsPerTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> GetTotalTrailsPerTest(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            int result = await service.GetTotalTrailsPerTestAsync(localId, testTypeId, cancellationToken);

            return Ok(result);
        }
        
        [HttpGet("dose-attend-test-type/{localId}/{testTypeId}", Name = "DoseAttendTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DoseAttendTestType(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await service.DoseAttendTestTypeAsync(localId, testTypeId, cancellationToken);

            return Ok(result);
        }
        
        [HttpGet("dose-pass-test-type/{localId}/{testTypeId}", Name = "DosePassTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DosePassTestType(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await service.DosePassTestTypeAsync(localId, testTypeId, cancellationToken);

            return Ok(result);
        }
        
        [HttpGet("is-there-an-active-test/{localId}/{testTypeId}", Name = "IsThereAnActiveTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsThereAnActiveTest(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await service.IsThereAnActiveTestAsync(localId, testTypeId, cancellationToken);

            return Ok(result);
        }

        [HttpPost(Name = "AddNewLocalLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetLocalLicenseDto>> AddNewLocalLicense(CreateLocalLicenseDto createLicense, CancellationToken cancellationToken)
        {
            LocalDrivingLicense newLicense = LocalLicenseMapper.ToLicense(createLicense);

            bool check = await service.CheckPersonHasSameClassAsync(newLicense.Application.ApplicantPersonId, newLicense.LicenseClassId, cancellationToken);
            if (check)
                return StatusCode(500, new { message = "This person has the same class, please choose another class" });

            bool result = await service.AddNewLocalAsync(newLicense, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding License" });

            return CreatedAtRoute("GetLocalLicenseById", new { id = newLicense.LocalDrivingLicenseApplicationId }, LocalLicenseMapper.ToGetDto(newLicense));
        }

        [HttpPut("{id}", Name = "UpdateLocalLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateLocalLicenseDto>> UpdateLocalLicense(int id, UpdateLocalLicenseDto updateLicense, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            LocalDrivingLicense? license = await service.FindLocalLicenseAsync(id, cancellationToken);
            if (license == null) return NotFound($"There's no license with this Id: {id}");

            license.Application.ApplicantPersonId = updateLicense.PersonId;
            license.Application.ApplicationStatus = updateLicense.AppStatus;
            license.Application.ApplicationTypeId = updateLicense.Type;
            license.Application.LastStatusDate = updateLicense.StatusDate;
            license.Application.PaidFees = updateLicense.Fees;
            license.Application.CreatedByUserId = updateLicense.UserId;
            license.LicenseClassId = updateLicense.ClassId;

            bool check = await service.CheckPersonHasSameClassAsync(license.Application.ApplicantPersonId, license.LicenseClassId, cancellationToken);
            if (check)
                return StatusCode(500, new { message = "This person has the same class, please choose another class" });

            bool result = await service.UpdateLocalAsync(license, cancellationToken);
            if (result) return Ok(updateLicense);
            else return StatusCode(500, new { message = "Error Updating License" });
        }

        [HttpDelete("local-id/{localId}/app-id/{appId}", Name = "DeleteLocalLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteLocalLicense(int localId, int appId, CancellationToken cancellationToken)
        {
            if (localId < 1 || appId < 1)
                return BadRequest("Invalid data");
            bool result = await service.DeleteAsync(localId, appId, cancellationToken);
            return result ? Ok($"Local License With ID {localId} has been deleted") : StatusCode(500, new { message = "Error Deleting License" });
        }
    }
}
