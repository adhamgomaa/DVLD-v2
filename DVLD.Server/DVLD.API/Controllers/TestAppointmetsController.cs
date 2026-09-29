using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.TestAppointment;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/TestAppointments")]
    [ApiController]
    public class TestAppointmetsController : ControllerBase
    {
        [HttpGet("all/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "GetAllAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments(int localId, TestTypeEnum testTypeId)
        {
            List<TestAppointment> apps = await TestAppointmentService.GetAllAppointmentAsync(localId, testTypeId);
            var appDto = apps.Select(AppointmentMapper.ToAppointmentDto).ToList();
            return Ok(appDto);
        }

        [HttpGet("{id}", Name = "GetAppointmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetAppointmentDto>> GetAppointmentById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            TestAppointment? test = await TestAppointmentService.FindAppointmentAsync(id);

            if (test == null) return NotFound($"There's no appointment with this Id: {id}");

            return Ok(AppointmentMapper.ToGetDto(test));
        }
        
        [HttpGet("last/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "GetLastAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetAppointmentDto>> GetLastAppointment(int localId, TestTypeEnum testTypeId)
        {
            TestAppointment? test = await TestAppointmentService.GetLastTestAppointmentAsync(localId, testTypeId);

            if (test == null) return NotFound($"There's no appointments");

            return Ok(AppointmentMapper.ToGetDto(test));
        }

        [HttpGet("trails/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "GetTrails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetTrails(int localId, TestTypeEnum testTypeId)
        {
            int trails = await TestAppointmentService.GetTrialsAsync(localId, testTypeId);
           
            return Ok(trails);
        }

        [HttpGet("test-id/by-appointment-id/{appointmentId}", Name = "GetTestId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> GetTestId(int appointmentId)
        {
            if (appointmentId < 1)
                return BadRequest("Invalid data");
            int id = await TestAppointmentService.GetTestIdAsync(appointmentId);
            return Ok(id);
        }

        [HttpGet("is-lock/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "AppointmentIsLock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> AppointmentIsLock(int localId, TestTypeEnum testTypeId)
        {
            bool result = await TestAppointmentService.AppointmentIsLockAsync(localId, testTypeId);
           
            return Ok(result);
        }

        [HttpPost(Name = "AddNewAppointment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAppointmentDto>> AddNewAppointment(CreateAppointmentDto createApp)
        {
            TestAppointment newApp = AppointmentMapper.ToApp(createApp);

            bool result = await TestAppointmentService.AddNewAppointmentAsync(newApp);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Appointment" });

            return CreatedAtRoute("GetAppointmentById", new { id = newApp.AppointmentId }, AppointmentMapper.ToGetDto(newApp));
        }

        [HttpPut("{id}", Name = "UpdateAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateAppointmentDto>> UpdateAppointment(int id, UpdateAppointmentDto updateApp)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            TestAppointment? test = await TestAppointmentService.FindAppointmentAsync(id);
            if (test == null) return NotFound($"There's no appointment with this Id: {id}");

            test.Date = updateApp.Date;
            test.Fees = updateApp.Fees;
            test.IsLocked = updateApp.IsLocked;
            test.LocalId = updateApp.LocalId;
            test.UserId = updateApp.UserId;
            test.TestTypeId = updateApp.TestTypeId;

            bool result = await TestAppointmentService.UpdateAppointmentAsync(test);
            if (result) return Ok(updateApp);
            else return StatusCode(500, new { message = "Error Updating Appointment" });
        }
    }
}
