using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Departments.Queries.Responses;

namespace SchoolProject.Core.CQRS.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentByIdWithDetailsResponse>>
    {
        public int DepartmentId { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }
    }
}
