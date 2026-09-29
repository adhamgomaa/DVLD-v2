using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.Drivers;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/Drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        [HttpGet(Name = "GetAllDrivers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DriverDto>>> GetAllDrivers()
        {
            List<DriverInfo> drivers = await DriverService.ListDriversAsync();
            var driverDto = drivers.Select(DriverMapper.ToDriverDto).ToList();
            return Ok(driverDto);
        }

        [HttpGet("{id}", Name = "GetDriverById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDriverDto>> GetDriverById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Driver? driver = await DriverService.FindDriverWithDriverIDAsync(id);

            if (driver == null) return NotFound($"There's no driver with this Id: {id}");

            return Ok(DriverMapper.ToGetDto(driver));
        }

        [HttpGet("by-person-id/{personId}", Name = "GetDriverByPersonId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetDriverDto>> GetDriverByPersonId(int personId)
        {
            if (personId < 1)
                return BadRequest("Invalid data");

            Driver? driver = await DriverService.FindDriverAsync(personId);

            if (driver == null) return NotFound($"There's no driver with this personId: {personId}");

            return Ok(DriverMapper.ToGetDto(driver));
        }

        [HttpGet("is-person-driver/{personId}", Name = "IsPersonDriver")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsPersonDriver(int personId)
        {
            if (personId < 1)
                return BadRequest("Invalid data");
            bool IsExist = await DriverService.IsPersonDriverAsync(personId);
            return Ok(IsExist);
        }

        [HttpPost(Name = "AddNewDriver")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetDriverDto>> AddNewDriver(CreateDriverDto createDriver)
        {
            Driver newDriver = DriverMapper.ToDriver(createDriver);

            bool result = await DriverService.AddNewDriverAsync(newDriver);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Driver" });

            return CreatedAtRoute("GetDriverById", new { id = newDriver.DriverID }, DriverMapper.ToGetDto(newDriver));
        }
    }
}
