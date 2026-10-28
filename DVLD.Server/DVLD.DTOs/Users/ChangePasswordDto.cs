using System.ComponentModel.DataAnnotations;

namespace DVLD.DTOs.Users;

public sealed class ChangePasswordDto
{
    [Required, MaxLength(128)]
    public string CurrentPassword { get; init; } = string.Empty;

    [Required, MinLength(8), MaxLength(128)]
    public string NewPassword { get; init; } = string.Empty;
}
