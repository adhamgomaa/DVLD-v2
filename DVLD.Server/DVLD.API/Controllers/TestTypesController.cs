using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.TestTypes;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/TestTypes")]
    [ApiController]
    public class TestTypesController : ControllerBase
    {
        [HttpGet(Name = "GetAllTestTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TestTypesDto>>> GetAllTestTypes()
        {
            List<TestType> types = await TestTypeService.GetAllTypesAsync();
            var typeDto = types.Select(TestTypesMapper.ToTypesDto).ToList();
            return Ok(typeDto);
        }

        [HttpGet("{id}", Name = "GetTestTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestTypesDto>> GetTestTypeById(TestTypeEnum id)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            TestType? type = await TestTypeService.FindTypeAsync(id);

            if (type == null) return NotFound($"There's no type with this Id: {id}");

            return Ok(TestTypesMapper.ToTypesDto(type));
        }

        [HttpPut("{id}", Name = "UpdateTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateTestTypesDto>> UpdateTestType(TestTypeEnum id, UpdateTestTypesDto updateType)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            TestType? type = await TestTypeService.FindTypeAsync(id);

            if (type == null) return NotFound($"There's no type with this Id: {id}");

            type.Fees = updateType.Fees;
            type.Title = updateType.Title;
            type.Description = updateType.Description;

            bool result = await TestTypeService.UpdateAppTypesAsync(type);
            if (result) return Ok(updateType);
            else return StatusCode(500, new { message = "Error Updating Type" });
        }
    }
}
