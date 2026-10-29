using DVLD.Business.Interfaces;
using DVLD.API.Mappers;
using DVLD.DTOs.Users;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DVLD.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public sealed class UsersController(IUserService service) : ControllerBase
    {
        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetAllUsers(CancellationToken cancellationToken)
        {
            List<UserInfo> users = await service.GetUsersAsync(cancellationToken);
            var userDto = users.Select(UserMapper.ToUserDto).ToList();
            return Ok(userDto);
        }

        [HttpGet("info/{id}", Name = "GetUserInfoById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDto>> GetUserInfoById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = await service.FindUserAsync(id, cancellationToken);

            if (user == null) return NotFound($"There's no user with this Id: {id}");

            return Ok(UserMapper.ToGetDto(user));
        }
        
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDto>> GetUserById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = await service.FindUserAsync(id, cancellationToken);

            if (user == null) return NotFound($"There's no user with this Id: {id}");

            return Ok(UserMapper.ToGetDto(user));
        }

        [HttpGet("by-username/{username}", Name = "GetUserByUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDto>> GetUserByUsername(string username, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Invalid data");

            User? user = await service.FindUserAsync(username, cancellationToken);

            if (user == null) return NotFound($"There's no user with this username: {username}");

            return Ok(UserMapper.ToGetDto(user));
        }

        [HttpGet("{id}/exists", Name = "IsUserExistById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsUserExistById(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool IsExist = await service.IsUserExistAsync(id, cancellationToken);
            return Ok(IsExist);
        }
        [HttpGet("{username}/by-username/exists", Name = "IsUserExistByUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsUserExistByUsername(string username, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Invalid data");
            bool IsExist = await service.IsUserExistAsync(username, cancellationToken);
            return Ok(IsExist);
        }

        [HttpGet("{personId}/by-person-id/exists", Name = "IsUserExistByPersonId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> IsUserExistByPersonId(int personId, CancellationToken cancellationToken)
        {
            if (personId < 1)
                return BadRequest("Invalid data");
            bool IsExist = await service.IsUserExistByPersonIdAsync(personId, cancellationToken);
            return Ok(IsExist);
        }

        [HttpPost(Name = "AddNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserDto>> AddNewUser(CreateUserDto createUser, CancellationToken cancellationToken)
        {
            User newUser = UserMapper.ToUser(createUser);

            bool result = await service.AddNewUserAsync(newUser, cancellationToken);
            if (!result)
                return StatusCode(500, new { message = "Error Adding User" });

            return CreatedAtRoute("GetUserById", new { id = newUser.UserId }, UserMapper.ToGetDto(newUser));
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateUserDto>> UpdateUser(
            int id,
            UpdateUserDto updateUser,
            CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = await service.FindUserAsync(id, cancellationToken);
            if (user == null) return NotFound($"There's no user with this Id: {id}");

            user.PersonId = updateUser.PersonId;
            user.UserName = updateUser.UserName;
            if (!string.IsNullOrWhiteSpace(updateUser.Password))
                user.Password = updateUser.Password;
            user.IsActive = updateUser.IsActive;

            bool result = await service.UpdateUserAsync(user, cancellationToken);
            if (result) return Ok(updateUser);
            else return StatusCode(500, new { message = "Error Updating User" });
        }

        [HttpPut("{id}/password", Name = "ChangeUserPassword")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ChangePassword(
            int id,
            ChangePasswordDto changePassword,
            CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            string? authenticatedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(authenticatedUserId, out int currentUserId) ||
                currentUserId != id)
            {
                return Forbid();
            }

            if (!await service.IsUserExistAsync(id, cancellationToken))
                return NotFound($"There's no user with this Id: {id}");

            bool changed = await service.ChangePasswordAsync(
                id,
                changePassword.CurrentPassword,
                changePassword.NewPassword,
                cancellationToken);

            return changed
                ? NoContent()
                : Unauthorized("The current password is incorrect");
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(int id, CancellationToken cancellationToken)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool exists = await service.IsUserExistAsync(id, cancellationToken);
            if (!exists) return NotFound($"There's no user with this Id: {id}");
            bool result = await service.DeleteUserAsync(id, cancellationToken);
            return result ? Ok($"User With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting User" });
        }
    }
}
