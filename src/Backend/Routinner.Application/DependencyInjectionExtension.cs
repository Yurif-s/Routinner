using Routinner.Application.Services.Mappings;

namespace Routinner.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication()
    {
        AddMapperConfigurations();
    }
    private static void AddMapperConfigurations()
    {
        MapConfigurations.Configure();
    }
}
