﻿using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler(IStudentService studentService, IMapper mapper) : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<GetStudentMainInfoResponse>>,
        IRequestHandler<EditStudentCommand, Response<string>>

    {
        public async Task<Response<GetStudentMainInfoResponse>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentMapper = mapper.Map<Student>(request);
            await studentService.AddAsync(studentMapper);
            return Created(mapper.Map<GetStudentMainInfoResponse>(studentMapper));
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.StudentId);
            if (student == null) return NotFound<string>($"No student ID: {request.StudentId} exists!");

            var studentMapper = mapper.Map<Student>(request);
            await studentService.UpdateStudentAsync(studentMapper);

            return Updated<string>($"Student ID: {request.StudentId} Updated successfully");
        }
    }
}
