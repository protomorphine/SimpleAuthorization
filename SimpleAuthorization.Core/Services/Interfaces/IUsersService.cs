using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;

namespace SimpleAuthorization.Core.Services.Interfaces;

public interface IUsersService
{
    Task<User> CreateNewAsync(CreateUserDto dto);


}
