using FluentValidation;
using MyTelevisionApi.Model;

namespace MyTelevisionApi.Validater
{
    public class TelivisionValidater: AbstractValidator<MyTelivision>
    {
        public TelivisionValidater()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter a name")
                .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");
        }
    }
}
