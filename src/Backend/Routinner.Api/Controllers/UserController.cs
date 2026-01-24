using Microsoft.AspNetCore.Mvc;
using Routinner.Communication.Responses;

namespace Routinner.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }
}
