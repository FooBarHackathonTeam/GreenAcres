using Authentication;
using Authentication.Models;
using AuthenticationLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AuthenticationService _authentication;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public LoginController(IConfiguration configuration, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _configuration = configuration;
            _authentication = new AuthenticationService(configuration, userManager, roleManager);
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.UserName);
            bool isCorrect = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (user == null || !isCorrect)
            {
                return Unauthorized();
            }

           

            var token = await _authentication.Generate(user);

            return Ok(new Response
            {
                Email = user.Email,
                UserName = user.UserName,
                Token = token
            });
        }
    }
}
