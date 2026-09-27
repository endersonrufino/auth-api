using AuthApi.API.Extensions;
using AuthApi.Application;
using AuthApi.Infrastructure;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
               
        builder.Services
            .AddInfrastructure(builder.Configuration)
            .AddAuthenticationConfiguration(builder.Configuration)
            .AddApplication();

        builder.Services.AddControllers();        

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}