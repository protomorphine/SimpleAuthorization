using Microsoft.OpenApi.Models;
using SimpleAuthorization.API.Extensions;
using SimpleAuthorization.API.Models;

namespace SimpleAuthorization.API
{
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
        /// Настройки свагера
        /// </summary>
        //private readonly SwaggerOprions _swaggerOptions;

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
            _dbOptions = _appSettings.DbOptions;
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

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Authorization Service API",
                    Version = "v1",
                    Description = "Simple auth service"
                });
            });

            services.AddMemoryCache();

            services.RegisterServices();
        }

        /// <summary>
        /// Конфигурация приложения
        /// </summary>
        /// <param name="app">приложение</param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

; app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
