using FluentValidation;
using SchoolProject.Core.CQRS.Users.Commands.Models;

namespace SchoolProject.Core.CQRS.Users.Commands.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("User name can't be null!")
                .NotEmpty().WithMessage("User name can't be empty!");

            RuleFor(x => x.CurrentPassword)
               .NotNull().WithMessage("Current password can't be null!")
               .NotEmpty().WithMessage("Current password can't be empty!");

            RuleFor(x => x.NewPassword)
               .NotNull().WithMessage("New password can't be null!")
               .NotEmpty().WithMessage("New password can't be empty!");

            RuleFor(x => x.ConfirmPassword)
               .NotNull().WithMessage("Confirm password can't be null!")
               .NotEmpty().WithMessage("Confirm password can't be empty!")
               .Equal(x => x.NewPassword).WithMessage("New password and confirm password don't matched!");

        }
        public void ApplyCustomValidationRules()
        {

        }
    }
}
