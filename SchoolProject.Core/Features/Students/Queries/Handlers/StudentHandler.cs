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
    public class StudentHandler(IStudentService studentService, IMapper mapper) :ResponseHandler , IRequestHandler<GetAllStudentsQuery, Response<List<GetAllStudentsResponse>>>
    {
        public async Task<Response<List<GetAllStudentsResponse>>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var allStudents = await studentService.GetAllStudentsAsync();
            var studentsMapper = mapper.Map<List<GetAllStudentsResponse>>(allStudents);
            return Success(studentsMapper);
        }
    }
}
