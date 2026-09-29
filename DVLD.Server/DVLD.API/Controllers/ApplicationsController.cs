using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.Applications;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/Applications")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetApplicationById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetAppDto>> GetApplicationById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Application? app = await ApplicationService.FindAppAsync(id);

            if (app == null) return NotFound($"There's no application with this Id: {id}");

            return Ok(ApplicationMapper.ToGetDto(app));
        }

        [HttpPost(Name = "AddNewApp")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetAppDto>> AddNewApp(CreateAppDto createApp)
        {
            Application newApp = ApplicationMapper.ToApp(createApp);

            bool result = await ApplicationService.AddNewAppAsync(newApp);
            if (!result)
                return StatusCode(500, new { message = "Error Adding Application" });

            return CreatedAtRoute("GetApplicationById", new { id = newApp.AppID }, ApplicationMapper.ToGetDto(newApp));
        }

        [HttpPut("{id}", Name = "UpdateApp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateAppDto>> UpdateApp(int id, UpdateAppDto updateApp)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            Application? app = await ApplicationService.FindAppAsync(id);
            if (app == null) return NotFound($"There's no application with this Id: {id}");

            app.PersonId = updateApp.PersonId;
            app.AppStatus = updateApp.AppStatus;
            app.Type = updateApp.Type;
            app.StatusDate = updateApp.StatusDate;
            app.Fees = updateApp.Fees;
            app.UserId = updateApp.UserId;

            bool result = await ApplicationService.UpdateAppAsync(app);
            if (result) return Ok(updateApp);
            else return StatusCode(500, new { message = "Error Updating Application" });
        }

        [HttpDelete("{id}", Name = "DeleteApp")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteApp(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool result = await ApplicationService.DeleteAppAsync(id);
            return result ? Ok($"Application With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting Application" });
        }
    }
}
