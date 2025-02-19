using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Authentication.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.CQRS.Authentication.Commands.Handler
{
    public class AuthCommandHandler(UserManager<User> userManager, IAuthenticationService authenticationService) : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JWTAuthResponse>>,
        IRequestHandler<RevokeRefreshTokenCommand, Response<string>>
    {
        public async Task<Response<JWTAuthResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {

            var user = await userManager.Users.Include(x => x.RefreshTokens.Where(x => x.ExpiresOn >= DateTime.UtcNow && x.RevokedOn == null)).FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
                return BadRequest<JWTAuthResponse>("Invalid username or password.");

            var jwtAuthResponse = await authenticationService.LoginAsync(user);

            return Success(jwtAuthResponse, message: $"User with username: {user.UserName} logged in successfully.");
        }

        public async Task<Response<string>> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            if (await authenticationService.RevokeRefreshTokenAsync(request.RefreshToken))
                return Success("Refresh token revoked successfully.");

            else
                return BadRequest<string>("Refresh token is invalid, No revoke!");
        }
    }
}
