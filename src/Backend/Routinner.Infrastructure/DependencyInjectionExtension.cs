using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Routinner.Infrastructure.Extensions;
using System.Reflection;

namespace Routinner.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddFluentMigrator(services, configuration);
    }
    private static void AddFluentMigrator(IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore().ConfigureRunner(opt =>
        {
            opt.AddSqlServer()
            .WithGlobalConnectionString(configuration.ConnectionString())
            .ScanIn(Assembly.Load("Routinner.Infrastructure")).For.All();
        });
    }
}
