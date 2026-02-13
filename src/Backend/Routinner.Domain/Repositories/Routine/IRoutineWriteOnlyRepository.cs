namespace Routinner.Domain.Repositories.Routine;

public interface IRoutineWriteOnlyRepository
{
    Task Add(Domain.Entities.Routine routine);
}
