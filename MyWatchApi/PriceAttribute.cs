using System.ComponentModel.DataAnnotations;

namespace MyWatchApi
{
    public class PriceAttribute : ValidationAttribute
    {
        protected override ValidationResult  IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || !(value is decimal))
            {
                return new ValidationResult("Invalid price format.");
            }
            decimal price = (decimal)value;
            if (price <= 0)
            {
                return new ValidationResult("Price must be greater than zero.");
            }
            return ValidationResult.Success;
        }
    }
}
