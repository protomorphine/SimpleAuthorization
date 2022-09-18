using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.Core.Services;

public class UsersService : IUsersService
{
    public UsersService()
    {

    }

    public Task<UserDto> CreateNewAsync(CreateUserDto dto)
    {
        throw new NotImplementedException();
    }
}
