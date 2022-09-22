using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using SimpleAuthorization.Core.Managers.Interfaces;
using SimpleAuthorization.Core.Services.Interfaces;

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

            if (token == String.Empty)
            {
                context.Result = new UnauthorizedResult();
            }
            
            var currentUserId = service.GetCurrentUserInfoAsync(token).Result;

            if (currentUserId == null)
            {
                context.Result = new UnauthorizedResult(); 
            }

            return;
        }
    }
}
