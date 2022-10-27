
using TodoApi.Models.Auth;
using TodoApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApi.Controllers.v1;

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
    public IActionResult SignUp(SignUpModel payload)
    {
        _authService.SignUp(payload);
        return new OkResult();
    }

    [HttpPost("SignIn")]
    [AllowAnonymous]
    public IActionResult SignIn(SignInModel payload)
    {
        var token = _authService.SignIn(payload);
        return new OkObjectResult(token);
    }

    [HttpPost("ChangePassword")]
    public IActionResult ChangePassword(ChangePasswordModel payload)
    {
        _authService.ChangePassword(payload);
        return new OkResult();
    }
}
