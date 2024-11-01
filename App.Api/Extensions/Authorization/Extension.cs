using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

using System.Security.Claims;

namespace App.Api.Extensions.Authorization
{
    public static class Extensions
    {
        public static void UseMyAuthorization(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();            
        }
        public static void UseAuthorizationOnly(this IApplicationBuilder app)
        {
            app.UseAuthorization();
        }
        public static IServiceCollection AddAteduAuthentication(this IServiceCollection services, AuthorizationOptions authorizationOptions)
        {
            bool isProduction = false;
      
            services.TryAddSingleton<AuthorizationOptions>(authorizationOptions);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.Authority = authorizationOptions.Endpoint;
                o.BackchannelHttpHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                };
                o.Audience = authorizationOptions.ClientId;
                o.SaveToken = true;
                o.RequireHttpsMetadata = false;
                o.IncludeErrorDetails = !isProduction;
                o.RefreshOnIssuerKeyNotFound = false;

                o.TokenValidationParameters = (authorizationOptions.TokenValidationParameters != null) ? authorizationOptions.TokenValidationParameters : new TokenValidationParameters
                {
                    RequireSignedTokens = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuer = true,
                    ValidIssuer = authorizationOptions.Endpoint,
                    ValidateIssuerSigningKey = true,                    
                    RoleClaimType = ClaimTypes.Role,
                };
            });
            return services;
        }
    }
}
