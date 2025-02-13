using AutoMapper;

namespace SchoolProject.Core.Mapping.UserMapper
{
    public partial class UserProfile : Profile
    {
        public UserProfile()
        {
            AddUserMapper();
            UserInfoMapper();
            UpdateUserMapper();
        }
    }
}
