using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler(IStudentService studentService, IMapper mapper) : ResponseHandler
        , IRequestHandler<GetAllStudentsQuery, Response<List<GetStudentMainInfoResponse>>>
        , IRequestHandler<GetStudentByIdQuery, Response<GetStudentMainInfoResponse>>
    {
        #region handle get all students
        public async Task<Response<List<GetStudentMainInfoResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var allStudents = await studentService.GetAllStudentsAsync();
            var studentsMapper = mapper.Map<List<GetStudentMainInfoResponse>>(allStudents);
            return Success(studentsMapper);
        }
        #endregion

        #region handle get student by id
        public async Task<Response<GetStudentMainInfoResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await studentService.GetStudentByIdAsync(request.Id);
            return (student == null) ? NotFound<GetStudentMainInfoResponse>($"No student with ID: {request.Id} is exist!") :
                Success(mapper.Map<GetStudentMainInfoResponse>(student));
        }
        #endregion
    }
}
