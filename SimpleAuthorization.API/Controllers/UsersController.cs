using Microsoft.AspNetCore.Mvc;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.API.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost("create")]
    public async Task<UserDto> CreateNew([FromBody] CreateUserDto request)
    {
        return await _usersService.CreateNewAsync(request);
    }
}
