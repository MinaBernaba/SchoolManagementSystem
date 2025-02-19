using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<JWTAuthResponse> LoginAsync(User user);
        Task<JWTAuthResponse?> RenewRefreshTokenAsync(string refreshToken);
        Task<bool> RevokeRefreshTokenAsync(string refreshToken);
    }
}
