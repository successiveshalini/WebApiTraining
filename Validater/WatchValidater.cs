using FluentValidation;
using MyWatchApi.Model;

namespace MyWatchApi.Validater
{
    public class WatchValidater : AbstractValidator<WatchDetails>
    {
        public WatchValidater()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please enter a name")
                .Length(0, 10).WithMessage("Name length should be between 0 and 10 characters");
        }
    }
}
