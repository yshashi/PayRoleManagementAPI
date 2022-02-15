using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayRoleManagementAPI.Data;
using PayRoleManagementAPI.Models;
using System.Linq;

namespace PayRoleManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserDbContext _context;
        public AuthController(UserDbContext userDbContext)
        {
            _context = userDbContext;
        }
        [HttpPost("signup")]
        public IActionResult SignUp(UserModel userObj)
        {
            _context.UserModels.Add(userObj);
            _context.SaveChanges();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Signup Successfully"
            });
        }
        [HttpPost("login")]
        public IActionResult Login(UserModel userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }
            else
            {
                var user = _context.UserModels.Where(a => a.UserName == userObj.UserName && a.Password == userObj.Password).FirstOrDefault();
                if (user == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "User Not Found"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Successfully"
                    });
                }
            }
        }
    }
}
