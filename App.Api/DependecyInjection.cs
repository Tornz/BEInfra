


using App.Api.Extensions.Authorization;
using App.Api.Mapping;
using App.Contracts.Keycloak;

namespace App.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, 
       ConfigurationManager configuration)
    {
        var keyCloakEndPoint = configuration["KeyCloakSettings:KeycloakEndPoint"];

        services.AddAteduAuthentication(new AuthorizationOptions()
        {
            AutomaticReconnect = new[] { TimeSpan.Zero, TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30) },
            MaximumRetries = 0,
            FrequencyCheck = 1000,
            //Endpoint = "http://localhost:8090/realms/DTIACCOUNT",
            Endpoint = keyCloakEndPoint,
            ClientId = "netcredential",
        });
        services.Configure<KeyCloakSettings>(configuration.GetSection("KeyCloakSettings"));
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMapping();
        return services;
    }
}

