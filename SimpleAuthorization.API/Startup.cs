using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SimpleAuthorization.API.Models;
using Hellang.Middleware.ProblemDetails;
using SimpleAuthorization.API.Extensions;
using SimpleAuthorization.Infrastructure.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ProblemDetailsExtensions = SimpleAuthorization.API.Extensions.ProblemDetailsExtensions;

namespace SimpleAuthorization.API;

public class Startup
{
    /// <summary>
    /// Настройки приложения
    /// </summary>
    private readonly AppSettings _appSettings;

    /// <summary>
    /// Настройки подключения к базе данных
    /// </summary>
    private readonly DbOptions _dbOptions;

    /// <summary>
    /// Создает новый экземпляр <see cref="Startup"/>
    /// </summary>
    /// <param name="config"></param>
    /// <param name="env"></param>
    public Startup(IConfiguration config, IWebHostEnvironment env)
    {
        Configuration = config;
        WebHostEnvironment = env;

        _appSettings = config.GetSection("AppSettings").Get<AppSettings>();
        _dbOptions = _appSettings.DbOptions!;
    }

    /// <summary>
    /// Возвращает или задает конфигурацию
    /// </summary>
    public IConfiguration Configuration { get; set; }

    /// <summary>
    /// Возвращает или задает окружение
    /// </summary>
    public IWebHostEnvironment WebHostEnvironment { get; set; }


    /// <summary>
    /// Конфигцрация сервисов
    /// </summary>
    /// <param name="services">коллекция сервисов</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddScoped(_ => _appSettings)
            .AddScoped(_ => _dbOptions);

        services.AddControllers()
            .AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                opt.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
            });

        services.AddProblemDetails(ProblemDetailsExtensions.ConfigureProblemDetails);

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Authorization Service API",
                Version = "v1",
                Description = "Simple auth service"
            });

            var xmlFilesPaths = new[]
            {
                "SimpleAuthorization.API.xml",
                "SimpleAuthorization.Core.xml",
                "SimpleAuthorization.Infrastructure.xml",
            };

            foreach (var xmlFilePath in xmlFilesPaths)
            {
                var path = Path.Combine(AppContext.BaseDirectory, xmlFilePath);
                options.IncludeXmlComments(path);
            }
        });

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(_dbOptions.ConnectionString);
            options.UseSnakeCaseNamingConvention();
        });

        services.AddMemoryCache();

        services.RegisterServices();

        services.RegisterRepositories();
    }

    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    /// <param name="app">приложение</param>
    /// <param name="env">окружение</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseProblemDetails();

        app.UseRoleCheck();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}