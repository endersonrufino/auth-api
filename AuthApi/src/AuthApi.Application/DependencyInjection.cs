using AuthApi.Application.Interfaces.Security;
using Microsoft.Extensions.DependencyInjection;

namespace AuthApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {        
        // Use cases
        // services.AddScoped<ILoginUseCase, LoginUseCase>();
        // services.AddScoped<IRegisterUseCase, RegisterUseCase>();

        // Validators (FluentValidation, se usar)
        // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}

