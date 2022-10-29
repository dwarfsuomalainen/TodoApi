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
using TodoApi.Repositories;
using TodoApi.Models;
namespace TodoApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _context;

        public AuthService(
            IOptions<JwtOptions> jwtOptions, IUserRepository userRepository, IHttpContextAccessor context)
        {
            _jwtOptions = jwtOptions.Value;
            _userRepository = userRepository;
            _context = context;
        }
        public async Task SignUp(SignUpDto payload)
        {
            var userExist = _userRepository.CheckIsUserExistByEmail(payload.Email);
            if (userExist) throw new Exception(); // - custom exception needed! 
            await _userRepository.Add(new User { Email = payload.Email.ToLower(), Password = BCrypt.Net.BCrypt.HashPassword(payload.Password) }); // - !!!! Bcrypt 
        }
        public async Task<String> SignIn(SignInDto payload)
        {
            var user = _userRepository.FindByEmail(payload.Email);

            if (user is null || !BCrypt.Net.BCrypt.Verify(payload.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Email and/or password is incorrect"); // Custom exception needed!!!
            }
            

             var tokenDescriptor = new SecurityTokenDescriptor
             {
                 Subject = new ClaimsIdentity(new[]
                 {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
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
            var stringId = _context.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (stringId is null || !int.TryParse(stringId, out int userId)) throw new UnauthorizedAccessException();

        var user =await _userRepository.FindById(userId);

        if (user is null) throw new UnauthorizedAccessException();

        await _userRepository.UpdateUserPassword(userId, BCrypt.Net.BCrypt.HashPassword(payload.Password));
        }
    }
}