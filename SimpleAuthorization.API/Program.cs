using Serilog;

namespace SimpleAuthorization.API;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();

    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var pathToContentRoot = Directory.GetCurrentDirectory();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(pathToContentRoot)
            .AddJsonFile("appsettings.json")
            .Build();
        
        var logger = new LoggerConfiguration().ReadFrom
            .Configuration(configuration)
            .CreateLogger();
        
        var host = Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseContentRoot(pathToContentRoot);
            webBuilder.UseStartup<Startup>();
            webBuilder.UseConfiguration(configuration);
        }).UseSerilog(logger);

        return host;
    }
}