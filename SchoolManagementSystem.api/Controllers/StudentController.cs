using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Data.Entities;

namespace SchoolManagementSystem.api.Controllers
{
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {

        #region GetById
        [HttpGet(Router.Student.GetStudentById)]
        public async Task<IActionResult> FindStudentById(int id) => Ok(await mediator.Send(new GetStudentByIdQuery() { Id = id}));
        #endregion

        #region GetAllStudents

        [HttpGet(Router.Student.GetAllStudents)]
        public async Task<IActionResult> GetAllStudents() => Ok(await mediator.Send(new GetAllStudentsQuery()));

        #endregion

        #region Add Student 

        [HttpPost(Router.Student.CreateStudent)]
        public async Task<IActionResult> CreateStudent(AddStudentCommand addStudent)
        {
            var responce = await (mediator.Send(addStudent));
            return Ok(responce);
        }

        #endregion

    }
}
