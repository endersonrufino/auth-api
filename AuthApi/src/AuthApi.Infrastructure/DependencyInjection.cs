using AuthApi.Application.Interfaces;
using AuthApi.Application.Interfaces.Security;
using AuthApi.Infrastructure.Persistence;
using AuthApi.Infrastructure.Persistence.Configurations;
using AuthApi.Infrastructure.Persistence.Repositories;
using AuthApi.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITokenService, TokenService>();

        var connectionString = configuration.GetConnectionString("AuthDb");

        services.AddDbContext<AuthDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IProfileRepository, ProfileRepository>();

        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}

