using System;
using DVLD.DTOs.Auth;

namespace DVLD.API.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(
        LoginRequestDto loginRequest,
        string? clientIpAddress,
        CancellationToken cancellationToken);
    Task<LoginResponseDto?> RefreshAsync(
        string refreshToken,
        CancellationToken cancellationToken);

    Task LogoutAsync(string refreshToken, CancellationToken cancellationToken);
}
