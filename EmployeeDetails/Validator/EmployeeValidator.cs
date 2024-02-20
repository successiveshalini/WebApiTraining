using EmployeeDetails.Model;
using FluentValidation;

namespace EmployeeDetails.Validator
{
    public class EmployeeValidator:AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(c => c.Nmae)
               .NotEmpty().WithMessage("Please enter a name")
               .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");

            RuleFor(u => u.Email).EmailAddress();
        }
    }
}
