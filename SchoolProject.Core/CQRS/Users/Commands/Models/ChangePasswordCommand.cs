using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.CQRS.Users.Commands.Models
{
    public class ChangePasswordCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
