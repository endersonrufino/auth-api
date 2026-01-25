using AuthApi.Application.Interfaces.Security;
using AuthApi.Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AuthApi.Infrastructure;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }

