using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Routinner.Infrastructure.DataAccess;

namespace WebApi.Test;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test")
            .ConfigureServices(s =>
            {
                var descriptor = s.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<RoutinnerDbContext>));
                if (descriptor is not null)
                    s.Remove(descriptor);

                var provider = s.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                s.AddDbContext<RoutinnerDbContext>(opt =>
                {
                    opt.UseInMemoryDatabase("InMemoryDbForTest");
                    opt.UseInternalServiceProvider(provider);
                });
            });
    }
}
