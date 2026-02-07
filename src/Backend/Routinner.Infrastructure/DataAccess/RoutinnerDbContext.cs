using Microsoft.EntityFrameworkCore;
using Routinner.Domain.Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("WebApi.Test")]
namespace Routinner.Infrastructure.DataAccess;

internal class RoutinnerDbContext : DbContext
{
    public RoutinnerDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) 
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoutinnerDbContext).Assembly);
}
