using Authentication.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class AuthenticationService
    {
        private readonly IConfiguration configuration;
        public AuthenticationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string Generate(UserModel user)
        {
            var seciurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(seciurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
            };

            JwtSecurityToken token = new(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserModel? Authenticate(LoginModel userLogin) => 
            UserConstants.ExampleUsers.FirstOrDefault(o =>
                    o.Email.ToLower() == userLogin.UserName.ToLower()
            );
    }
}
