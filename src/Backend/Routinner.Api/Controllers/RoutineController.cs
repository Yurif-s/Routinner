using Microsoft.AspNetCore.Mvc;
using Routinner.Application.UseCases.Routine.Register;
using Routinner.Communication.Requests;
using Routinner.Communication.Responses;

namespace Routinner.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class RoutineController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredRoutineJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register(
        [FromServices] IRegisterRoutineUsecase usecase,
        [FromBody] RequestRegisterRoutineJson request)
    {
        var response = await usecase.Execute(request);

        return Created(string.Empty, response);
    }
}
