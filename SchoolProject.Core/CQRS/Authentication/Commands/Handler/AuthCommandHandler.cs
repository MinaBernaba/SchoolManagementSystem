using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Authentication.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.CQRS.Authentication.Commands.Handler
{
    public class AuthCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authenticationService) : ResponseHandler,
        IRequestHandler<SignInCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return NotFound<string>($"No user with Username: {request.UserName} exist!");

            var signInResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!signInResult.Succeeded)
                return BadRequest<string>("Invalid username or password.");

            var token = authenticationService.GetJWTToken(user);

            return Success(token);
        }
    }
}
