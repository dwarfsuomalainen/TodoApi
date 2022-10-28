using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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