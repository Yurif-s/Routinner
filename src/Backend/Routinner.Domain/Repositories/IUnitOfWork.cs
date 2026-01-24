namespace Routinner.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
