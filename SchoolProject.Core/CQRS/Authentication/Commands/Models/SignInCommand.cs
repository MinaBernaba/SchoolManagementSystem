using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.CQRS.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JWTAuthResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
