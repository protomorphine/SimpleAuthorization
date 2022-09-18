using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Services.Interfaces;

public interface IUsersService
{
    Task<UserDto> CreateNewAsync(CreateUserDto dto);


}
