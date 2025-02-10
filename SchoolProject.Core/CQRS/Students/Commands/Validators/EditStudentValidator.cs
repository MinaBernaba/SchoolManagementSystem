using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService studentService;

        public EditStudentValidator(IStudentService studentService)
        {
            ApplyValidationRules();
            ApplyCustomRules();
            this.studentService = studentService;
        }
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty!")
                .NotNull().WithMessage("Name must not be null!")
                .MaximumLength(15).WithMessage("Name is too long!");

            RuleFor(x => x.DepartmentId)
               .NotEmpty().WithMessage("{PropertyName} must not be empty!")
               .NotNull().WithMessage("{PropertyName} must not be null!");

            RuleFor(x => x.Address)
                .Must(address => address == null || !string.IsNullOrWhiteSpace(address))
                .WithMessage("{PropertyName} must not be empty if provided!");

            RuleFor(x => x.Phone)
                .Must(Phone => Phone == null || !string.IsNullOrWhiteSpace(Phone))
                .WithMessage("{PropertyName} must not be empty if provided!");

        }
        public void ApplyCustomRules()
        {
            RuleFor(x => x.Name)
               .MustAsync(async (Model, Key, CancellationToken) => !await studentService.IsStudentNameExistExceptSelfAsync(Key, Model.StudentId))
               .WithMessage(x => $"the name {x.Name} exists before!");


        }
    }
}
