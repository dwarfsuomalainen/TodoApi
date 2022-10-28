using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TodoApi.Dto.Auth;
using TodoApi.Options;
namespace TodoApi.Services
{
    public class AuthService: IAuthService
    {
     private readonly JwtOptions _jwtOptions;
    public AuthService(
        IOptions<JwtOptions> jwtOptions){
        _jwtOptions = jwtOptions.Value;
    }
    public async Task SignUp(SignUpDto payload)
    {
        
    }
    public async Task<String>SignIn(SignInDto payload)
    {
         /*var user = _unitOfWork.Users.FindByEmail(payload.Email);

        if (user is null || !BCrypt.Net.BCrypt.Verify(payload.Password, user.Password))
        {
            throw new AuthorizationException("Email and/or password is incorrect");
        }*/ 
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                //new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, "user.Id.ToString"),
                new Claim(JwtRegisteredClaimNames.Email, "user.Email"),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
            }),

            Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.TtlInMinutes),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Key)),
                SecurityAlgorithms.HmacSha512Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        var stringToken = tokenHandler.WriteToken(token);

        return stringToken;
    }
    public async Task ChangePassword(ChangePasswordDto payload)
    {

    }
    }
}