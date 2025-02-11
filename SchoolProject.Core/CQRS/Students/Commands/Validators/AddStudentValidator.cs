using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Interfaces;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService studentService;
        private readonly IDepartmentService departmentService;

        public AddStudentValidator(IStudentService studentService, IDepartmentService departmentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            this.studentService = studentService;
            this.departmentService = departmentService;
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
               .WithMessage(x => $"The name {x.Name} exists before!");
            RuleFor(x => x.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => await departmentService.IsDepartmentExistByIdAsync(Key))
                .WithMessage(x => $"The departmetn ID: {x.DepartmentId} doesn't exist!");

        }
    }
}
