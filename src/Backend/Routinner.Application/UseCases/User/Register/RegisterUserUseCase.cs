using FluentValidation.Results;
using Mapster;
using Routinner.Communication.Requests;
using Routinner.Communication.Responses;
using Routinner.Domain.Repositories;
using Routinner.Domain.Security.Cryptography;
using Routinner.Exception;
using Routinner.Exception.ExceptionsBase;

namespace Routinner.Application.UseCases.User.Register;

public class RegisterUserUseCase : IRegisterUserUseCase
{
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    public RegisterUserUseCase(
        IUserReadOnlyRepository readOnlyRepository,
        IUserWriteOnlyRepository writeOnlyRepository,
        IUnitOfWork unitOfWork,
        IPasswordHasher passwordHasher)
    {
        _readOnlyRepository = readOnlyRepository;
        _writeOnlyRepository = writeOnlyRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }
    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        await Validate(request);

        var user = request.Adapt<Domain.Entities.User>();
        user.Password = _passwordHasher.Hash(request.Password);

        await _writeOnlyRepository.Add(user);
        await _unitOfWork.Commit();

        return new()
        {
            Id = user.Id,
            Name = user.Name
        };
    }
    private async Task Validate(RequestRegisterUserJson request)
    {
        var result = new RegisterUserValidator().Validate(request);

        var emailExist = await _readOnlyRepository.ExistActiveUserWithEmail(request.Email);

        if (emailExist)
            result.Errors.Add(new ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_ALREADY_REGISTERED));

        if (!result.IsValid)
            throw new ErrorOnValidationException(result.Errors.Select(f => f.ErrorMessage).ToList());
    }
}
