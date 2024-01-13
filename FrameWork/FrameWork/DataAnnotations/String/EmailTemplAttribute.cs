using System.ComponentModel.DataAnnotations;
using FrameWork.ExMethods;

namespace FrameWork.DataAnnotations.String
{
    public class EmailTemplAttribute : ValidationAttribute
    {
        public EmailTemplAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "قالب '{0}' صحیح نمی باشد. قالب صحیح: ex@example.com";
        }
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return ValidationResult.Success;

            if (value is not string)
                throw new Exception("Value only can be string.");

            if (!value.ToString().IsMatch("^[a-zA-Z0-9\\-\\._]{3,100}[@][a-zA-Z0-9\\-\\._]{3,100}$"))
                return new ValidationResult(ErrorMessage.Replace("{0}", validationContext.DisplayName));

            return ValidationResult.Success;
        }
    }
}
