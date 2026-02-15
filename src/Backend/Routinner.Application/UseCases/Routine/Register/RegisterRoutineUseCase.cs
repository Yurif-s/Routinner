using FluentValidation.Results;
using Mapster;
using Routinner.Communication.Requests;
using Routinner.Communication.Responses;
using Routinner.Domain.Repositories;
using Routinner.Domain.Repositories.Routine;
using Routinner.Domain.Repositories.User;
using Routinner.Exception;
using Routinner.Exception.ExceptionsBase;

namespace Routinner.Application.UseCases.Routine.Register;

public class RegisterRoutineUseCase : IRegisterRoutineUsecase
{
    private readonly IRoutineWriteOnlyRepository _repository;
    private readonly IUserReadOnlyRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterRoutineUseCase(
        IRoutineWriteOnlyRepository repository,
        IUserReadOnlyRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisteredRoutineJson> Execute(RequestRegisterRoutineJson request)
    {
        await Validate(request);

        var routine = request.Adapt<Domain.Entities.Routine>();

        await _repository.Add(routine);
        await _unitOfWork.Commit();

        return new()
        {
            Name = routine.Name
        };
    }
    private async Task Validate(RequestRegisterRoutineJson request)
    {
        var result = new RegisterRoutineValidator().Validate(request);

        var userExist = await _userRepository.ExistUserWithId(request.UserId);

        if (!userExist)
            throw new NotFoundException(ResourceMessagesException.USER_NOT_FOUND);

        if (!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(f => f.ErrorMessage).ToList());
    }
}
