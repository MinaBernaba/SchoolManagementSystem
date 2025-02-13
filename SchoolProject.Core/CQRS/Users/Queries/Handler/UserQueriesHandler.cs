using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using SchoolProject.Core.CQRS.Users.Queries.Models;
using SchoolProject.Core.CQRS.Users.Queries.Responses;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities.Identity;
using System.Linq.Expressions;

namespace SchoolProject.Core.CQRS.Users.Queries.Handler
{
    public class UserQueriesHandler(UserManager<User> userManager, IMapper mapper) : ResponseHandler,
        IRequestHandler<GetAllUsersPaginatedQuery, PaginatedResult<GetUserMainInfoResponse>>,
        IRequestHandler<GetUserByIdQuery, Response<GetUserMainInfoResponse>>
    {
        #region Handle Get Paginated Users
        public async Task<PaginatedResult<GetUserMainInfoResponse>> Handle(GetAllUsersPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<User, GetUserMainInfoResponse>> expression = user => new GetUserMainInfoResponse
            {
                Address = user.Address,
                Country = user.Country,
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName
            };
            var users = await userManager.Users.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return users;
        }
        #endregion

        #region Handle Get User by ID
        public async Task<Response<GetUserMainInfoResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<User, GetUserMainInfoResponse>> expression = user => new GetUserMainInfoResponse
            {
                Address = user.Address,
                Country = user.Country,
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName
            };
            var user = await userManager.Users.Where(x => x.Id.Equals(request.UserId)).Select(expression).FirstOrDefaultAsync();

            if (user == null)
                return NotFound<GetUserMainInfoResponse>($"User ID: {request.UserId} doesn't exist!");

            return Success(user);
        }
        #endregion
    }
}
