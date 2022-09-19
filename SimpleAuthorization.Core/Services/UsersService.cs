using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Entities;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.Core.Services;

public class UsersService : IUsersService
{
    private readonly IUserRepository _usersRepository;
    public UsersService(IUserRepository userRepository)
    {
        _usersRepository = userRepository;
    }

    public async Task<UserDto> CreateNewAsync(CreateUserDto dto)
    {
        var entity = new User()
        {
            Fio = dto.Fio,
            Login = dto.Login,
            PasswordHash = dto.Password
        };

        await _usersRepository.CreateAsync(entity);

        return new() { 
            Login = entity.Login,
            Id = entity.Id,
            Fio = entity.Fio
        };
    }
}
