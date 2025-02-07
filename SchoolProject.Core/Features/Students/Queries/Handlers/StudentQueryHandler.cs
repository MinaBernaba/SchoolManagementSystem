using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Interfaces;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler(IStudentService studentService, IMapper mapper) : ResponseHandler
        , IRequestHandler<GetAllStudentsQuery, Response<List<GetStudentMainInfoResponse>>>
        , IRequestHandler<GetStudentByIdQuery, Response<GetStudentMainInfoResponse>>
        , IRequestHandler<GetStudentsPaginatedQuery, PaginatedResult<GetStudentMainInfoResponse>>
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

        #region handle pagination
        public async Task<PaginatedResult<GetStudentMainInfoResponse>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentMainInfoResponse>> expression = student => new GetStudentMainInfoResponse()
            {
                Address = student.Address,
                Name = student.Name,
                StudentId = student.StudentId,
                DepartmentName = student.Department.Name
            };

            if (request.Search != null)
                return await studentService.FilterStudentsIQueryable(request.Search)
                    .Select(expression)
                    .ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return await studentService.GetAllStudentsIQueryable()
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
        }
        #endregion

    }
}
