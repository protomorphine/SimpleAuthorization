using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Caching.Memory;
using SimpleAuthorization.API.Models;
using SimpleAuthorization.Core.Enums;
using SimpleAuthorization.Core.Services.Interfaces;

namespace SimpleAuthorization.API.Middlewares;

/// <summary>
/// Мидлвара для проверки роли пользователя
/// </summary>
public class RoleCheckMiddleware
{
    /// <summary>
    /// Делегат следующей мидлвары в цепочке
    /// </summary>
    private readonly RequestDelegate _next;

    /// <summary>
    /// Создает новый экземпляр <see cref="RoleCheckMiddleware"/>
    /// </summary>
    /// <param name="next">делегат следующей мидлвары в цепочке</param>
    public RoleCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Основной метод мидлвары
    /// </summary>
    /// <param name="context">контекст запроса</param>
    /// <exception cref="InvalidOperationException">недоступная операция</exception>
    public async Task InvokeAsync(HttpContext context)
    {
        var cache = context.RequestServices.GetService<IMemoryCache>();
        var userService = context.RequestServices.GetService<IUsersService>();

        if (context.Request.Path == "/api/auth/sign-in")
        {
            await _next.Invoke(context);
            return;
        }

        var token = context.Request.Cookies["auth"];

        cache!.TryGetValue(token!, out long userId);

        var role = await userService!.GetUserRole(userId);

        if (role is UserRoles.Administartor)
            await _next.Invoke(context);

        var currentEndpoint = new EndpointModel()
        {
            Controller = context.GetEndpoint()!.Metadata.OfType<ControllerActionDescriptor>().First().ControllerName,
            Action = context.GetEndpoint()!.Metadata.OfType<ControllerActionDescriptor>().First().ActionName,
            Method = context.Request.Method
        };

        var approvedEndpoints = GetAllEndpoins()
            .Where(it => it.Method == "GET" || it.Controller == "AuthController").ToList();

        var contains = approvedEndpoints
            .FirstOrDefault(it => it.Action == currentEndpoint.Action &&
                                  it.Controller == currentEndpoint.Controller &&
                                  it.Method == currentEndpoint.Method) != null;

        if (!contains)
            throw new InvalidOperationException("Необходима роль администратора.");

        await _next.Invoke(context);
    }

    /// <summary>
    /// Получает все эндпоинты проекта
    /// </summary>
    /// <returns>список всех эндпоинтов <see cref="EndpointModel"/></returns>
    private List<EndpointModel> GetAllEndpoins()
    {
        Assembly asm = Assembly.GetExecutingAssembly();

        return asm.GetTypes()
            .Where(type=> typeof(ControllerBase).IsAssignableFrom(type))
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            .Select(x => new EndpointModel()
            {
                Controller = x.DeclaringType.Name.Replace("Controller", ""),
                Action = x.Name,
                Method = x.GetCustomAttributes().First(it => it.GetType().Name.StartsWith("Http"))
                    .ToString()
                    ?.ToUpper()
                    .Replace("MICROSOFT.ASPNETCORE.MVC.HTTP", "")
                    .Replace("ATTRIBUTE", "")
            })
            .ToList();
    }
}