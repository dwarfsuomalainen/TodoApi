using TodoApi.Dto.Auth;

namespace TodoApi.Services
{
    public interface IAuthService
    {
    Task SignUp(SignUpDto payload);
    Task<String>SignIn(SignInDto payload);
    Task ChangePassword(ChangePasswordDto payload);
    }
}