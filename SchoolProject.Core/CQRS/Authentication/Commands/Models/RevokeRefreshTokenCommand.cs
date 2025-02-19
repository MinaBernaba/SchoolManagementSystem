using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.CQRS.Authentication.Commands.Models
{
    public class RevokeRefreshTokenCommand : IRequest<Response<string>>
    {
        public string RefreshToken { get; set; }
    }
}
