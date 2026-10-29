using System;

namespace DVLD.DTOs.Auth;

public sealed record LoginResponseDto(string AccessToken, string RefreshToken);