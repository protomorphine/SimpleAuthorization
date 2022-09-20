using Microsoft.AspNetCore.Mvc;
using SimpleAuthorization.API.Models;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Managers.Interfaces;

namespace SimpleAuthorization.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        private readonly IAuthManager _authManager;

        public AuthController(AppSettings appSettings, IAuthManager authManager)
        {
            _appSettings = appSettings;
            _authManager = authManager;
        }

        [HttpPost("sign-in")]
        public Task<string> SignInAsync([FromBody] SignInDto dto)
        {
            return _authManager.SignInAsync(dto.Login!, dto.Password!);
        }

        [HttpPost("sing-out")]
        public Task SignOutAsync()
        {
            return _authManager.SignOutAsync();
        }

        [HttpGet("info")]
        public async Task<UserDto> GetCurrentUserInfo(string token)
        {
            return await _authManager.GetCurrentUserInfoAsync(token);
        }
    }
}
