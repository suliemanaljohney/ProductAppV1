using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductAppV1.Shared.Dto.UserDto;
using System.Security.Claims;
using UserAppV1.Server.Data.AppService.UserAppService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAppV1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }


        [HttpGet("GetAllUsers")]
        [Authorize(Roles = "administrator")]
        public IActionResult GetAllUser()
        {
            var data = _userAppService.GetAllUsers();
            return Ok(data);
        }



        [HttpGet("GetUserById/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult GetSingleUser(int id)
        {
            var data = _userAppService.GetUserById(id);
            return Ok(data);
        }


        [HttpPost("AddNewUser")]
        [Authorize(Roles = "administrator")]
        public IActionResult Post([FromBody] CreateUserDto User)
        {
            var response = _userAppService.AddNewUser(User);
            return Ok(response);
        }


        [HttpPut("UpdateUser/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Put(int id,UpdateUserDto User)
        {
            var response = _userAppService.UpdateUser(id,User);
            return Ok(response);
        }


        [HttpDelete("DeleteUser/{id}")]
        [Authorize(Roles = "administrator")]
        public IActionResult Delete(int id)
        {
            var response = _userAppService.DeleteUser(id);
            return Ok(response);
        }

        [HttpGet("GetUserrole")]
        [Authorize]
        public IActionResult GetCurrentUserRole()
        {
            var currentuser = GetCurrentUser();
            return Ok($"Hi {currentuser.Firstname} you are {currentuser.Role}");

        }
        private User GetCurrentUser()
        {
            var identity=HttpContext.User.Identity as ClaimsIdentity;
            if(identity!=null)
            {
                var userclaims = identity.Claims;
                return new User
                {
                    Username = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                    Email = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                    Firstname = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                    Surname = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.Surname)?.Value,
                    Address = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.StreetAddress)?.Value,
                    Role = userclaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
                };
            }
            return null;
        }

       
    }
}
