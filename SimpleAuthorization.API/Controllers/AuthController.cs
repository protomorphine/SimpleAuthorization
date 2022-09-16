using Microsoft.AspNetCore.Mvc;
using SimpleAuthorization.API.Models;

namespace SimpleAuthorization.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public AuthController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpGet("get")]
        public Task<string> GetTest()
        {
            return Task.Run(() => _appSettings.DbOptions.ConnectionString);
        }
    }
}
