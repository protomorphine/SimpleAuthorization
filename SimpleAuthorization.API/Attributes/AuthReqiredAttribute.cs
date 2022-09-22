using Microsoft.AspNetCore.Mvc.Filters;
using SimpleAuthorization.Core.Exceptions;
using SimpleAuthorization.Core.Managers.Interfaces;

namespace SimpleAuthorization.API.Attributes
{
    public class AuthReqiredAttribute : Attribute, IAuthorizationFilter
    {
        public AuthReqiredAttribute()
        {
            Console.WriteLine("attr created");
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var service = context.HttpContext.RequestServices.GetService<IAuthManager>();

            var token = context.HttpContext.Request.Cookies["auth"];

            if (token == null)
                throw new UnauthorizedAccessException("Unauthorized");

            try
            {
                var user = service.GetCurrentUserInfoAsync(token).Result;
            }
            catch (AggregateException ex) when (ex.InnerException.GetType() == typeof(ObjectNotFoundException))
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }
        }
    }
}
