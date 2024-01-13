using System.ComponentModel.DataAnnotations;

namespace FrameWork.DataAnnotations.String
{
    public class RequiredStringAttribute : ValidationAttribute
    {
        public RequiredStringAttribute()
        {
            if (ErrorMessage == null)
                ErrorMessage = "وارد کردن '{0}' الزامی است.";
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
                return new ValidationResult(GetMessage(validationContext));
            else
                return ValidationResult.Success;
        }

        public string GetMessage(ValidationContext validationContext)
        {
            if (ErrorMessage.Contains("{0}"))
                ErrorMessage = ErrorMessage.Replace("{0}", validationContext.DisplayName);

            return ErrorMessage;
        }
    }
}
