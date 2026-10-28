using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.TestTypes;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/TestTypes")]
    [ApiController]
    public sealed class TestTypesController(ITestTypeService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllTestTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TestTypesDto>>> GetAllTestTypes(CancellationToken cancellationToken)
        {
            List<TestType> types = await service.GetAllTypesAsync(cancellationToken);
            var typeDto = types.Select(TestTypesMapper.ToTypesDto).ToList();
            return Ok(typeDto);
        }

        [HttpGet("{id}", Name = "GetTestTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestTypesDto>> GetTestTypeById(TestTypeEnum id, CancellationToken cancellationToken)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            TestType? type = await service.FindTypeAsync(id, cancellationToken);

            if (type == null) return NotFound($"There's no type with this Id: {id}");

            return Ok(TestTypesMapper.ToTypesDto(type));
        }

        [HttpPut("{id}", Name = "UpdateTestType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateTestTypesDto>> UpdateTestType(TestTypeEnum id, UpdateTestTypesDto updateType, CancellationToken cancellationToken)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            TestType? type = await service.FindTypeAsync(id, cancellationToken);

            if (type == null) return NotFound($"There's no type with this Id: {id}");

            type.Fees = updateType.Fees;
            type.Title = updateType.Title;
            type.Description = updateType.Description;

            bool result = await service.UpdateAppTypesAsync(type, cancellationToken);
            if (result) return Ok(updateType);
            else return StatusCode(500, new { message = "Error Updating Type" });
        }
    }
}
