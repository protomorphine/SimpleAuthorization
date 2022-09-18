using Microsoft.Extensions.Caching.Memory;
using SimpleAuthorization.Core.Dtos;
using SimpleAuthorization.Core.Managers.Interfaces;

namespace SimpleAuthorization.Core.Managers;

public class AuthManager : IAuthManager
{
    private readonly IMemoryCache _cache;

    public AuthManager(IMemoryCache cache)
    {
        _cache = cache;
    }

    public Task<UserDto> GetCurrentUserInfoAsync()
    {
        throw new NotImplementedException();
    }

    public Task<string> SignInAsync(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task SignOutAsync()
    {
        throw new NotImplementedException();
    }

    Task IAuthManager.SignInAsync(string username, string password)
    {
        throw new NotImplementedException();
    }
}
