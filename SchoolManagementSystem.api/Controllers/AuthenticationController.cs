using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;
using SchoolProject.Core.CQRS.Authentication.Commands.Models;
using SchoolProject.Core.CQRS.Authentication.Queries.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Helpers;

namespace SchoolManagementSystem.api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {


        private void SetRefreshTokenInCookie(string refreshToken, DateTime expiresOn)
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = expiresOn.ToLocalTime()
            };
            Response.Cookies.Append("RefreshToken", refreshToken, cookieOptions);
        }
        private void DeleteRefreshTokenCookie()
        {
            var cookieOptions = new CookieOptions()
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(-1)
            };
            Response.Cookies.Append("RefreshToken", "", cookieOptions);
        }

        [HttpGet(Router.Authentication.RenewRefreshToken)]
        public async Task<IActionResult> RenewRefreshToken()
        {
            var refreshToken = Request.Cookies["RefreshToken"];

            if (string.IsNullOrWhiteSpace(refreshToken))
                return BadRequest("No refresh token provided!");

            var response = await Mediator.Send(new RenewRefreshTokenQuery() { RefreshToken = refreshToken });

            if (response.Data != null)
                SetRefreshTokenInCookie(response.Data.RefreshToken, response.Data.RefreshTokenExpiration);
            else
                DeleteRefreshTokenCookie();

            return NewResult(response);
        }

        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn(SignInCommand signInCommand)
        {
            var response = await Mediator.Send(signInCommand);
            if (response.Data == null)
            {
                DeleteRefreshTokenCookie();
                return NewResult(response);
            }

            SetRefreshTokenInCookie(response.Data.RefreshToken, response.Data.RefreshTokenExpiration);
            return NewResult(response);
        }

        [HttpPost(Router.Authentication.RevokeRefreshToken)]
        public async Task<IActionResult> RevokeRefreshToken(RevokeRefreshToken revokeToken)
        {
            var refreshToken = revokeToken.RefreshToken ?? Request.Cookies["RefreshToken"];
            if (string.IsNullOrWhiteSpace(refreshToken))
                return BadRequest("Refresh Token is required!");
            else
                return NewResult(await Mediator.Send(new RevokeRefreshTokenCommand() { RefreshToken = refreshToken }));
        }

    }
}
