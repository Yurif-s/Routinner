using Microsoft.Extensions.Configuration;

namespace Routinner.Infrastructure.Extensions;

public static class ConfigurationExtensions
{
    public static string ConnectionString(this IConfiguration configuration) 
        => configuration.GetConnectionString("Connection")!;
    public static bool IsUnitTestEnviroment(this IConfiguration configuration) => configuration.GetValue<bool>("InMemoryTest");
}
