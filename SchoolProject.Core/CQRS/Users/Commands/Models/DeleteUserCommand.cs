using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.CQRS.Users.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
