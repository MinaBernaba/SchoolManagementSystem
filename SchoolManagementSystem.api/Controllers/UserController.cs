using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;
using SchoolProject.Core.CQRS.Users.Commands.Models;
using SchoolProject.Core.CQRS.Users.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolManagementSystem.api.Controllers
{
    [ApiController]
    public class UserController : AppControllerBase
    {
        #region Get All Users Paginated
        [HttpGet(Router.User.GetAllUsersPaginated)]
        public async Task<IActionResult> GetAllUsersPaginated([FromQuery] int pageNumber, int pageSize)
            => Ok(await Mediator.Send(new GetAllUsersPaginatedQuery() { PageNumber = pageNumber, PageSize = pageSize }));
        #endregion

        #region Get User By Id

        [HttpGet(Router.User.GetUserById)]
        public async Task<IActionResult> GetUserById(int id) => NewResult(await Mediator.Send(new GetUserByIdQuery() { UserId = id }));

        #endregion

        #region Resigter New User 
        [HttpPost(Router.User.AddNewUser)]
        public async Task<IActionResult> AddNewUser(AddUserCommand addUserCommand) => NewResult(await Mediator.Send(addUserCommand));
        #endregion

        #region Update User 
        [HttpPut(Router.User.UpdateUser)]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand updateUser) => NewResult(await Mediator.Send(updateUser));
        #endregion

        #region Change password 
        [HttpPut(Router.User.ChangePassword)]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand changePassword) => NewResult(await Mediator.Send(changePassword));
        #endregion

        #region Delete User 
        [HttpDelete(Router.User.DeleteUser)]
        public async Task<IActionResult> DeleteUser(int id) => NewResult(await Mediator.Send(new DeleteUserCommand() { Id = id }));
        #endregion

    }
}
