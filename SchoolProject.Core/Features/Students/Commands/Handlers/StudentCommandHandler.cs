using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler (IStudentService studentService , IMapper mapper) : ResponseHandler, IRequestHandler
        <AddStudentCommand, Response<string>>
    {
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = mapper.Map<Student>(request);
            string result = await studentService.AddAsync(studentMapper);

            if (result == "Exist")
                return UnprocessableEntity<string>($"The Name : {studentMapper.Name} is repeated");
           
            return Created("Added Successfully");
        }
    }
}
