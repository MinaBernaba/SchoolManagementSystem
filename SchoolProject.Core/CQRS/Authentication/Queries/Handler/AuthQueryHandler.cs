using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Authentication.Queries.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.CQRS.Authentication.Queries.Handler
{
    public class AuthQueryHandler(IAuthenticationService authenticationService) : ResponseHandler,
        IRequestHandler<RenewRefreshTokenQuery, Response<JWTAuthResponse>>
    {
        public async Task<Response<JWTAuthResponse>> Handle(RenewRefreshTokenQuery request, CancellationToken cancellationToken)
        {
            var response = await authenticationService.RenewRefreshTokenAsync(request.RefreshToken);
            if (response == null)
                return BadRequest<JWTAuthResponse>("Invalid token");

            return Success(response);
        }
    }
}
