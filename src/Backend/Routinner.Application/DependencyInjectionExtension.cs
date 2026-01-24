using Microsoft.Extensions.DependencyInjection;
using Routinner.Application.Services.Mappings;
using Routinner.Application.UseCases.User.Register;

namespace Routinner.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddMapperConfigurations();
        AddUseCases(services);

    }
    private static void AddMapperConfigurations()
    {
        MapConfigurations.Configure();
    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }
}
