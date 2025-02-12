using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;
using SchoolProject.Core.CQRS.Users.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolManagementSystem.api.Controllers
{
    [ApiController]
    public class UserController : AppControllerBase
    {
        #region Resigter New User 
        [HttpPost(Router.User.AddNewUser)]
        public async Task<IActionResult> AddNewUser(AddUserCommand addUserCommand) => NewResult(await Mediator.Send(addUserCommand));
        #endregion

    }
}
