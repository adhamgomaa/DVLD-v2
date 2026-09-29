using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.Tests;
using DVLD.Shared.Entities;
using DVLD.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD.API.Controllers
{
    [Route("api/Tests")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetTestById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestDto>> GetTestById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Test? test = await TestService.FindTestAsync(id);

            if (test == null) return NotFound($"There's no test with this Id: {id}");

            return Ok(TestMapper.ToGetDto(test));
        }
        
        [HttpGet("last/local-id/{localId}/test-type/{testTypeId}", Name = "GetLastTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestDto>> GetLastTest(int localId, TestTypeEnum testTypeId)
        {
            Test? test = await TestService.GetLastTestAsync(localId, testTypeId);

            if (test == null) return NotFound($"There's no tests");

            return Ok(TestMapper.ToGetDto(test));
        }

        [HttpPost(Name = "AddNewTest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TestDto>> AddNewApp(CreateTestDto createTest)
        {
            Test newTest = TestMapper.ToTest(createTest);

            bool result = await TestService.AddNewTestAsync(newTest);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Test" });

            return CreatedAtRoute("GetTestById", new { id = newTest.AppointmentID }, TestMapper.ToGetDto(newTest));
        }

        [HttpPut("{id}", Name = "UpdateTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateTestDto>> UpdateApp(int id, UpdateTestDto updateTest)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Test? test = await TestService.FindTestAsync(id);
            if (test == null) return NotFound($"There's no test with this Id: {id}");

            test.AppointmentID = updateTest.AppointmentID;
            test.Result = updateTest.Result;
            test.Notes = updateTest.Notes;
            test.UserId = updateTest.UserId;
           
            bool result = await TestService.UpdateTestAsync(test);
            if (result) return Ok(updateTest);
            else return StatusCode(500, new { message = "Error Updating Test" });
        }
    }
}
