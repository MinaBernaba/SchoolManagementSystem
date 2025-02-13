using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Users.Queries.Responses;

namespace SchoolProject.Core.CQRS.Users.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserMainInfoResponse>>
    {
        public int UserId { get; set; }
    }
}
