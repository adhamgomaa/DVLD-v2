using System;
using System.Globalization;
using DVLD.DTOs.Auth;
using DVLD.API.Interfaces;
using DVLD.Business.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DVLD.API.Configuration;
using DVLD.Shared.Entities;

namespace DVLD.API.Implementations;

public sealed class AuthService(
    JwtTokenSettings jwtSettings,
    IUserService userService,
    IRefreshTokenService refreshTokenService,
    ILoginAttemptService loginAttemptService) : IAuthService
{
    public async Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto loginRequest,
        string? clientIpAddress, 
        CancellationToken cancellationToken)
    {
        var user = await userService.FindUserAsync(loginRequest.UserName, cancellationToken);
        if (user is null)
        {
            await loginAttemptService.RecordAsync(
                null,
                loginRequest.UserName,
                false,
                clientIpAddress,
                cancellationToken);
            return null;
        }
        if (!user.IsActive || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, user.Password))
        {
            await loginAttemptService.RecordAsync(
                user.UserId,
                loginRequest.UserName,
                false,
                clientIpAddress,
                cancellationToken);
            return null;
        }

        await loginAttemptService.RecordAsync(
            user.UserId,
            loginRequest.UserName,
            true,
            clientIpAddress,
            cancellationToken);

        var refreshToken = await refreshTokenService.CreateAsync(
            user.UserId,
            Guid.NewGuid(),
            TimeSpan.FromDays(jwtSettings.RefreshTokenDays),
            cancellationToken);

        return CreateTokenResponse(user, refreshToken);
    }

    public async Task<LoginResponseDto?> RefreshAsync(string refreshToken, CancellationToken cancellationToken)
    {
        var result = await refreshTokenService.RotateAsync(
            refreshToken,
            TimeSpan.FromDays(jwtSettings.RefreshTokenDays),
            cancellationToken);

        if (!result.Succeeded)
        {
            return null;
        }

        return CreateTokenResponse(result.User!, result.NewRefreshToken!);
    }

    public Task LogoutAsync(string refreshToken, CancellationToken cancellationToken)
    {
        return refreshTokenService.LogoutAsync(refreshToken, cancellationToken);
    }

    public LoginResponseDto CreateTokenResponse(User user, string refreshToken)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString(CultureInfo.InvariantCulture)),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SigningKey));
        var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(jwtSettings.AccessTokenMinutes),
            signingCredentials: signingCredentials);

        var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
        return new LoginResponseDto(accessToken, refreshToken);
    }
}
