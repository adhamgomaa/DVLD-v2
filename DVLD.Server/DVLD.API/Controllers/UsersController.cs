using DVLD.API.Mappers;
using DVLD.Business;
using DVLD.DTOs.Users;
using DVLD.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DVLD.API.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet(Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UserInfoDto>>> GetAllUsers()
        {
            List<UserInfo> users = await UserService.GetUsersAsync();
            var userDto = users.Select(UserMapper.ToUserDto).ToList();
            return Ok(userDto);
        }

        [HttpGet("info/{id}", Name = "GetUserInfoById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDto>> GetUserInfoById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = await UserService.FindUserAsync(id);

            if (user == null) return NotFound($"There's no user with this Id: {id}");

            return Ok(UserMapper.ToGetDto(user));
        }
        
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoginUserDto>> GetUserById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = await UserService.FindUserAsync(id);

            if (user == null) return NotFound($"There's no user with this Id: {id}");

            LoginUserDto currentDTO = new()
            {
                UserId = id,
                PersonId = user.PersonId,
                UserName = user.UserName,
                Password = user.Password,
                IsActive = user.IsActive
            };
            return Ok(currentDTO);
        }

        [HttpGet("by-username/{username}", Name = "GetUserByUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserDto>> GetUserByUsername(string username)
        {

            User? user = await UserService.FindUserAsync(username);

            if (user == null) return NotFound($"There's no user with this username: {username}");

            return Ok(UserMapper.ToGetDto(user));
        }

        [HttpPost("login", Name = "LoginUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<LoginUserDto>> LoginUser(LoginRequestDto loginRequest)
        {
            User? current = await UserService.FindUserAsync(loginRequest.UserName, loginRequest.Password);
            if (current == null) return Unauthorized("Invalid username or password");

            LoginUserDto currentDTO = new()
            {
                UserId = current.UserId,
                PersonId = current.PersonId,
                UserName = loginRequest.UserName,
                Password = loginRequest.Password,
                IsActive = current.IsActive
            };
            return Ok(currentDTO);
        }

        [HttpGet("{id}/exists", Name = "IsUserExistById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsUserExistById(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool IsExist = await UserService.IsUserExistAsync(id);
            return Ok(IsExist);
        }
        [HttpGet("{username}/by-username/exists", Name = "IsUserExistByUsername")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> IsUserExistByUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return BadRequest("Invalid data");
            bool IsExist = await UserService.IsUserExistAsync(username);
            return Ok(IsExist);
        }

        [HttpGet("{personId}/by-person-id/exists", Name = "IsUserExistByPersonId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> IsUserExistByPersonId(int personId)
        {
            if (personId < 1)
                return BadRequest("Invalid data");
            bool IsExist = await UserService.IsUserExistByPersonIdAsync(personId);
            return Ok(IsExist);
        }

        [HttpPost(Name = "AddNewUser")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetUserDto>> AddNewUser(CreateUserDto createUser)
        {
            User newUser = UserMapper.ToUser(createUser);

            bool result = await UserService.AddNewUserAsync(newUser);
            if (!result)
                return StatusCode(500, new { message = "Error Adding User" });

            return CreatedAtRoute("GetUserByID", new { id = newUser.UserId }, UserMapper.ToGetDto(newUser));
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateUserDto>> UpdateUser(int id, UpdateUserDto updateUser)
        {
            if (id < 1)
                return BadRequest("Invalid data");

            User? user = await UserService.FindUserAsync(id);
            if (user == null) return NotFound($"There's no user with this Id: {id}");

            user.PersonId = updateUser.PersonId;
            user.UserName = updateUser.UserName;
            user.Password = updateUser.Password;
            user.IsActive = updateUser.IsActive;

            bool result = await UserService.UpdateUserAsync(user);
            if (result) return Ok(updateUser);
            else return StatusCode(500, new { message = "Error Updating User" });
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (id < 1)
                return BadRequest("Invalid data");
            bool exists = await UserService.IsUserExistAsync(id);
            if (!exists) return NotFound($"There's no user with this Id: {id}");
            bool result = await UserService.DeleteUserAsync(id);
            return result ? Ok($"User With ID {id} has been deleted") : StatusCode(500, new { message = "Error Deleting User" });
        }
    }
}
