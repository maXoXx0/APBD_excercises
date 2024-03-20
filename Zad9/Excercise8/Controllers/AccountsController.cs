using Excercise8.Models.DTOs;
using Excercise9.Models;
using Excercise9.Models.DTOs;
using Excercise9.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Excercise9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public readonly IAccountsService _accountsService;
        private readonly IConfiguration _configuration;
        public AccountsController(IAccountsService accountsService, IConfiguration configuration)
        {
            _accountsService = accountsService;
            _configuration = configuration;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {

            if (!_accountsService.IsLoginAndPasswordCorrect(loginRequest))
            {
                return BadRequest("Złe hasło lub login");
            }


            var secret = _configuration["JWT:Secret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds
                ) ;

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = new JwtSecurityToken(
                expires: DateTime.Now.AddDays(7)
                );

            string refreshJwt = new JwtSecurityTokenHandler().WriteToken(refreshToken);

            return Ok($"Token: {jwt}\n" +
                $"Refresh Token: {refreshJwt}");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest registration)
        {

            if (_accountsService.DoesLoginExists(registration.Login))
            {
                return BadRequest($"Login {registration.Login} już istnieje");
            }

            
            var user = new User
            {
                Login = registration.Login,
            };

            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, registration.Password);

            await _accountsService.AddUser(user);

            return Ok("Utworzono urzytkownika");
        }

        [HttpGet]
        public async Task<IActionResult> GetNewAccesToken(String RefreshToken)
        {

            var secret = _configuration["JWT:Secret"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var Token = new JwtSecurityToken(RefreshToken, signingCredentials: creds);
            var Jwt = new JwtSecurityTokenHandler().WriteToken(Token);

            return Ok(Jwt);
        }
    }
}
