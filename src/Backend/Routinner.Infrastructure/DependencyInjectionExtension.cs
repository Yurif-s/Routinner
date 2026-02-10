using FluentMigrator.Runner;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Routinner.Domain.Repositories;
using Routinner.Domain.Security.Cryptography;
using Routinner.Infrastructure.DataAccess;
using Routinner.Infrastructure.DataAccess.Repositories;
using Routinner.Infrastructure.Extensions;
using Routinner.Infrastructure.Security.Cryptography;
using System.Reflection;

namespace Routinner.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddPasswordHasher(services);
        if (configuration.IsUnitTestEnviroment())
            return;
        AddFluentMigrator(services, configuration);
        AddDbContext(services, configuration);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.ConnectionString();

        services.AddDbContext<RoutinnerDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }
    private static void AddPasswordHasher(IServiceCollection services)
    {
        services.AddScoped<IPasswordHasher, PasswordHasher>();
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
