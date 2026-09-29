using DVLD.DTOs.Users;
using DVLD.Shared.Entities;

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
                UserName = user.UserName,
                IsActive = user.IsActive
            };
        }

        public static User ToUser(CreateUserDto createUser)
        {
            return new User
            {
                UserName = createUser.UserName,
                IsActive = createUser.IsActive,
                Password = createUser.Password,
                PersonId = createUser.PersonId
            };
        }
    }
}
