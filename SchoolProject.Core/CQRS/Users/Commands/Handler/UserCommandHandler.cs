using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Users.Commands.Models;
using SchoolProject.Core.CQRS.Users.Commands.Responses;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.CQRS.Users.Commands.Handler
{
    public class UserCommandHandler(UserManager<User> userManager, IMapper mapper, IAuthenticationService authenticationService) : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<AuthResponse>>,
        IRequestHandler<UpdateUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        #region Handle Add new user
        public async Task<Response<AuthResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            var createResult = await userManager.CreateAsync(user, request.Password);

            if (!createResult.Succeeded)
            {
                var errors = string.Join("\n", createResult.Errors.Select(e => e.Description));
                return BadRequest<AuthResponse>(errors);
            }

            (string token, DateTime expiresOn) = authenticationService.GetJWTToken(user);

            var successAuthResponse = new AuthResponse()
            {
                Email = user.Email,
                Token = token,
                UserName = user.UserName,
                ExpiresOn = expiresOn
            };
            return Success(successAuthResponse, message: $"User with username: {user.UserName} registered successfully.");
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
                var errors = string.Join("\n", updateResult.Errors.Select(e => e.Description));
                return BadRequest<string>($"Failed to update user!\n Errors: {errors}");
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
                var errors = string.Join("\n", deleteResult.Errors.Select(e => e.Description));
                return BadRequest<string>($"Failed to Delete user!\n Errors: {errors}");
            }
            return Deleted<string>($"User  with ID: {user.Id} deleted successfully!");
        }
        #endregion

        #region Handle change password
        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
                return NotFound<string>($"No user with username: {request.UserName} exists! ");

            var changePasswordResult = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                var errors = string.Join("\n  - ", changePasswordResult.Errors.Select(x => x.Description));
                return BadRequest<string>($"Failed to update password!\nErrors:\n  - {errors}");
            }
            return Updated<string>($"Password for user '{request.UserName}' changed successfully!");
        }
        #endregion
    }
}
