using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolProject.Service.Services
{
    public class AuthenticationService(IOptionsMonitor<JWTOptions> jwtOptions) : IAuthenticationService
    {
        public string GetJWTToken(User user)
        {
            List<Claim> cliams = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.FullName),
                new Claim("Username" ,  user.UserName),
                new Claim("Email" , user.Email)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescribtor = new SecurityTokenDescriptor()
            {
                Issuer = jwtOptions.CurrentValue.Issuer,
                Audience = jwtOptions.CurrentValue.Audience,
                Subject = new ClaimsIdentity(cliams),
                Expires = DateTime.Now.AddMinutes(jwtOptions.CurrentValue.LifeTime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.CurrentValue.SigningKey)), SecurityAlgorithms.HmacSha256)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescribtor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
        }
    }
}
