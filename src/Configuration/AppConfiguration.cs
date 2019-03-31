using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public static class AppConfiguration
{
    public static IConfigurationRoot Configuration;

    public static void Configure()
    {
        string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        string launch = Environment.GetEnvironmentVariable("LAUNCH_PROFILE");
 
        if (string.IsNullOrWhiteSpace(env))
        {
            env = "Development";
        }
 
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{env}.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();
 
        Configuration = builder.Build();
 
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
 
        var serviceProvider = serviceCollection.BuildServiceProvider();

        serviceProvider.GetService<App>().Run();
    }
    private static void ConfigureServices(IServiceCollection services)
    {
        // configure logging
        services.AddLogging(builder =>
            builder
            .AddDebug()
            .AddConsole()
        );

        // build config
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .Build();

        services.AddOptions();
        services.AddSingleton<IConfiguration>(configuration);

        services.AddDbContext<EmployeeContext>();
        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddTransient<ICsvParser, CsvParser>();

        // add app
        services.AddTransient<App>();
    }

}