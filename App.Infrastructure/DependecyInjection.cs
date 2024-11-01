



using App.Application.Interfaces.Caching;
using App.Application.Interfaces.Persistance;
using App.Application.Interfaces.Services;

using App.Infrastructure.Persistence;
using App.Infrastructure.Persistence.Caching;
using App.Infrastructure.Persistence.Repositories;
using App.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;


namespace App.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configuration)
    {         
        services.AddPersistance(configuration);
        services.AddSwaggerGen();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();     
        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services,
        Microsoft.Extensions.Configuration.ConfigurationManager configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            new MySqlServerVersion(new Version(9, 0, 1))));

        // Redis configuration
        var redisConnectionString = configuration["Redis:ConnectionString"];
        var options = ConfigurationOptions.Parse(redisConnectionString);       
        options.Password = ""; // For secured Redis
        options.DefaultDatabase = 1; // Choose the default database
        //options.Ssl = true; // Enable SSL if required
        options.ConnectRetry = 5; // Retry connection 5 times
        options.SyncTimeout = 5000; // Adjust the sync timeout        

        var redisConnection = ConnectionMultiplexer.Connect(options);
        // Register Redis as a singleton
        services.AddSingleton<IConnectionMultiplexer>(redisConnection);

        // Other service registrations...
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IRedisCacheService, RedisCacheService>();
        services.AddScoped<IIdentityServerRespository, IdentityServerRespository>();
        return services;
    }

    
}

