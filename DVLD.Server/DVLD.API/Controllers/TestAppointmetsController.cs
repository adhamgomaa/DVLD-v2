using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.TestAppointment;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/TestAppointments")]
    [ApiController]
    public sealed class TestAppointmetsController(ITestAppointmentService service) : ControllerBase
    {
        [HttpGet("all/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "GetAllAppointments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetAllAppointments(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            List<TestAppointment> apps = await service.GetAllAppointmentAsync(localId, testTypeId, cancellationToken);
            var appDto = apps.Select(AppointmentMapper.ToAppointmentDto).ToList();
            return Ok(appDto);
        }

        [HttpGet("{id}", Name = "GetAppointmentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetAppointmentDto>> GetAppointmentById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            TestAppointment? test = await service.FindAppointmentAsync(id, cancellationToken);

            if (test == null) return NotFound($"There's no appointment with this Id: {id}");

            return Ok(AppointmentMapper.ToGetDto(test));
        }
        
        [HttpGet("last/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "GetLastAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetAppointmentDto>> GetLastAppointment(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            TestAppointment? test = await service.GetLastTestAppointmentAsync(localId, testTypeId, cancellationToken);

            if (test == null) return NotFound($"There's no appointments");

            return Ok(AppointmentMapper.ToGetDto(test));
        }

        [HttpGet("trails/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "GetTrails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> GetTrails(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            int trails = await service.GetTrialsAsync(localId, testTypeId, cancellationToken);
           
            return Ok(trails);
        }

        [HttpGet("test-id/by-appointment-id/{appointmentId}", Name = "GetTestId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> GetTestId(int appointmentId, CancellationToken cancellationToken)
        {
            if (appointmentId < 1)
                return BadRequest("Invalid data");
            int id = await service.GetTestIdAsync(appointmentId, cancellationToken);
            return Ok(id);
        }

        [HttpGet("is-lock/by-local-id/{localId}/by-test-type/{testTypeId}", Name = "AppointmentIsLock")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> AppointmentIsLock(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            bool result = await service.AppointmentIsLockAsync(localId, testTypeId, cancellationToken);
           
            return Ok(result);
        }

        [HttpPost(Name = "AddNewAppointment")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAppointmentDto>> AddNewAppointment(CreateAppointmentDto createApp, CancellationToken cancellationToken)
        {
            TestAppointment newApp = AppointmentMapper.ToApp(createApp);

            bool result = await service.AddNewAppointmentAsync(newApp, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Appointment" });

            return CreatedAtRoute("GetAppointmentById", new { id = newApp.AppointmentId }, AppointmentMapper.ToGetDto(newApp));
        }

        [HttpPut("{id}", Name = "UpdateAppointment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateAppointmentDto>> UpdateAppointment(int id, UpdateAppointmentDto updateApp, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            TestAppointment? test = await service.FindAppointmentAsync(id, cancellationToken);
            if (test == null) return NotFound($"There's no appointment with this Id: {id}");

            test.Date = updateApp.Date;
            test.Fees = updateApp.Fees;
            test.IsLocked = updateApp.IsLocked;
            test.LocalId = updateApp.LocalId;
            test.UserId = updateApp.UserId;
            test.TestTypeId = updateApp.TestTypeId;

            bool result = await service.UpdateAppointmentAsync(test, cancellationToken);
            if (result) return Ok(updateApp);
            else return StatusCode(500, new { message = "Error Updating Appointment" });
        }
    }
}
