using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Departments.Queries.Models;
using SchoolProject.Core.CQRS.Departments.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.DbTables;
using SchoolProject.Service.Interfaces;
using System.Linq.Expressions;

namespace SchoolProject.Core.CQRS.Departments.Queries.Handler
{
    public class DepartmentQueryHandler(IDepartmentService departmentService, IStudentService studentService, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdWithDetailsResponse>>
    {
        #region Handle Get Department By Id With Details
        public async Task<Response<GetDepartmentByIdWithDetailsResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            if (!await departmentService.IsDepartmentExistByIdAsync(request.DepartmentId))
                return NotFound<GetDepartmentByIdWithDetailsResponse>($"No department ID: {request.DepartmentId} is found!");

            var departmentWithDetails = await departmentService.GetDepartmentByIdWithDetailsAsync(request.DepartmentId);

            var response = mapper.Map<GetDepartmentByIdWithDetailsResponse>(departmentWithDetails);

            Expression<Func<Student, StudentResponse>> expression = student => new StudentResponse()
            {
                Name = student.Name,
                StudentId = student.StudentId
            };
            var paginatedStudentList = await studentService.GetAllStudentsOfCertainDepartmentIQueryable(request.DepartmentId)
                .Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            response.StudentsList = paginatedStudentList;

            return Success(response);
        }
        #endregion
    }
}
