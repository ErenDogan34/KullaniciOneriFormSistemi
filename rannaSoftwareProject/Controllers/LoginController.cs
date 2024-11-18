using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using rannaSoftwareProject.Data.Dto;
using rannaSoftwareProject.Data.Entities;
using rannaSoftwareProject.Data.Model;
using rannaSoftwareProject.Service.Abstract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace rannaSoftwareProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IPersonRepository personrepository;

        public LoginController(IOptions<JwtSettings> jwtSettings, IPersonRepository personrepository)
        {
            _jwtSettings = jwtSettings.Value;
            this.personrepository = personrepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var person=await personrepository.GetByUserNameAsync(loginDto.Name);
            if(person==null)
            {
                return BadRequest();
            }
            if(person.RoleId==1)
            {
                var token = GenerateJwtToken("Admin",person.Id);
                return Ok(new { Token = token });
            }

            var tokenuser = GenerateJwtToken("User",person.Id);
            return Ok(new { Token = tokenuser });

        }

        private string GenerateJwtToken(string role,int  id)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, role),
            new Claim(ClaimTypes.Role, role),
            new Claim(ClaimTypes.NameIdentifier,id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
