using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Students.Queries.Models;

namespace SchoolManagementSystem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IMediator mediator) : ControllerBase
    {
        #region GetById
        [HttpGet("GetStudentById/{id}")]
        public async Task<IActionResult> FindStudentById(int id)
        {
            return Ok(await mediator.Send(new GetAllStudentsQuery()));
        }
        #endregion

        #region GetAllStudents

        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudents() => Ok(await mediator.Send(new GetAllStudentsQuery()));

        #endregion
    }
}
