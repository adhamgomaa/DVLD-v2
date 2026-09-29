using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.LocalLicense;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/LocalLicense")]
    [ApiController]
    public class LocalLicenseController : ControllerBase
    {
        [HttpGet(Name = "GetAllLocalLicenses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<LocalLicenseDto>>> GetAllLocalLicenses()
        {
            List<LocalDrivingApplications> licenses = await LocalDrivingLicenseService.GetAllLocalLicensesAsync();
            var licenseDto = licenses.Select(LocalLicenseMapper.ToLocalDto).ToList();
            return Ok(licenseDto);
        }
        [HttpGet("{id}", Name = "GetLocalLicenseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetLocalLicenseDto>> GetLocalLicenseById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            LocalLicense? license = await LocalDrivingLicenseService.FindLocalLicenseAsync(id);

            if (license == null) return NotFound($"There's no license with this Id: {id}");

            return Ok(LocalLicenseMapper.ToGetDto(license));
        }

        [HttpGet("cancel/{localId}", Name = "CancelLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> CancelLicense(int localId)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await LocalDrivingLicenseService.CancelLicenseAsync(localId);

            return Ok(result);
        }
        
        [HttpGet("check-same-class/by-person-id/{personId}/by-class-id/{classId}", Name = "CheckPersonHasSameClass")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> CheckPersonHasSameClass(int personId, int classId)
        {
            if (personId < 1 || classId < 1)
                return BadRequest("Invalid data");

            bool result = await LocalDrivingLicenseService.CheckPersonHasSameClassAsync(personId, classId);

            return Ok(result);
        }

        [HttpGet("passed-test-count/{localId}", Name = "GetPassedTestCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<byte>> GetPassedTestCount(int localId)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            byte result = await LocalDrivingLicenseService.GetPassedTestCountAsync(localId);

            return Ok(result);
        }
        
        [HttpGet("total-trails-per-test/{localId}/{testTypeId}", Name = "GetTotalTrailsPerTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<byte>> GetTotalTrailsPerTest(int localId, TestTypeEnum testTypeId)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            byte result = await LocalDrivingLicenseService.GetTotalTrailsPerTestAsync(localId, testTypeId);

            return Ok(result);
        }
        
        [HttpGet("dose-attend-test-type/{localId}/{testTypeId}", Name = "DoseAttendTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DoseAttendTestType(int localId, TestTypeEnum testTypeId)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await LocalDrivingLicenseService.DoseAttendTestTypeAsync(localId, testTypeId);

            return Ok(result);
        }
        
        [HttpGet("dose-pass-test-type/{localId}/{testTypeId}", Name = "DosePassTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> DosePassTestType(int localId, TestTypeEnum testTypeId)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await LocalDrivingLicenseService.DosePassTestTypeAsync(localId, testTypeId);

            return Ok(result);
        }
        
        [HttpGet("is-there-an-active-test/{localId}/{testTypeId}", Name = "IsThereAnActiveTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsThereAnActiveTest(int localId, TestTypeEnum testTypeId)
        {
            if (localId < 1)
                return BadRequest("Invalid data");

            bool result = await LocalDrivingLicenseService.IsThereAnActiveTestAsync(localId, testTypeId);

            return Ok(result);
        }

        [HttpPost(Name = "AddNewLocalLicense")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetLocalLicenseDto>> AddNewLocalLicense(CreateLocalLicenseDto createLicense)
        {
            LocalLicense newLicense = LocalLicenseMapper.ToLicense(createLicense);

            bool check = await LocalDrivingLicenseService.CheckPersonHasSameClassAsync(newLicense.PersonId, newLicense.ClassId);
            if (check)
                return StatusCode(500, new { message = "This person has the same class, please choose another class" });

            bool result = await LocalDrivingLicenseService.AddNewLocalAsync(newLicense);
            if (!result)
                return StatusCode(500, new { message = "Error Adding License" });

            LocalLicense? license = await LocalDrivingLicenseService.FindLocalLicenseAsync(newLicense.LocalId);

            return CreatedAtRoute("GetLocalLicenseById", new { id = newLicense.LocalId }, LocalLicenseMapper.ToGetDto(license!));
        }

        [HttpPut("{id}", Name = "UpdateLocalLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateLocalLicenseDto>> UpdateLocalLicense(int id, UpdateLocalLicenseDto updateLicense)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            LocalLicense? license = await LocalDrivingLicenseService.FindLocalLicenseAsync(id);
            if (license == null) return NotFound($"There's no license with this Id: {id}");

            license.PersonId = updateLicense.PersonId;
            license.AppStatus = updateLicense.AppStatus;
            license.Type = updateLicense.Type;
            license.StatusDate = updateLicense.StatusDate;
            license.Fees = updateLicense.Fees;
            license.UserId = updateLicense.UserId;
            license.ClassId = updateLicense.ClassId;

            bool check = await LocalDrivingLicenseService.CheckPersonHasSameClassAsync(license.PersonId, license.ClassId);
            if (check)
               return StatusCode(500, new { message = "This person has the same class, please choose another class" });

            bool result = await LocalDrivingLicenseService.UpdateLocalAsync(license);
            if (result) return Ok(updateLicense);
            else return StatusCode(500, new { message = "Error Updating License" });
        }

        [HttpDelete("local-id/{localId}/app-id/{appId}", Name = "DeleteLocalLicense")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteLocalLicense(int localId, int appId)
        {
            if (localId < 1 || appId < 1)
                return BadRequest("Invalid data");
            bool result = await LocalDrivingLicenseService.DeleteAsync(localId, appId);
            return result ? Ok($"Local License With ID {localId} has been deleted") : StatusCode(500, new { message = "Error Deleting License" });
        }
    }
}
