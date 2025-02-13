using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.CQRS.Users.Commands.Handler
{
    public class UserCommandHandler(UserManager<User> userManager, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>
    {
        #region Handle Add new user
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
        #endregion

        #region Handle Update user
        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());

            if (user == null)
                return NotFound<string>($"No user with ID: {request.Id} exist!");

            var userMapper = mapper.Map(request, user);

            var updateResult = await userManager.UpdateAsync(userMapper);
            if (!updateResult.Succeeded)
            {
                var errors = string.Join(Environment.NewLine, updateResult.Errors.Select(e => e.Description));
                return BadRequest<string>($"Failed to update user!{Environment.NewLine} Errors: {errors}");
            }
            return Updated<string>($"User  with ID: {userMapper.Id} Updated successfully!");
        }
        #endregion

        #region Handle delete user
        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
                return NotFound<string>($"No user with ID: {request.Id} exist!");

            var deleteResult = await userManager.DeleteAsync(user);

            if (!deleteResult.Succeeded)
            {
                var errors = string.Join(Environment.NewLine, deleteResult.Errors.Select(e => e.Description));
                return BadRequest<string>($"Failed to Delete user!{Environment.NewLine} Errors: {errors}");
            }
            return Deleted<string>($"User  with ID: {user.Id} deleted successfully!");
        }
        #endregion

    }
}
