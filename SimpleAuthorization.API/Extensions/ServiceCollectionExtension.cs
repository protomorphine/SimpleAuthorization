using SimpleAuthorization.Core.Managers;
using SimpleAuthorization.Core.Managers.Interfaces;
using SimpleAuthorization.Core.Services;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthManager, AuthManager>();
        services.AddTransient<IUsersService, UsersService>();
    }
}
