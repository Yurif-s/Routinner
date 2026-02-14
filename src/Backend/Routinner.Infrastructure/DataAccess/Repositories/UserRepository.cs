using Microsoft.EntityFrameworkCore;
using Routinner.Domain.Entities;
using Routinner.Domain.Repositories.User;

namespace Routinner.Infrastructure.DataAccess.Repositories;

internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly RoutinnerDbContext _dbContext;
    public UserRepository(RoutinnerDbContext dbContext) => _dbContext = dbContext;
    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email) 
        => await _dbContext.Users.AsNoTracking().AnyAsync(user => user.Email.Equals(email) && user.Active);

    public Task<bool> ExistUserWithId(long id) =>_dbContext.Users.AsNoTracking().AnyAsync(user => user.Id == id);
}
