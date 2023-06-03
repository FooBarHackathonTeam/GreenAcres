using Authentication;
using Authentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AuthenticationService _authentication;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
            _authentication = new AuthenticationService(configuration);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = _authentication.Authenticate(userLogin);

            if (user == null)
            {
                return NotFound("User not found");
            }

            if (user.Password != userLogin.Password)
            {
                return Unauthorized("Wrong password");
            }

            var token = _authentication.Generate(user);
            return Ok(token);
        }
    }
}
