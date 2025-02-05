using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.api.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolManagementSystem.api.Controllers
{
    [ApiController]
    public class StudentController: AppControllerBase
    {

        #region GetById
        [HttpGet(Router.Student.GetStudentById)]
        public async Task<IActionResult> FindStudentById(int id) => NewResult(await Mediator.Send(new GetStudentByIdQuery() { Id = id}));
        #endregion

        #region GetAllStudents

        [HttpGet(Router.Student.GetAllStudents)]
        public async Task<IActionResult> GetAllStudents() => NewResult(await Mediator.Send(new GetAllStudentsQuery()));

        #endregion

        #region Add Student 

        [HttpPost(Router.Student.CreateStudent)]
        public async Task<IActionResult> CreateStudent(AddStudentCommand addStudent) => NewResult(await (Mediator.Send(addStudent)));

        #endregion

    }
}
