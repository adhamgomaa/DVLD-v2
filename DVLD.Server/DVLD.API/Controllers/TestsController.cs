using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
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
    public sealed class TestsController(ITestService service) : ControllerBase
    {
        [HttpGet("{id}", Name = "GetTestById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestDto>> GetTestById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Test? test = await service.FindTestAsync(id, cancellationToken);

            if (test == null) return NotFound($"There's no test with this Id: {id}");

            return Ok(TestMapper.ToGetDto(test));
        }
        
        [HttpGet("last/local-id/{localId}/test-type/{testTypeId}", Name = "GetLastTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TestDto>> GetLastTest(int localId, TestTypeEnum testTypeId, CancellationToken cancellationToken)
        {
            Test? test = await service.GetLastTestAsync(localId, testTypeId, cancellationToken);

            if (test == null) return NotFound($"There's no tests");

            return Ok(TestMapper.ToGetDto(test));
        }

        [HttpPost(Name = "AddNewTest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TestDto>> AddNewApp(CreateTestDto createTest, CancellationToken cancellationToken)
        {
            Test newTest = TestMapper.ToTest(createTest);

            bool result = await service.AddNewTestAsync(newTest, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Test" });

            return CreatedAtRoute("GetTestById", new { id = newTest.AppointmentID }, TestMapper.ToGetDto(newTest));
        }

        [HttpPut("{id}", Name = "UpdateTest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateTestDto>> UpdateApp(int id, UpdateTestDto updateTest, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Test? test = await service.FindTestAsync(id, cancellationToken);
            if (test == null) return NotFound($"There's no test with this Id: {id}");

            test.AppointmentID = updateTest.AppointmentID;
            test.Result = updateTest.Result;
            test.Notes = updateTest.Notes;
            test.UserId = updateTest.UserId;
           
            bool result = await service.UpdateTestAsync(test, cancellationToken);
            if (result) return Ok(updateTest);
            else return StatusCode(500, new { message = "Error Updating Test" });
        }
    }
}
