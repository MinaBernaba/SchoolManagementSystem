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
        public (string Token, DateTime ExpiresOn) GetJWTToken(User user)
        {
            var expirationDate = DateTime.Now.AddMinutes(jwtOptions.CurrentValue.LifeTime);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim(ClaimTypes.Name , user.FullName),
                new Claim("Username" ,  user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = jwtOptions.CurrentValue.Issuer,
                Audience = jwtOptions.CurrentValue.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = expirationDate,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.CurrentValue.SigningKey)), SecurityAlgorithms.HmacSha256)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return (accessToken, expirationDate);
        }
    }
}
