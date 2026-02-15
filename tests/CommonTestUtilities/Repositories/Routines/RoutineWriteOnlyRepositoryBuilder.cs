using Moq;
using Routinner.Domain.Repositories.Routine;

namespace CommonTestUtilities.Repositories.Routines;

public static class RoutineWriteOnlyRepositoryBuilder
{
    public static IRoutineWriteOnlyRepository Build()
    {
        var mock = new Mock<IRoutineWriteOnlyRepository>();
        return mock.Object;
    }
}
