using MediatR;
using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentsPaginatedQuery : IRequest<PaginatedResult<GetStudentMainInfoResponse>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public EnStudentOrdering OrderBy { get; set; }
        public string? Search { get; set; }

    }
}
