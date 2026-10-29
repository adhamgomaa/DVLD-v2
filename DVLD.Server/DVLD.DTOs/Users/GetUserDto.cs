namespace DVLD.DTOs.Users;

public sealed class GetUserDto
{
    public int UserId { get; init; } = -1;
    public int PersonId { get; init; } = -1;
    public string UserName { get; init; } = string.Empty;
    public bool IsActive { get; init; }
}
