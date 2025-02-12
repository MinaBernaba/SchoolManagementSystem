using SchoolProject.Core.CQRS.Users.Commands.Models;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.UserMapper
{
    public partial class UserProfile
    {
        public void AddUserMapper()
        {
            CreateMap<AddUserCommand, User>();
        }
    }
}
