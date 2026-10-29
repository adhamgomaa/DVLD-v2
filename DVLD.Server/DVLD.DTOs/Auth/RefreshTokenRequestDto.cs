using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.Auth;

public class RefreshTokenRequestDto
{
    [Required]
    public required string RefreshToken { get; init; }
}
