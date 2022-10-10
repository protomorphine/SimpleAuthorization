using FluentValidation;
using FluentValidation.AspNetCore;
using SimpleAuthorization.API.Validators;
using SimpleAuthorization.Core.Dtos;
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
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthManager, AuthManager>();
        services.AddTransient<IUsersService, UsersService>();
        services.AddTransient<IOrganizationService, OrganizationService>();
    }

    /// <summary>
    /// Метод регистрации репозиториев
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IOrganizationRepository, OrganizationRepository>();
    }
    
    /// <summary>
    /// Метод регистрации валидаторов
    /// </summary>
    /// <param name="services"><see cref="IServiceCollection"/></param>
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        
        services.AddScoped<IValidator<CreateOrganizationDto>, CreateOrganizationValidator>();
        services.AddScoped<IValidator<CreateAndUpdateUserDto>, CreateUserValidator>();
    }
}
