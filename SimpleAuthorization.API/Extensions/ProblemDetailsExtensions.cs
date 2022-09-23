using Hellang.Middleware.ProblemDetails;
using SimpleAuthorization.API.Exceptions;
using SimpleAuthorization.Core.Exceptions;

namespace SimpleAuthorization.API.Extensions;

public static class ProblemDetailsExtensions
{
    public static void ConfigureProblemDetails(ProblemDetailsOptions options)
    {
        options.Map<UnauthorizedException>(ex => new ExtendedExceptionProblemDetails(ex, StatusCodes.Status401Unauthorized));
        options.Map<ObjectNotFoundException>(ex => new ExtendedExceptionProblemDetails(ex, StatusCodes.Status404NotFound));
        options.Map<UserAlreadyExistException>(ex => new ExtendedExceptionProblemDetails(ex, StatusCodes.Status400BadRequest));
    }
}