using FluentValidation;
using NewCrudOperationApi.Model;

namespace NewCrudOperationApi.Validator
{
    public class EmployeeValidator:AbstractValidator<EmployeeModel>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Please Enter a Name")
               .Length(1, 20).WithMessage("Name length should be between 1 and 20 characters");

            RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Invalid Email Address Formate");




        }
    }
}
