using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Server.Configuration;

public static class JwtConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme )
            .AddJwtBearer(Options =>
            {
                Options.TokenValidationParameters = new()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidIssuer = "para-lanches",
                    ValidateIssuerSigningKey = false,
                    ValidateLifetime = true,
                    IssuerSigningKey = configuration.GetJwtSecurityKey()
                };
            });
        
        services.AddAuthorization();
        return services;
    }
}