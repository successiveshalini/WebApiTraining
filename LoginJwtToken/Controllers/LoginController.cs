using JwtTokenApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JwtTokenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private object _;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        private Users AuthenciateUser(Users user)
        {
            Users _user = null;
            if(user.UserNmae == "admin" && user.Password == "12345")
            {
                _user = new Users { UserNmae = "shalini kumari" };
                
            }
            return _user;

        }
        private string GenerateToken(Users users)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials
                ); 
            return new JwtSecurityTokenHandler().WriteToken(token); 
            

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users user)
        { 
            IActionResult response = Unauthorized();
            var user_ = AuthenciateUser(user);
            if (user_ != null)
            { 
                var token = GenerateToken(user_);
                response = Ok(new { token = token });
            }
            return response;
            
        }
    }
}
 