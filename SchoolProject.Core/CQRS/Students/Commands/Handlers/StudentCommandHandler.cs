using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities.DbTables;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler(IStudentService studentService, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>

    {
        #region Handle Add new student

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = mapper.Map<Student>(request);
            await studentService.AddAsync(studentMapper);
            return Created<string>($"New student added successfully with ID: {studentMapper.StudentId} and Name: {studentMapper.Name}!");
        }

        #endregion

        #region Handle Update student

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            if (!await studentService.IsStudentExistByIdAsync(request.StudentId))
                return NotFound<string>($"No student ID: {request.StudentId} exists!");

            var studentMapper = mapper.Map<Student>(request);
            await studentService.UpdateStudentAsync(studentMapper);

            return Updated<string>($"Student ID: {request.StudentId} Updated successfully");
        }

        #endregion

        #region Handle Delete student
        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            if (!await studentService.IsStudentExistByIdAsync(request.StudentId))
                return NotFound<string>($"No student ID: {request.StudentId} exists!");

            if (await studentService.DeleteStudentByIdAsync(request.StudentId))
                return Deleted<string>($"Student ID: {request.StudentId} Deleted successfully");
            else return BadRequest<string>("Deleted failed");
        }
        #endregion 

    }
}
