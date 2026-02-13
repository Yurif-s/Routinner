using Mapster;
using Routinner.Communication.Requests;
using Routinner.Communication.Responses;
using Routinner.Domain.Repositories;
using Routinner.Domain.Repositories.Routine;
using Routinner.Exception.ExceptionsBase;

namespace Routinner.Application.UseCases.Routine.Register;

public class RegisterRoutineUseCase : IRegisterRoutineUsecase
{
    private readonly IRoutineWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterRoutineUseCase(
        IRoutineWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisteredRoutineJson> Execute(RequestRegisterRoutineJson request)
    {
        Validate(request);

        var routine = request.Adapt<Domain.Entities.Routine>();

        await _repository.Add(routine);
        await _unitOfWork.Commit();

        return new()
        {
            Name = routine.Name
        };
    }
    private void Validate(RequestRegisterRoutineJson request)
    {
        var result = new RegisterRoutineValidator().Validate(request);

        if (!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(f => f.ErrorMessage).ToList());
    }
}
