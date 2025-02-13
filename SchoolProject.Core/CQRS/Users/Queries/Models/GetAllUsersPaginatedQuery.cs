using MediatR;
using SchoolProject.Core.CQRS.Users.Queries.Responses;
using SchoolProject.Core.Wrappers;

namespace SchoolProject.Core.CQRS.Users.Queries.Models
{
    public class GetAllUsersPaginatedQuery : IRequest<PaginatedResult<GetUserMainInfoResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
