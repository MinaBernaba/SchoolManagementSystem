using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService studentService;

        public AddStudentValidator(IStudentService studentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
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
        }
        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
               .MustAsync(async (Key, CancellationToken) => !await studentService.IsStudentNameExistAsync(Key))
               .WithMessage(x => $"the name {x.Name} exists before!");

        }
    }
}
