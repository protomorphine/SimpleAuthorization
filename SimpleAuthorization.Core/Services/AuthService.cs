using Microsoft.Extensions.Caching.Memory;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.Core.Services;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _cache;

    public AuthService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<string> SignInAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }
}
