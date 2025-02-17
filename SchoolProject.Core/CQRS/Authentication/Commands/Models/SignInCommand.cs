using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Authentication.Commands.Responces;

namespace SchoolProject.Core.CQRS.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<AuthResponse>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
