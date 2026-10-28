using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.ApplicationTypes;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/ApplicationTypes")]
    [ApiController]
    public sealed class ApplicationTypesController(IApplicationTypeService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllAppTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TypesDto>>> GetAllAppTypes(CancellationToken cancellationToken)
        {
            List<ApplicationType> types = await service.GetAllTypesAsync(cancellationToken);
            var typeDto = types.Select(AppTypesMapper.ToTypesDto).ToList();
            return Ok(typeDto);
        }

        [HttpGet("{id}", Name = "GetTypeById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypesDto>> GetTypeById(AppTypeEnum id, CancellationToken cancellationToken)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            ApplicationType? type = await service.FindTypeAsync(id, cancellationToken);

            if (type == null) return NotFound($"There's no type with this Id: {id}");

            return Ok(AppTypesMapper.ToTypesDto(type));
        }

        [HttpGet("by-title/{title}", Name = "GetTypeByTitle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TypesDto>> GetTypeByTitle(string title, CancellationToken cancellationToken)
        {
            ApplicationType? type = await service.FindTypeAsync(title, cancellationToken);

            if (type == null) return NotFound($"There's no type with this title: {title}");

            return Ok(AppTypesMapper.ToTypesDto(type));
        }

        [HttpPut("{id}", Name = "UpdateType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateAppTypeDto>> UpdateType(AppTypeEnum id, UpdateAppTypeDto updateType, CancellationToken cancellationToken)
        {
            if ((int)id < 1)
                return BadRequest("Invalid data");

            ApplicationType? type = await service.FindTypeAsync(id, cancellationToken);
            if (type == null) return NotFound($"There's no type with this Id: {id}");

            type.Fees = updateType.Fees;
            type.Title = updateType.Title;

            bool result = await service.UpdateAppTypesAsync(type, cancellationToken);
            if (result) return Ok(updateType);
            else return StatusCode(500, new { message = "Error Updating Type" });
        }
    }
}
