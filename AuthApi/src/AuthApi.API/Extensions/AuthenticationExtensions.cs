using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AuthApi.API.Extensions;

public static class AuthenticationExtensions
{
    public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtKey = configuration["Jwt:Key"];

        if (string.IsNullOrWhiteSpace(jwtKey))
            throw new InvalidOperationException(
                "A configuração Jwt:Key não foi encontrada.");

        services
           .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(jwtKey)),

                   ValidateIssuer = true,
                   ValidIssuer = configuration["Jwt:Issuer"],

                   ValidateAudience = true,
                   ValidAudience = configuration["Jwt:Audience"],

                   ValidateLifetime = true,

                   ClockSkew = TimeSpan.Zero
               };
           });

        services.AddAuthorization();

        return services;
    }
}
