using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.CQRS.Authentication.Queries.Models
{
    public class RenewRefreshTokenQuery : IRequest<Response<JWTAuthResponse>>
    {
        public string RefreshToken { get; set; }
    }
}
