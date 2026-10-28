using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DVLD.DTOs.Auth;
using DVLD.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using DVLD.API.Configuration;
namespace DVLD.API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public sealed class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login", Name = "Login")]
        [AllowAnonymous]
        [EnableRateLimiting(RateLimitPolicies.Login)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequest, CancellationToken cancellationToken)
        {
            var clientIpAddress = HttpContext.Connection.RemoteIpAddress?.MapToIPv6().ToString();
            var token = await authService.LoginAsync(loginRequest, clientIpAddress, cancellationToken);
            if(token is null)
                return Unauthorized("Invalid Credentials");

            return Ok(token);
        }

        [HttpPost("refresh", Name = "Refresh")]
        [AllowAnonymous]
        [EnableRateLimiting(RateLimitPolicies.Refresh)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<LoginResponseDto>> Refresh(
            RefreshTokenRequestDto request,
            CancellationToken cancellationToken)
        {
            var tokens = await authService.RefreshAsync(request.RefreshToken, cancellationToken);
            if (tokens is null)
                return Unauthorized("Invalid or expired refresh token");

            return Ok(tokens);
        }

        [HttpPost("logout", Name = "Logout")]
        [AllowAnonymous]
        [EnableRateLimiting(RateLimitPolicies.Logout)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status429TooManyRequests)]
        public async Task<IActionResult> Logout(
            RefreshTokenRequestDto request,
            CancellationToken cancellationToken)
        {
            await authService.LogoutAsync(request.RefreshToken, cancellationToken);
            return NoContent();
        }
    }
}
