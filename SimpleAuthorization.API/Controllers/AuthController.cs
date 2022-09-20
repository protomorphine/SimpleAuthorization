using Microsoft.AspNetCore.CookiePolicy;
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
        public async Task<string> SignInAsync([FromBody] SignInDto dto)
        {
            var token = await _authManager.SignInAsync(dto.Login!, dto.Password!);
            Response.Cookies.Append("auth", token, new CookieOptions() { HttpOnly = true});
            return token;
        }

        [HttpPost("sing-out")]
        public async void SignOutAsync()
        {
            var token = Request.Cookies.FirstOrDefault(c => c.Key == "auth").Value;
            await _authManager.SignOutAsync(token);
            //Response.Cookies.Delete("auth");

        }

        [HttpGet("info")]
        public async Task<UserDto> GetCurrentUserInfo()
        {
            var token = Request.Cookies["auth"];
            return await _authManager.GetCurrentUserInfoAsync(token);
        }
    }
}
