using SchoolProject.Core.CQRS.Users.Queries.Responses;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Mapping.UserMapper
{
    public partial class UserProfile
    {
        public void UserInfoMapper()
        {
            CreateMap<User, GetUserMainInfoResponse>();
        }
    }
}
