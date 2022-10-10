using Hellang.Middleware.ProblemDetails;
using SimpleAuthorization.API.Exceptions;
using SimpleAuthorization.Core.Exceptions;

namespace SimpleAuthorization.API.Extensions;

/// <summary>
/// Расширения для конфигурации <see cref="ProblemDetailsMiddleware"/>
/// </summary>
public static class ProblemDetailsExtensions
{
    /// <summary>
    /// Мапинг эксепшенов в коде на стандартизированну ошибку
    /// </summary>
    /// <param name="options"></param>
    public static void ConfigureProblemDetails(ProblemDetailsOptions options)
    {
        options.Map<UnauthorizedException>(ex =>
            new ExtendedExceptionProblemDetails(ex, StatusCodes.Status401Unauthorized));

        options.Map<ObjectNotFoundException>(ex =>
            new ExtendedExceptionProblemDetails(ex, StatusCodes.Status404NotFound));

        options.Map<UserAlreadyExistException>(ex =>
            new ExtendedExceptionProblemDetails(ex, StatusCodes.Status400BadRequest));

        options.Map<InvalidOperationException>(ex =>
            new ExtendedExceptionProblemDetails(ex, StatusCodes.Status403Forbidden));
    }
}