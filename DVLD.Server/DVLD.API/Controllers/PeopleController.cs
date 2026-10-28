using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.People;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DVLD.API.Controllers
{
    [Route("api/People")]
    [ApiController]
    public sealed class PeopleController(IPersonService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PeopleDto>>> GetAllPeople(CancellationToken cancellationToken)
        {
            List<PeopleInfo> people = await service.GetPeopleAsync(cancellationToken);
            var personDto = people.Select(PersonMapper.ToPeopleDto).ToList();
            return Ok(personDto);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPersonDto>> GetPersonById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Person? person = await service.FindPersonAsync(id, cancellationToken);

            if (person == null) return NotFound($"There's no person with this Id: {id}");

            return Ok(PersonMapper.ToGetDto(person));
        }

        [HttpGet("by-national-no/{nationalNo}", Name = "GetPersonByNationalNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPersonDto>> GetPersonByNationalNumber(string nationalNo, CancellationToken cancellationToken)
        {

            Person? person = await service.FindPersonAsync(nationalNo, cancellationToken);

            if (person == null) return NotFound($"There's no person with this National Number: {nationalNo}");

            return Ok(PersonMapper.ToGetDto(person));
        }

        [HttpGet("{id}/exists", Name = "IsPersonExistById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsPersonExistById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool IsExist = await service.IsPersonExistAsync(id, cancellationToken);
            return Ok(IsExist);
        }
        
        [HttpGet("{nationalNo}/by-national-no/exists", Name = "IsPersonExistByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> IsPersonExistByNationalNo(string nationalNo, CancellationToken cancellationToken)
        {
            bool IsExist = await service.IsPersonExistAsync(nationalNo, cancellationToken);
            return Ok(IsExist);
        }

        [HttpPost(Name = "AddNewPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetPersonDto>> AddNewPerson(CreatePersonDto createPerson, CancellationToken cancellationToken)
        {
            Person newPerson = PersonMapper.ToPerson(createPerson);

            bool result = await service.AddNewPersonAsync(newPerson, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Person" });

            return CreatedAtRoute("GetPersonByID", new { id = newPerson.PersonId }, PersonMapper.ToGetDto(newPerson));
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdatePersonDto>> UpdatePerson(int id, UpdatePersonDto updatePerson, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Person? person = await service.FindPersonAsync(id, cancellationToken);
            if (person == null) return NotFound($"There's no person with this Id: {id}");

            person.NationalNo = updatePerson.NationalNo;
            person.FName = updatePerson.FName;
            person.SecName = updatePerson.SecName;
            person.ThName = updatePerson.ThName;
            person.LName = updatePerson.LName;
            person.Date = updatePerson.Date;
            person.Gendor = updatePerson.Gendor;
            person.Address = updatePerson.Address;
            person.Phone = updatePerson.Phone;
            person.Email = updatePerson.Email;
            person.NationaltyId = updatePerson.NationaltyId;
            person.ImagePath = updatePerson.ImagePath;

            bool result = await service.UpdatePersonAsync(person, cancellationToken);
            if (result) return Ok(updatePerson);
            else return StatusCode(500, new { message = "Error Updating Person" });
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePerson(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool exists = await service.IsPersonExistAsync(id, cancellationToken);
            if (!exists) return NotFound($"There's no person with this Id: {id}");
            bool result = await service.DeletePersonAsync(id, cancellationToken);
            return result ? Ok($"Person With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting Person" });
        }
    }
}
