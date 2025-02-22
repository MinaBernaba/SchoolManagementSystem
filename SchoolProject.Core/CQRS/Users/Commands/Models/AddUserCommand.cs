﻿using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.CQRS.Users.Commands.Models
{
    public class AddUserCommand : IRequest<Response<JWTAuthResponse>>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
