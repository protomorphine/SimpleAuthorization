namespace SimpleAuthorization.Core.Services.Interfaces;

public interface IAuthService
{
    Task<string> SignInAsync(string username, string password);

    Task SignOutAsync();
}
