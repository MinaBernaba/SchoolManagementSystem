using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.CQRS.Users.Commands.Handler
{
    public class UserCommandHandler(UserManager<User> userManager, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var existingUserEmail = await userManager.FindByEmailAsync(request.Email);
            if (existingUserEmail != null)
                return BadRequest<string>("Email already exists for another user!");


            var existingUserName = await userManager.FindByNameAsync(request.UserName);
            if (existingUserName != null)
                return BadRequest<string>("Username already exists for another user!");

            var identityUser = mapper.Map<User>(request);
            var createResult = await userManager.CreateAsync(identityUser, request.Password);

            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(e => e.Description));
                return BadRequest<string>($"Failed to add user! Errors: {errors}");
            }
            return Created<string>($"User added successfully with ID: {identityUser.Id}");
        }
    }
}
