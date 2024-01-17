using FluentValidation;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyNewProjectApi.Model;

namespace MyNewProjectApi.Validator
{
    public class EmployeeValidator : AbstractValidator<EmployeeDetails>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter a name")
                .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");

            RuleFor(c => c.EmailAddress)
            .NotEmpty().EmailAddress()
            .WithMessage("Email is required for members");

            RuleFor(c => c.Address)
               .NotEmpty().WithMessage("Please enter a name")
               .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");

            RuleFor(x => x.Amount)
            .GreaterThan(100).WithMessage("Amount must be greater than 100");


        }
    }
}