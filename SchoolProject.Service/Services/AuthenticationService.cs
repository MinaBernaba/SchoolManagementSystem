using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolProject.Service.Services
{
    public class AuthenticationService(IOptionsMonitor<JWTOptions> jwtOptions, UserManager<User> userManager) : IAuthenticationService
    {
        private string CreateJWTToken(User user)
        {
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
                Expires = DateTime.UtcNow.AddDays(jwtOptions.CurrentValue.LifeTime),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.CurrentValue.SigningKey)), SecurityAlgorithms.HmacSha256)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);
            return accessToken;
        }
        private RefreshToken CreateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
            }
            string token = Convert.ToBase64String(randomNumber);

            return new RefreshToken()
            {
                Token = token,
                ExpiresOn = DateTime.UtcNow.AddDays(jwtOptions.CurrentValue.RefreshTokenLifeTime),
                CreatedOn = DateTime.UtcNow
            };
        }
        public async Task<JWTAuthResponse> LoginAsync(User user)
        {
            string jwtToken = CreateJWTToken(user);

            var authResponse = new JWTAuthResponse()
            {
                UserName = user.UserName,
                Email = user.Email,
                Token = jwtToken,
                Roles = null
            };

            var activeRefreshToken = user.RefreshTokens.FirstOrDefault(x => x.IsActive);

            if (activeRefreshToken != null)
            {
                activeRefreshToken.ExpiresOn = activeRefreshToken.ExpiresOn.AddDays(jwtOptions.CurrentValue.LifeTime * 10);
                authResponse.RefreshToken = activeRefreshToken.Token;
                authResponse.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }

            else
            {
                var newRefreshToken = CreateRefreshToken();
                authResponse.RefreshToken = newRefreshToken.Token;
                authResponse.RefreshTokenExpiration = newRefreshToken.ExpiresOn;
                user.RefreshTokens.Add(newRefreshToken);
            }

            await userManager.UpdateAsync(user);

            return authResponse;
        }
        public async Task<JWTAuthResponse?> RenewRefreshTokenAsync(string refreshToken)
        {
            var user = await userManager.Users.Include(x => x.RefreshTokens).SingleOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token.Equals(refreshToken)));

            if (user == null)
                return null;

            var userRefreshToken = user.RefreshTokens.Single(x => x.Token.Equals(refreshToken));


            if (!userRefreshToken.IsActive)
                return null;


            userRefreshToken.RevokedOn = DateTime.UtcNow;

            var newRefreshToken = CreateRefreshToken();

            user.RefreshTokens.Add(newRefreshToken);

            await userManager.UpdateAsync(user);

            string jwtToken = CreateJWTToken(user);

            return new JWTAuthResponse()
            {
                Token = jwtToken,
                Email = user.Email,
                UserName = user.UserName,
                Roles = null,
                RefreshToken = newRefreshToken.Token,
                RefreshTokenExpiration = newRefreshToken.ExpiresOn
            };
        }
        public async Task<bool> RevokeRefreshTokenAsync(string refreshToken)
        {
            var user = await userManager.Users.Include(x => x.RefreshTokens).SingleOrDefaultAsync(x => x.RefreshTokens.Any(x => x.Token.Equals(refreshToken)));

            if (user == null)
                return false;

            var userRefreshToken = user.RefreshTokens.Single(x => x.Token.Equals(refreshToken));


            if (!userRefreshToken.IsActive)
                return false;

            userRefreshToken.RevokedOn = DateTime.UtcNow;

            await userManager.UpdateAsync(user);

            return true;
        }
    }
}
