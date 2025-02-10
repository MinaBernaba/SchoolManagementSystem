using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;
using SchoolProject.Core.CQRS.Departments.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolManagementSystem.api.Controllers
{
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        #region Get department by id
        [HttpGet(Router.Department.GetDepartmentById)]
        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentByIdQuery getDepartment)
            => NewResult(await Mediator.Send(getDepartment));
        #endregion
    }
}
