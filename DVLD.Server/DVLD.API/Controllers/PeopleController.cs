using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.People;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/People")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet(Name = "GetAllPeople")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<PeopleDto>>> GetAllPeople()
        {
            List<PeopleInfo> people = await PersonService.GetPeopleAsync();
            var personDto = people.Select(PersonMapper.ToPeopleDto).ToList();
            return Ok(personDto);
        }

        [HttpGet("{id}", Name = "GetPersonById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPersonDto>> GetPersonById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Person? person = await PersonService.FindPersonAsync(id);

            if (person == null) return NotFound($"There's no person with this Id: {id}");

            return Ok(PersonMapper.ToGetDto(person));
        }

        [HttpGet("by-national-no/{nationalNo}", Name = "GetPersonByNationalNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetPersonDto>> GetPersonByNationalNumber(string nationalNo)
        {

            Person? person = await PersonService.FindPersonAsync(nationalNo);

            if (person == null) return NotFound($"There's no person with this National Number: {nationalNo}");

            return Ok(PersonMapper.ToGetDto(person));
        }

        [HttpGet("{id}/exists", Name = "IsPersonExistById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsPersonExistById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool IsExist = await PersonService.IsPersonExistAsync(id);
            return Ok(IsExist);
        }
        
        [HttpGet("{nationalNo}/by-national-no/exists", Name = "IsPersonExistByNationalNo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> IsPersonExistByNationalNo(string nationalNo)
        {
            bool IsExist = await PersonService.IsPersonExistAsync(nationalNo);
            return Ok(IsExist);
        }

        [HttpPost(Name = "AddNewPerson")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetPersonDto>> AddNewPerson(CreatePersonDto createPerson)
        {
            Person newPerson = PersonMapper.ToPerson(createPerson);

            bool result = await PersonService.AddNewPersonAsync(newPerson);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Person" });

            return CreatedAtRoute("GetPersonByID", new { id = newPerson.PersonId }, PersonMapper.ToGetDto(newPerson));
        }

        [HttpPut("{id}", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdatePersonDto>> UpdatePerson(int id, UpdatePersonDto updatePerson)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Person? person = await PersonService.FindPersonAsync(id);
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

            bool result = await PersonService.UpdatePersonAsync(person);
            if (result) return Ok(updatePerson);
            else return StatusCode(500, new { message = "Error Updating Person" });
        }

        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeletePerson(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool exists = await PersonService.IsPersonExistAsync(id);
            if (!exists) return NotFound($"There's no person with this Id: {id}");
            bool result = await PersonService.DeletePersonAsync(id);
            return result ? Ok($"Person With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting Person" });
        }
    }
}
