using JwtAuthentication.BAL;
using JwtAuthentication.Model;
using JwtAuthentication.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace JwtAuthentication.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        public readonly ITokenRepository _tokenRepository;
        public AccountController(ITokenRepository tokenInterface) {
            _tokenRepository = tokenInterface;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string userName, string password)
        {
            //Check if Username and Password matches then
            if ((userName.Equals("test") || userName.Equals("test1") || userName.Equals("test2")) && password.Equals("test@123"))
            {
                //Get the roles for the user
                var roles = new List<string>();
                if (userName.Equals("test")) roles = new List<string>() { Roles.Administrator };
                else if (userName.Equals("test1")) roles = new List<string>() { Roles.Reader };
                else if (userName.Equals("test2")) roles = new List<string>() { Roles.Writer };

                //create token and send it to Dto
                var jwtToken = _tokenRepository.CreateJWTToken(userName, roles);
                var response = new LoginResponse()
                {
                    JwtToken = jwtToken
                };
                return Ok(response);
            }
            return BadRequest("Username or Password not found");
        }
    }
}
