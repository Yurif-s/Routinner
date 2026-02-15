using Moq;
using Routinner.Domain.Repositories.User;

namespace CommonTestUtilities.Repositories.Users;

public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository;
    public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();
    public void ExistActiveUserWithEmail(string email) => 
        _repository.Setup(repo => repo.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
    public void ExistUserWithId(long id) =>
        _repository.Setup(repo => repo.ExistUserWithId(id)).ReturnsAsync(true);
    public IUserReadOnlyRepository Build() => _repository.Object;
}
