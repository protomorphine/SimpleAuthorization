using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace SimpleAuthorization.API.Attributes
{
    public class AuthReqiredAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IMemoryCache _cache;

        public AuthReqiredAttribute(IMemoryCache cache) => _cache = cache;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_cache.Get(context.HttpContext.Request.Cookies["auth"]) == null)
                context.Result = new UnauthorizedResult();
            //throw new UnauthorizedAccessException("Unauthorized.");
        }
    }
}
