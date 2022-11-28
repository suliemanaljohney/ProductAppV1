using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductAppV1.Server.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductAppV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DataContext _datacontext;
        public LoginController(IConfiguration config, DataContext datacontext)
        {
            _config = config;
            _datacontext = datacontext;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userlogin)
        {
            var user = Authenticate(userlogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            else
                return NotFound();
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.Firstname),
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.MobilePhone,user.Phone),
                new Claim(ClaimTypes.StreetAddress,user.Address),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], claims, expires:DateTime.Now.AddMinutes(5),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(UserLogin userlogin)
        {
            var currentuser= _datacontext.Users.FirstOrDefault(x=>x.Username.ToLower()== userlogin.UserName.ToLower() && x.Password.ToLower()== userlogin.Password.ToLower());
            if (currentuser != null)
            {
                return currentuser;
            }
            else return null;
        }
    }
}
