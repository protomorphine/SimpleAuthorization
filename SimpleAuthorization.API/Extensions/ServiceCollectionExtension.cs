using SimpleAuthorization.Core.Services;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<IUsersService, UsersService>();
    }
}
