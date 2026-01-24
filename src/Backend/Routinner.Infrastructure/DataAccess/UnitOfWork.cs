using Routinner.Domain.Repositories;

namespace Routinner.Infrastructure.DataAccess;

internal class UnitOfWork : IUnitOfWork
{
    private readonly RoutinnerDbContext _dbContext;
    public UnitOfWork(RoutinnerDbContext dbContext) => _dbContext = dbContext;
    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
