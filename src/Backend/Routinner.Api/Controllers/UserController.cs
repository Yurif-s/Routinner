using Microsoft.AspNetCore.Mvc;

namespace Routinner.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }
}
