namespace DVLD.DTOs.Users;

public class UserInfoDto
{
    public int UserId { get; set; }
    public int PersonId { get; set; }
    public required string FullName { get; set; }
    public required string UserName { get; set; }
    public bool IsActive { get; set; }
}

