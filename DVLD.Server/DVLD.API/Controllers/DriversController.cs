using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.Drivers;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/Drivers")]
    [ApiController]
    public sealed class DriversController(IDriverService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllDrivers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetAllDrivers(CancellationToken cancellationToken)
        {
            List<DriverInfo> drivers = await service.ListDriversAsync(cancellationToken);
            var driverDto = drivers.Select(DriverMapper.ToDriverDto).ToList();
            return Ok(driverDto);
        }

        [HttpGet("{id}", Name = "GetDriverById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDriverDto>> GetDriverById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Driver? driver = await service.FindDriverWithDriverIDAsync(id, cancellationToken);

            if (driver == null) return NotFound($"There's no driver with this Id: {id}");

            return Ok(DriverMapper.ToGetDto(driver));
        }

        [HttpGet("by-person-id/{personId}", Name = "GetDriverByPersonId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDriverDto>> GetDriverByPersonId(int personId, CancellationToken cancellationToken)
        {
            if (personId < 1)
                return BadRequest("Invalid data");

            Driver? driver = await service.FindDriverAsync(personId, cancellationToken);

            if (driver == null) return NotFound($"There's no driver with this personId: {personId}");

            return Ok(DriverMapper.ToGetDto(driver));
        }

        [HttpGet("is-person-driver/{personId}", Name = "IsPersonDriver")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsPersonDriver(int personId, CancellationToken cancellationToken)
        {
            if (personId < 1)
                return BadRequest("Invalid data");
            bool IsExist = await service.IsPersonDriverAsync(personId, cancellationToken);
            return Ok(IsExist);
        }

        [HttpPost(Name = "AddNewDriver")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetDriverDto>> AddNewDriver(CreateDriverDto createDriver, CancellationToken cancellationToken)
        {
            Driver newDriver = DriverMapper.ToDriver(createDriver);

            bool result = await service.AddNewDriverAsync(newDriver, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Driver" });

            return CreatedAtRoute("GetDriverById", new { id = newDriver.DriverID }, DriverMapper.ToGetDto(newDriver));
        }
    }
}
