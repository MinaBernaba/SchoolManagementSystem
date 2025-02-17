using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Authentication.Commands.Models;
using SchoolProject.Core.CQRS.Authentication.Commands.Responces;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.CQRS.Authentication.Commands.Handler
{
    public class AuthCommandHandler(UserManager<User> userManager, IAuthenticationService authenticationService) : ResponseHandler,
        IRequestHandler<SignInCommand, Response<AuthResponse>>
    {
        public async Task<Response<AuthResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);

            //either the following method or the next one after it, both are correct

            if (user == null || !await userManager.CheckPasswordAsync(user, request.Password))
                return BadRequest<AuthResponse>("Invalid username or password.");


            //var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            //if (!signInResult.Succeeded)
            //    return BadRequest<AuthResponse>("Invalid username or password.");


            (string token, DateTime expiresOn) = authenticationService.GetJWTToken(user);

            var successAuthResponse = new AuthResponse()
            {
                Email = user.Email,
                Token = token,
                UserName = user.UserName,
                ExpiresOn = expiresOn
            };
            return Success(successAuthResponse, message: $"User with username: {user.UserName} logged in successfully.");
        }
    }
}
