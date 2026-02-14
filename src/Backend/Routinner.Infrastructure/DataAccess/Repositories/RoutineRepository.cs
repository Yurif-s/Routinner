using Routinner.Domain.Entities;
using Routinner.Domain.Repositories.Routine;

namespace Routinner.Infrastructure.DataAccess.Repositories;

internal class RoutineRepository : IRoutineWriteOnlyRepository
{
    private readonly RoutinnerDbContext _dbContext;
    public RoutineRepository(RoutinnerDbContext dbContext) => _dbContext = dbContext;
    public async Task Add(Routine routine) => await _dbContext.Routines.AddAsync(routine);
}
