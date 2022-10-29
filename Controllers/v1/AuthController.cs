using TodoApi.Dto.Auth;
using TodoApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers.v1;

[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}")]
[ApiVersion("1")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("SignUp")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp(SignUpDto payload)
    {
        await _authService.SignUp(payload);
        return new OkResult();
    }

    [HttpPost("SignIn")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn(SignInDto payload)
    {
        var token = await _authService.SignIn(payload);
        return new OkObjectResult(token);
    }

    [HttpPost("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordDto payload)
    {
        await _authService.ChangePassword(payload);
        return new OkResult();
    }
}
