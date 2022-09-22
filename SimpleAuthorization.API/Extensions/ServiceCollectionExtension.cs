using SimpleAuthorization.Core.Managers;
using SimpleAuthorization.Core.Services;
using SimpleAuthorization.Core.Repositories;
using SimpleAuthorization.Core.Managers.Interfaces;
using SimpleAuthorization.Core.Services.Interfaces;
using SimpleAuthorization.Infrastructure.Repositories;

namespace SimpleAuthorization.API.Extensions;

/// <summary>
/// Методы расширения <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionExtension
{
    /// <summary>
    /// Метод регистрации сервисов
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthManager, AuthManager>();
        services.AddTransient<IUsersService, UsersService>();
    }

    /// <summary>
    /// Метод регистрации репозиториев
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
    }
}
