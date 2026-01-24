using Routinner.Domain.Entities;
using Routinner.Domain.Repositories;

namespace Routinner.Infrastructure.DataAccess.Repositories;

internal class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    public Task Add(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistActiveUserWithEmail(string email)
    {
        throw new NotImplementedException();
    }
}
