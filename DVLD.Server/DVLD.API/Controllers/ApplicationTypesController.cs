using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.ApplicationTypes;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/ApplicationTypes")]
    [ApiController]
    public class ApplicationTypesController : ControllerBase
    {
        [HttpGet(Name = "GetAllAppTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypesDto>>> GetAllAppTypes()
        {
            List<ApplicationType> types = await ApplicationTypeService.GetAllTypesAsync();
            var typeDto = types.Select(AppTypesMapper.ToTypesDto).ToList();
            return Ok(typeDto);
        }

        [HttpGet("{id}", Name = "GetTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypesDto>> GetTypeById(AppTypeEnum id)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            ApplicationType? type = await ApplicationTypeService.FindTypeAsync(id);

            if (type == null) return NotFound($"There's no type with this Id: {id}");

            return Ok(AppTypesMapper.ToTypesDto(type));
        }

        [HttpGet("by-title/{title}", Name = "GetTypeByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypesDto>> GetTypeByTitle(string title)
        {
            ApplicationType? type = await ApplicationTypeService.FindTypeAsync(title);

            if (type == null) return NotFound($"There's no type with this title: {title}");

            return Ok(AppTypesMapper.ToTypesDto(type));
        }

        [HttpPut("{id}", Name = "UpdateType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateAppTypeDto>> UpdateType(AppTypeEnum id, UpdateAppTypeDto updateType)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            ApplicationType? type = await ApplicationTypeService.FindTypeAsync(id);
            if (type == null) return NotFound($"There's no type with this Id: {id}");

            type.Fees = updateType.Fees;
            type.Title = updateType.Title;

            bool result = await ApplicationTypeService.UpdateAppTypesAsync(type);
            if (result) return Ok(updateType);
            else return StatusCode(500, new { message = "Error Updating Type" });
        }
    }
}
