using Moq;
using Routinner.Domain.Repositories;

namespace CommonTestUtilities.Repositories;

public class UserReadOnlyRepositoryBuilder
{
    private readonly Mock<IUserReadOnlyRepository> _repository;
    public UserReadOnlyRepositoryBuilder() => _repository = new Mock<IUserReadOnlyRepository>();
    public void ExistActiveUserWithEmail(string email) => 
        _repository.Setup(repo => repo.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
    public IUserReadOnlyRepository Build() => _repository.Object;
}
