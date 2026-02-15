using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Users;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Security.Cryptography;
using Routinner.Application.UseCases.User.Register;
using Routinner.Exception;
using Routinner.Exception.ExceptionsBase;
using Shouldly;

namespace UseCases.Test.User.Register;

public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase();

        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Name.ShouldBe(request.Name);
        result.Id.ShouldBeOfType<long>();
    } 
    [Fact]
    public async Task Error_Email_Already_Registered()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        var useCase = CreateUseCase(request.Email);

        Func<Task> act = async () => await useCase.Execute(request);

        var exception = await act.ShouldThrowAsync<ErrorOnValidationException>();

        exception.StatusCode.ShouldBe((int)System.Net.HttpStatusCode.BadRequest);
        exception.GetErrors().ShouldSatisfyAllConditions(exception =>
        {
            exception.Count.ShouldBe(1);
            exception.ShouldContain(ResourceMessagesException.EMAIL_ALREADY_REGISTERED);
        });
    }
    [Fact]
    public async Task Error_Invalid_Request()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
        var useCase = CreateUseCase();

        Func<Task> act = async () => await useCase.Execute(request);

        var exception = await act.ShouldThrowAsync<ErrorOnValidationException>();

        exception.StatusCode.ShouldBe((int)System.Net.HttpStatusCode.BadRequest);
        exception.GetErrors().ShouldSatisfyAllConditions(exception =>
        {
            exception.Count.ShouldBe(1);
            exception.ShouldContain(ResourceMessagesException.NAME_EMPTY);
        });
    }
    private RegisterUserUseCase CreateUseCase(string? email = null)
    {
        var passwordHasher = PasswordHasherBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
        var readRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

        if (string.IsNullOrEmpty(email) == false)
            readRepositoryBuilder.ExistActiveUserWithEmail(email);

        return new(readRepositoryBuilder.Build(), writeRepository, unitOfWork, passwordHasher);
    }
}
