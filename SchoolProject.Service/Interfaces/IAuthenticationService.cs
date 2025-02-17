using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Interfaces
{
    public interface IAuthenticationService
    {
        (string Token, DateTime ExpiresOn) GetJWTToken(User user);
    }
}
