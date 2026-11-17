using DVLD.DTOs.Users;
using DVLD.Shared.Models;

namespace DVLD.API.Mappers
{
    public class UserMapper
    {
        public static UserInfoDto ToUserDto(UserInfo user)
        {
            return new UserInfoDto
            {
                UserId = user.UserId,
                PersonId = user.PersonId,
                FullName = user.FullName,
                IsActive = user.IsActive,
                UserName = user.UserName
            };
        }

        public static GetUserDto ToGetDto(User user)
        {
            return new GetUserDto
            {
                UserId = user.UserId,
                PersonId = user.PersonId,
                UserName = user.Username,
                IsActive = user.IsActive
            };
        }

        public static User ToUser(CreateUserDto createUser)
        {
            return new User
            {
                Username = createUser.UserName,
                IsActive = createUser.IsActive,
                Password = createUser.Password,
                PersonId = createUser.PersonId
            };
        }
    }
}
