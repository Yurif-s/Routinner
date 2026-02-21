using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Routines;
using CommonTestUtilities.Repositories.Users;
using CommonTestUtilities.Requests;
using Routinner.Application.UseCases.Routine.Register;
using Routinner.Exception;
using Routinner.Exception.ExceptionsBase;
using Shouldly;

namespace UseCases.Test.Routine.Register;

public class RegisterRoutineUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();
        var useCase = CreateUseCase(request.UserId);

        var response = await useCase.Execute(request);

        response.ShouldNotBeNull();
        response.Name.ShouldBe(request.Name);
    }
    [Fact]
    public async Task Invalid_Request()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();
        var useCase = CreateUseCase(request.UserId);
        request.Name = string.Empty;

        Func<Task> act = async () => await useCase.Execute(request);

        var exception = await act.ShouldThrowAsync<ErrorOnValidationException>();
        exception.StatusCode.ShouldBe((int)System.Net.HttpStatusCode.BadRequest);
        exception.GetErrors().ShouldSatisfyAllConditions(exception =>
        {
            exception.Count.ShouldBe(1);
            exception.ShouldContain(ResourceMessagesException.NAME_EMPTY);
        });
    }
    [Fact]
    public async Task Error_Not_Exist_User_With_Id()
    {
        var request = RequestRegisterRoutineJsonBuilder.Build();
        var useCase = CreateUseCase(0);

        Func<Task> act = async () => await useCase.Execute(request);

        var exception = await act.ShouldThrowAsync<NotFoundException>();
        exception.StatusCode.ShouldBe((int)System.Net.HttpStatusCode.NotFound);
        exception.GetErrors().ShouldSatisfyAllConditions(exception =>
        {
            exception.Count.ShouldBe(1);
            exception.ShouldContain(ResourceMessagesException.USER_NOT_FOUND);
        });
    }
    private RegisterRoutineUseCase CreateUseCase(long id = 0)
    {
        var routineRepository = RoutineWriteOnlyRepositoryBuilder.Build();
        var userRepository = new UserReadOnlyRepositoryBuilder();
        var unitOfWork = UnitOfWorkBuilder.Build();

        if (id != 0)
            userRepository.ExistUserWithId(id);

        return new(routineRepository, userRepository.Build(), unitOfWork);
    }
}
