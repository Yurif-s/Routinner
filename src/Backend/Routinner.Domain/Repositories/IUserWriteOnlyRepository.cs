using Routinner.Domain.Entities;

namespace Routinner.Domain.Repositories;

public interface IUserWriteOnlyRepository
{
    Task Add(User user);
}
