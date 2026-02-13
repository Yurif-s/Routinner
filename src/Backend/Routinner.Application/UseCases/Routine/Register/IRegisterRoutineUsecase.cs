using Routinner.Communication.Requests;
using Routinner.Communication.Responses;

namespace Routinner.Application.UseCases.Routine.Register;

public interface IRegisterRoutineUsecase
{
    Task<ResponseRegisteredRoutineJson> Execute(RequestRegisterRoutineJson request);
}
