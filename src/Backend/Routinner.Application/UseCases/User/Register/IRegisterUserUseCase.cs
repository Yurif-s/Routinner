using Routinner.Communication.Requests;
using Routinner.Communication.Responses;

namespace Routinner.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}
