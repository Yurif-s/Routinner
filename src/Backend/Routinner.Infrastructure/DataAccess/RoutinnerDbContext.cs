using Microsoft.EntityFrameworkCore;
using Routinner.Domain.Entities;

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
