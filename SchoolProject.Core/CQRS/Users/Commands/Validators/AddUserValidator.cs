﻿using FluentValidation;
using SchoolProject.Core.CQRS.Users.Commands.Models;

namespace SchoolProject.Core.CQRS.Users.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        public AddUserValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.FullName).NotNull().WithMessage("Full name can't be null!")
                .NotEmpty().WithMessage("Full name can't be empty!");

            RuleFor(x => x.Email).NotNull().WithMessage("{PropertyName} can't be null!")
                .NotEmpty().WithMessage("{PropertyName} can't be empty!");

            RuleFor(x => x.UserName).NotNull().WithMessage("User name can't be null!")
                .NotEmpty().WithMessage("User name can't be empty!");

            RuleFor(x => x.Password).NotNull().WithMessage("{PropertyName} can't be null!")
               .NotEmpty().WithMessage("{PropertyName} can't be empty!");

            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("Confirm Password can't be null!")
               .NotEmpty().WithMessage("Confirm Password can't be empty!")
               .Equal(x => x.Password).WithMessage("Password and confirm password don't matched!");

        }
        public void ApplyCustomValidationRules()
        {

        }
    }
}
