using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace SimpleAuthorization.API.Attributes;

/// <summary>
/// Аттрибут для проверки токена авторизации пользователя
/// </summary>
public class AuthReqiredAttribute : Attribute, IAuthorizationFilter
{
    public AuthReqiredAttribute()
    {
    }
    public void OnAuthorization(AuthorizationFilterContext context)
    {  
        var cache = context.HttpContext.RequestServices.GetService<IMemoryCache>();

        var token = context.HttpContext.Request.Cookies["auth"];

        if (token == null)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        cache!.TryGetValue(token!, out long userId);

        if (userId == 0)
            context.Result = new UnauthorizedResult();

    }
}