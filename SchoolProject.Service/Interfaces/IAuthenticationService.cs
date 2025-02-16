using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Interfaces
{
    public interface IAuthenticationService
    {
        string GetJWTToken(User user);
    }
}
