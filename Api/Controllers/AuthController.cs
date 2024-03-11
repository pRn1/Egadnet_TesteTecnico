using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Viacep.Application.Interfaces;
using Viacep.Application.Models;

namespace ViacepEgadnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost("/authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials credentials)
        {
            var user = await _authAppService.AuthenticateAsync(credentials.Username, credentials.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("egadnet_teste_tecnico_secret_key");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, "username"),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { token = tokenHandler.WriteToken(token) });        
        }
    }
}
