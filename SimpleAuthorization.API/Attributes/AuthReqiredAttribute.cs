using Microsoft.AspNetCore.Mvc.Filters;
using SimpleAuthorization.Core.Exceptions;
using SimpleAuthorization.Core.Managers.Interfaces;

namespace SimpleAuthorization.API.Attributes
{
    public class AuthReqiredAttribute : Attribute, IAuthorizationFilter
    {
        public AuthReqiredAttribute()
        {
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var service = context.HttpContext.RequestServices.GetService<IAuthManager>();

            var token = context.HttpContext.Request.Cookies["auth"];

            if (token == null)
                throw new UnauthorizedAccessException("Unauthorized");

            try
            {
                var userId = service.GetUserByTokenAsync(token).Result.Id;

            }
            catch
            {
                return;
            }


            /*
            try
            {
                var _ = service!.GetUserByTokenAsync(token).Result;
            }
            catch (AggregateException ex) when (ex.InnerException?.GetType() == typeof(UnauthorizedAccessException))
            {
                throw new UnauthorizedAccessException("Unauthorized.");
            }*/
        }
    }
}
