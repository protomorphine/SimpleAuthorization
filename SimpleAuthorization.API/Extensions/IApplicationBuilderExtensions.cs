using SimpleAuthorization.API.Middlewares;

namespace SimpleAuthorization.API.Extensions;

/// <summary>
/// Метод расширенимя для использования <see cref="IApplicationBuilder"/>
/// </summary>
public static class IApplicationBuilderExtensions
{
    /// <summary>
    /// Использование <see cref="RoleCheckMiddleware"/>
    /// </summary>
    public static IApplicationBuilder UseRoleCheck(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RoleCheckMiddleware>();
    }
}