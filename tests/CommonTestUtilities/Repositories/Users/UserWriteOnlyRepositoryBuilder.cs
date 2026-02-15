using Moq;
using Routinner.Domain.Repositories.User;

namespace CommonTestUtilities.Repositories.Users;

public class UserWriteOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();
        return mock.Object;
    }
}
