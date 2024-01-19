using FluentValidation;
using SimpleWebApiProject.Model;

namespace SimpleWebApiProject.Validator
{
    public class StudentValidator : AbstractValidator<StudentDetails>
    {
        public StudentValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Name Should not be Empty")
                .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");


            RuleFor(e => e.Address)
                .NotEmpty().WithMessage("Address should not be Empty")
                .Length(0, 10).WithMessage("Address length should be between 0 and 10 characters");

            RuleFor(e => e.EmailAddress)
                .NotEmpty().WithMessage("Email should not be empty")
                .EmailAddress().WithMessage("Email address should be in Valid Format");

            RuleFor(e => e.Age)
                .NotEmpty().WithMessage("Age cannot be empty")
                .InclusiveBetween(40, 60).WithMessage("Age must be between 40 and 60");

            RuleFor(e => e.Phone)
                .NotEmpty().WithMessage("phone cannot be empty");






        }



    }
}
